using Hourglass_CIS174_WesBrown.DAO;
using Hourglass_CIS174_WesBrown.Entity;
using Hourglass_CIS174_WesBrown.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.BusinessLogic
{
    public class EmployeeManager
    {
        private readonly EmployeeDataService employeeDataService;
        private ILogger _logger;

        public EmployeeManager(EmployeeDataService dataService, ILogger<EmployeeManager> logger)
        {
            employeeDataService = dataService;
            _logger = logger;
        }

        public EmployeeModifier CreateEmployee(EmployeeModifier employeeModifier)
        {
            Employee employee = new Employee();
            employee.FirstName = employeeModifier.FirstName;
            employee.LastName = employeeModifier.LastName;
            employee.PayRate = employeeModifier.PayRate;
            employee.RemainingPtoHours = employeeModifier.RemainingPtoHours;
            employee.IsDeleted = false;

            employeeDataService.CreateEmployee(employee);
            _logger.LogInformation("New Employee Created - ID: {employeeID}", employee.Id);
            return employeeModifier;
        }

        public EmployeeModifier UpdateEmployee(EmployeeModifier employeeModifier)
        {
            Employee employee = new Employee();
            employee.Id = employeeModifier.Id;
            employee.FirstName = employeeModifier.FirstName;
            employee.LastName = employeeModifier.LastName;
            employee.PayRate = employeeModifier.PayRate;
            employee.RemainingPtoHours = employeeModifier.RemainingPtoHours;
            employee.IsDeleted = false;
            employeeDataService.UpdateEmployee(employee);
            _logger.LogInformation("Employee Updated - ID: {employeeID}", employee.Id);
            return employeeModifier;
        }

        public void DeleteEmployee(int id)
        {
            employeeDataService.DeleteEmployee(id);
            _logger.LogInformation("Employee Deleted - ID: {employeeID}", id);
        }

        public IList<Employee> GetAllEmployees()
        {
            return employeeDataService.GetAllEmployees();
        }

        public EmployeeModifier GetEmployee(int id)
        {
            Employee employee = employeeDataService.GetEmployee(id);
            EmployeeModifier modifier = new EmployeeModifier();
            modifier.Id = employee.Id;
            modifier.FirstName = employee.FirstName;
            modifier.LastName = employee.LastName;
            modifier.PayRate = employee.PayRate;
            modifier.RemainingPtoHours = employee.RemainingPtoHours;

            return modifier;
        }
    }
}
