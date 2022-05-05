using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.controllers
{
    public class HomeController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, 
                            IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            throw new Exception("Exception error Occured in Details");

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details",
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadeEmpProfPic(model);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Dep = model.Dep,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { Id = newEmployee.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Email = employee.Email,
                Dep = employee.Dep,
                ExistingPhotPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employeeEdit = _employeeRepository.GetEmployee(model.Id);
                employeeEdit.Name = model.Name;
                employeeEdit.Gender = model.Gender;
                employeeEdit.Email = model.Email;
                employeeEdit.Dep = model.Dep;

                if (model.Photo != null)
                {
                    if(model.ExistingPhotPath != null)
                    {
                        String filepath = Path.Combine(hostingEnvironment.WebRootPath, "assets/images/employees", model.ExistingPhotPath);
                            System.IO.File.Delete(filepath);
                    }
                   employeeEdit.PhotoPath = ProcessUploadeEmpProfPic(model);
                }
                _employeeRepository.Update(employeeEdit);
                return RedirectToAction("index");
            }
            return View();
        }

        private IDisposable File(string filepath, FileMode open)
        {
            throw new NotImplementedException();
        }

        private string ProcessUploadeEmpProfPic(EmployeeCreateViewModel model)
        {
            String uniqueFileName = null;
            if (model.Photo != null)
            {
                String uploadedEmployee = Path.Combine(hostingEnvironment.WebRootPath, "assets/images/employees");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                String FilePath = Path.Combine(uploadedEmployee, uniqueFileName);

                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }

                //model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
            }

            return uniqueFileName;
        }
    }
}
