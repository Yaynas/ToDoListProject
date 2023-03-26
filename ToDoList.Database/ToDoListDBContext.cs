using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Database;

namespace ToDoList.Database
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<WorkTask> WorkTask { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"FileName={Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "toDoListApp.sqlite")}");
        }
    }
}
