using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalureProject2.Models;

namespace WalureProject2.Context
{
    public class Employee1DBContext: DbContext
    {

        public Employee1DBContext(DbContextOptions<Employee1DBContext> options): base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
