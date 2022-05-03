using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Ahmed Abdi Ali",
                    Gender = "Male",
                    Email = "AAA@gmail.com",
                    Dep = DeptsEnum.ICT
                },
                new Employee
                {
                    Id = 2,
                    Name = "Maryam Farah Abdullahi",
                    Gender = "Male",
                    Email = "MFA@gmail.com",
                    Dep = DeptsEnum.Marketing
                }
                );
        }
    }
}
