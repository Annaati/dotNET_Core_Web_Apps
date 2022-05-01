using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1, Name="Hassan Hussein Husni", Gender="Male", Email="Hassan@gmail.com", Dep=DeptsEnum.HR},
                new Employee() {Id=2, Name="Abdullahi Ahmed", Gender="Male", Email="Abdullahi@gmail.com", Dep=DeptsEnum.ICT},
                new Employee() {Id=3, Name="Farhiya Hassan Abdullahi", Gender="Female", Email="Farhiya@gmail.com", Dep=DeptsEnum.Marketing},
                new Employee() {Id=4, Name="Ahmed Ali Nour", Gender="Male", Email="AhmedAli@gmail.com", Dep=DeptsEnum.HR},
                new Employee() {Id=5, Name="Halima Adan Mohammed", Gender="Female", Email="Halima@gmail.com", Dep= DeptsEnum.Sales}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e =>e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
