using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly systemdbContext context;

        public SQLEmployeeRepository(systemdbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee addEmployee)
        {
            context.Employees.Add(addEmployee);
            context.SaveChanges();
            return addEmployee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = context.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return updateEmployee;
        }
    }
}
