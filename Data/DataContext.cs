using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jalasoft_devtest_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace jalasoft_devtest_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<ToDo> ToDos { get; set; }
       
    }
}