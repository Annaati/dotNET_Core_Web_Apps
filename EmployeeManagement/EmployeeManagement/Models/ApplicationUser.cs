using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public String FullName { get; set; }

        [Required]
        public String Gender { get; set; }
        [Required]
        public String Address { get; set; }
    }
}
