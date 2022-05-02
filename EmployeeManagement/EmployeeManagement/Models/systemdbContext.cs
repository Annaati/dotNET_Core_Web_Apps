using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class systemdbContext: DbContext
    {
        public systemdbContext(DbContextOptions<systemdbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
