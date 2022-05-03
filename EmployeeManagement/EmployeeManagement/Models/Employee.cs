using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage="Name can not excede 50 charactors")]
        public String Name { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage="Invalid Email format")]
        public String Email { get; set; }
        [Required]
        public DeptsEnum? Dep { get; set; }
        public String PhotoPath { get; set; }
    }
}
