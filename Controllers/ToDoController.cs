using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jalasoft_devtest_backend.Models;
using jalasoft_devtest_backend.Models.Dtos;
using jalasoft_devtest_backend.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace jalasoft_devtest_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;
        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDos ()
        {
            var toDos = await _repository.GetAllAsync();

            var response = new List<ToDoDTO>();
            foreach (var toDo in toDos)
            {
                if (toDo.IsDeleted != true)
                {
                    response.Add(new ToDoDTO
                    {
                        Id = toDo.Id,
                        Title = toDo.Title,
                        Description = toDo.Description,
                        CreatedAt = toDo.CreatedAt,
                        UpdatedAt = toDo.UpdatedAt,
                        DueTime = toDo.DueTime,
                        IsDeleted = toDo.IsDeleted,
                        Status = toDo.Status
                    });
                }
            }
            
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetToDoById([FromRoute] int id)
        {
            var foundToDo = await _repository.GetByIdAsync(id);

            if(foundToDo is null)
                return NotFound();
            
            var response = new ToDoDTO 
            {
                Id = foundToDo.Id,
                Title = foundToDo.Title,
                Description = foundToDo.Description,
                CreatedAt = foundToDo.CreatedAt,
                UpdatedAt = foundToDo.UpdatedAt,
                DueTime = foundToDo.DueTime,
                IsDeleted = foundToDo.IsDeleted,
                Status = foundToDo.Status
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo (PostToDoRequestDTO request)
        {
            var toDo = new ToDo
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DueTime = request.DueTime,
                IsDeleted = false,
                Status = TodoStatus.NotCompleted
            };

            await _repository.CreateAsync(toDo);

            var response = new ToDoDTO
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Description = toDo.Description,
                CreatedAt = toDo.CreatedAt,
                UpdatedAt = toDo.UpdatedAt,
                DueTime = toDo.DueTime,
                IsDeleted = toDo.IsDeleted,
                Status = toDo.Status
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateToDo([FromRoute] int id, UpdateToDoRequestDTO request)
        {
            var toDo = new ToDo
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DueTime = null,
                IsDeleted = false,
                Status = request.Status
            };

            toDo = await _repository.UpdateAsync(toDo);

            if (toDo is null)
             return NotFound();

            var response = new ToDoDTO
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Description = toDo.Description,
                CreatedAt = toDo.CreatedAt,
                UpdatedAt = toDo.UpdatedAt,
                DueTime = toDo.DueTime,
                IsDeleted = toDo.IsDeleted,
                Status = toDo.Status
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> SoftDeleteTodo([FromRoute] int id) 
        {
            var toDo = await _repository.SoftDeleteAsync(id);
            if (toDo is null)
             return NotFound();

            var response = new ToDoDTO
            {
                Id = toDo.Id,
                Title = toDo.Title,
                Description = toDo.Description,
                CreatedAt = toDo.CreatedAt,
                UpdatedAt = toDo.UpdatedAt,
                DueTime = toDo.DueTime,
                IsDeleted = toDo.IsDeleted,
                Status = toDo.Status
            };

            return Ok(response);
        }
    }
}