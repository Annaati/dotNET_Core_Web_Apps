using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        [Required]
        public String Id { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String FullName { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        public String Address { get; set; }


        public List<String> Claims { get; set; }

        public List<String> Roles { get; set; }
    }
}
