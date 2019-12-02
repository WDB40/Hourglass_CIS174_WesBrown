using Hourglass_CIS174_WesBrown.Data;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Services
{
    public class PtoRequestDataService
    {
        private readonly HourglassDBContext _context;

        public PtoRequestDataService(HourglassDBContext context)
        {
            _context = context;
        }

        public PtoRequest CreatePtoRequest(PtoRequest ptoRequest)
        {
            ptoRequest = _context.PtoRequests.Add(ptoRequest).Entity;
            _context.SaveChanges();
            return ptoRequest;
        }

        public PtoRequest UpdatePtoRequest(PtoRequest updatedPtoRequest)
        {
            _context.PtoRequests.Update(updatedPtoRequest);
            _context.SaveChanges();
            return updatedPtoRequest;
        }
        
        public IList<PtoRequest> GetAllPtoRequests()
        {
            return _context.PtoRequests
                .Where(request => !request.IsDeleted)
                .ToList();
        }

        public PtoRequest GetPtoRequest(int id)
        {
            return _context.PtoRequests.Find(id);
        }

        public void DeletePtoRequest(int id)
        {
            _context.PtoRequests.Find(id).IsDeleted = true;
            _context.SaveChanges();
        }

        public IList<PtoRequest> GetAllApprovedPtoRequests()
        {
            return _context.PtoRequests
                .Where(request => !request.IsDeleted && request.Approved)
                .ToList();
        }

        public IList<PtoRequest> GetAllNonApprovedPtoRequests()
        {
            return _context.PtoRequests
                .Where(request => !request.IsDeleted && !request.Approved)
                .ToList();
        }

        public IList<PtoRequest> GetAllPtoRequestForEmployee(int id)
        {
            return _context.PtoRequests
                .Where(request => !request.IsDeleted && request.EmployeeId == id)
                .ToList();
        }

    }
}
