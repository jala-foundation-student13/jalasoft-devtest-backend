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

        [HttpPost]
        public async Task<IActionResult> CreateToDo (PostToDoRequestDTO request)
        {
            var toDo = new ToDo
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
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
                IsDeleted = toDo.IsDeleted,
                Status = toDo.Status
            };

            return Ok(response);
        }
    }
}