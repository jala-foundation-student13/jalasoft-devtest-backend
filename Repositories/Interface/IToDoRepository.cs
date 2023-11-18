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
        Task<IEnumerable<ToDo>> GetAllAsync ();
        Task<ToDo?> GetByIdAsync (int id);
        Task<ToDo?> UpdateAsync (ToDo toDo);
        Task<ToDo?> SoftDeleteAsync (int id);
    }
}