using Hourglass_CIS174_WesBrown.Data;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Services
{
    public class EmployeeDataService
    {
        private readonly HourglassDBContext _context;

        public EmployeeDataService(HourglassDBContext context)
        {
            _context = context;
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee = _context.Employees.Add(employee).Entity;
            _context.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;
        }

        public IList<Employee> GetAllEmployees()
        {
            return _context.Employees
                .Where(employee => !employee.IsDeleted)
                .ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public void DeleteEmployee(int id)
        {
            _context.Employees.Find(id).IsDeleted = true;
            _context.SaveChanges();
        }

        public bool EmployeeExists(int id)
        {
            if(GetEmployee(id) == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
