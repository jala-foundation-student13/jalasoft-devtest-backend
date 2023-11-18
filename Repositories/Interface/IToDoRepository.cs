using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jalasoft_devtest_backend.Models;

namespace jalasoft_devtest_backend.Repositories.Interface
{
    public interface IToDoRepository
    {
        Task<ToDo> CreateAsync(ToDo toDo);
    }
}