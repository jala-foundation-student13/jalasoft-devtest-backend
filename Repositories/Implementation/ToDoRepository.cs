using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jalasoft_devtest_backend.Data;
using jalasoft_devtest_backend.Models;
using jalasoft_devtest_backend.Repositories.Interface;

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
    }
}