using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jalasoft_devtest_backend.Models.Dtos
{
    public class UpdateToDoRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime  {get; set; } = null;
        public TodoStatus Status { get; set; } = TodoStatus.NotCompleted;

    }
}