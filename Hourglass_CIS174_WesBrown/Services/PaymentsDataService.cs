using Hourglass_CIS174_WesBrown.Data;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Services
{
    public class PaymentsDataService
    {
        private readonly HourglassDBContext _context;

        public PaymentsDataService(HourglassDBContext context)
        {
            _context = context;
        }

        public Payment CreatePayment(Payment payment)
        {
            payment = _context.Payments.Add(payment).Entity;
            _context.SaveChanges();
            return payment;
        }

        public Payment UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
            return payment;
        }

        public IList<Payment> GetAllPayments()
        {
            return _context.Payments
                .Where(payment => !payment.IsDeleted)
                .ToList();
        }

        public IList<Payment> GetAllPaymentsForEmployee(int id)
        {
            return _context.Payments
                .Where(payment => !payment.IsDeleted && payment.EmployeeId == id)
                .ToList();
        }

        public Payment GetPayment(int id)
        {
            return _context.Payments.Find(id);
        }

        public void DeletePayment(int id)
        {
            _context.Payments.Find(id).IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
