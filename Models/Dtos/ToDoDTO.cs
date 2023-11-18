using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jalasoft_devtest_backend.Models.Dtos
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt {get; set; } = new DateTime();
        public DateTime? DueTime  {get; set; } = null;
        public Boolean IsDeleted { get; set; } = false;
        public TodoStatus Status { get; set; } = TodoStatus.NotCompleted;
    }
}