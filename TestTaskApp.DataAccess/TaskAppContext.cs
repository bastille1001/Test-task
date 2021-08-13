using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.DataAccess
{
    public class TaskAppContext : DbContext
    {
        public TaskAppContext(DbContextOptions<TaskAppContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
