using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jalasoft_devtest_backend.Data;
using jalasoft_devtest_backend.Models;
using jalasoft_devtest_backend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace jalasoft_devtest_backend.Repositories.Implementation
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;
        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ToDo> CreateAsync(ToDo toDo)
        {
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();

            return toDo;
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(int id)
        {
            var toDo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            return toDo;
        }


        public async Task<ToDo?> UpdateAsync(ToDo toDo)
        {
            var existingToDo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == toDo.Id);

            if (existingToDo is null)
                return null;

            toDo.UpdatedAt = DateTime.Now;
            toDo.CreatedAt = existingToDo.CreatedAt;
            
            _context.Entry(existingToDo).CurrentValues.SetValues(toDo);
            await _context.SaveChangesAsync();

            return existingToDo;
        }
        public async Task<ToDo?> SoftDeleteAsync(int id)
        {
            var existingToDo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            if (existingToDo is null)
                return null;

            var softDeletedTodo = new ToDo 
            {
                Id = id,
                Title = existingToDo.Title,
                Description = existingToDo.Description,
                CreatedAt = existingToDo.CreatedAt,
                UpdatedAt = DateTime.Now,
                DueTime = existingToDo.DueTime,
                IsDeleted = true,
                Status = existingToDo.Status
            };
            
            _context.Entry(existingToDo).CurrentValues.SetValues(softDeletedTodo);

            return softDeletedTodo;
        }
    }
}