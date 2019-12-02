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
    public class PtoManager
    {
        private readonly PtoRequestDataService ptoRequestDataService;
        private readonly EmployeeDataService employeeDataService;
        private ILogger _logger;

        public PtoManager(PtoRequestDataService dataService, EmployeeDataService eDataService, ILogger<PtoManager> logger)
        {
            ptoRequestDataService = dataService;
            _logger = logger;
            employeeDataService = eDataService;
        }

        public SubmitPTORequest CreatePtoRequest(SubmitPTORequest submitPTORequest)
        {
            PtoRequest ptoRequest = new PtoRequest();
            Employee employee = employeeDataService.GetEmployee(submitPTORequest.EmployeeId);
            ptoRequest.EmployeeId = submitPTORequest.EmployeeId;
            ptoRequest.RequestDate = submitPTORequest.RequestDate;
            ptoRequest.RequestedHours = submitPTORequest.RequestedHours;
            ptoRequest.Approved = false;
            ptoRequest.IsDeleted = false;

            if (HasEnoughPto(employee, ptoRequest.RequestedHours))
            {
                ReducePtoHours(employee, ptoRequest.RequestedHours);
                ptoRequest = ptoRequestDataService.CreatePtoRequest(ptoRequest);
                _logger.LogInformation("PTO Request with ID: {ptoID} Created for Employee ID: {employeeID}.", ptoRequest.Id, ptoRequest.EmployeeId);
            }

            return submitPTORequest;
        }

        public SubmitPTORequest UpdatePtoRequest(SubmitPTORequest submitPtoRequest)
        {
            PtoRequest ptoRequest = new PtoRequest();
            double originalHours = ptoRequestDataService.GetPtoRequest(submitPtoRequest.Id).RequestedHours;
            ptoRequest.Id = submitPtoRequest.Id;
            Employee employee = employeeDataService.GetEmployee(submitPtoRequest.EmployeeId);
            ptoRequest.EmployeeId = submitPtoRequest.EmployeeId;
            ptoRequest.RequestDate = submitPtoRequest.RequestDate;
            ptoRequest.RequestedHours = submitPtoRequest.RequestedHours;
            ptoRequest.Approved = false;
            ptoRequest.IsDeleted = false;

            if (HasEnoughPTOForUpdate(employee, originalHours, ptoRequest.RequestedHours))
            {
                IncreasePtoHours(employee, originalHours);
                ReducePtoHours(employee, ptoRequest.RequestedHours);
                ptoRequestDataService.UpdatePtoRequest(ptoRequest);
                _logger.LogInformation("PTO Request with ID: {ptoID} Updated for Employee ID: {employeeID}.", ptoRequest.Id, ptoRequest.EmployeeId);
            }
            return submitPtoRequest;
        }

        public SubmitPTORequest GetPtoRequest(int id)
        {
            PtoRequest request = ptoRequestDataService.GetPtoRequest(id);
            SubmitPTORequest ptoRequest = new SubmitPTORequest();
            ptoRequest.Id = request.Id;
            ptoRequest.EmployeeId = request.EmployeeId;
            ptoRequest.RequestDate = request.RequestDate;
            ptoRequest.RequestedHours = request.RequestedHours;
            ptoRequest.Approved = request.Approved;
            ptoRequest.IsDeleted = request.IsDeleted;

            return ptoRequest;
        }

        public void DeletePtoRequest(int id)
        {
            PtoRequest ptoRequest = ptoRequestDataService.GetPtoRequest(id);
            Employee employee = employeeDataService.GetEmployee(ptoRequest.EmployeeId);
            ptoRequestDataService.DeletePtoRequest(id);
            _logger.LogInformation("PTO Request with ID: {ptoID} Deleted.", id);
            IncreasePtoHours(employee, ptoRequest.RequestedHours);
        }

        public IList<PtoRequest> GetAllPtoRequests()
        {
            return ptoRequestDataService.GetAllPtoRequests();
        }

        public IList<PtoRequest> GetAllApprovedPtoRequests()
        {
            return ptoRequestDataService.GetAllApprovedPtoRequests();
        }

        public IList<PtoRequest> GetAllNonApprovedPtoRequests()
        {
            return ptoRequestDataService.GetAllNonApprovedPtoRequests();
        }

        public IList<PtoRequest> GetAllPtoRequestsForEmployee(int id)
        {
            return ptoRequestDataService.GetAllPtoRequestForEmployee(id);
        }

        public void ApprovePTO(int id)
        {
            PtoRequest request = ptoRequestDataService.GetPtoRequest(id);
            request.Approved = true;
            ptoRequestDataService.UpdatePtoRequest(request);
            _logger.LogInformation("PTO Request with ID: {ptoID} Approved.", id);
        }

        public void DenyPTO(int id)
        {
            DeletePtoRequest(id);
            _logger.LogInformation("PTO Request with ID: {ptoID} Denied.", id);
        }

        public bool HasEnoughPto(Employee employee, double hours)
        {
            return employee.RemainingPtoHours >= hours;
        }

        public void ReducePtoHours(Employee employee, double hours)
        {
            employee.RemainingPtoHours = employee.RemainingPtoHours - hours;
            employeeDataService.UpdateEmployee(employee);
        }
        
        public void IncreasePtoHours(Employee employee, double hours)
        {
            employee.RemainingPtoHours = employee.RemainingPtoHours + hours;
            employeeDataService.UpdateEmployee(employee);
        }

        public bool HasEnoughPTOForUpdate(Employee employee, double originalHours, double newHours)
        {
            employee.RemainingPtoHours = employee.RemainingPtoHours + originalHours;
            return HasEnoughPto(employee, newHours);
        }
    }
}
