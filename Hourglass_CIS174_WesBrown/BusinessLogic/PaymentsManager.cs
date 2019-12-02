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
    public class PaymentsManager
    {
        private readonly PaymentsDataService paymentsDataService;
        private readonly EmployeeDataService employeeDataService;
        private readonly WeeklyHoursDataService weeklyHoursDataService;
        private ILogger _logger;
        private const double OVERTIME_BONUS = 1.5;

        public PaymentsManager(PaymentsDataService pDataService, EmployeeDataService eDataService, WeeklyHoursDataService wDataService, ILogger<PaymentsManager> logger)
        {
            paymentsDataService = pDataService;
            employeeDataService = eDataService;
            weeklyHoursDataService = wDataService;
            _logger = logger;
        }

        public Payment CreatePayment(int id)
        {
            Payment payment = new Payment();
            WeeklyHours weeklyHours = weeklyHoursDataService.GetWeeklyHours(id);
            payment.WeeklyHoursId = id;
            payment.EmployeeId = weeklyHours.EmployeeId;
            payment.PaymentDate = DateTime.Now;
            Employee employee = employeeDataService.GetEmployee(weeklyHours.EmployeeId);
            payment.PaymentAmount = CalculatePaymentAmount(employee, weeklyHours);
            payment = paymentsDataService.CreatePayment(payment);

            weeklyHours.Paid = true;
            weeklyHoursDataService.UpdateWeeklyHours(weeklyHours);

            _logger.LogInformation("Weekly Timesheet with ID: {hoursID} paid with Payment ID: {paymentID}", weeklyHours.Id, payment.Id);

            return payment;
        }

        public IList<AllPayments> GetUnpaidTimesheets()
        {
            IList<WeeklyHours> allTimesheets = weeklyHoursDataService.GetAllUnPaidWeeklyHours();
            IList<AllPayments> allPayments = new List<AllPayments>();
            AllPayments thisPayment;
            Employee employee;

            foreach (WeeklyHours hours in allTimesheets)
            {
                thisPayment = new AllPayments();
                employee = employeeDataService.GetEmployee(hours.EmployeeId);
                thisPayment.WeeklyHoursId = hours.Id;
                thisPayment.FirstName = employee.FirstName;
                thisPayment.LastName = employee.LastName;
                thisPayment.RegularHours = hours.RegularHours;
                thisPayment.OvertimeHours = hours.OvertimeHours;
                thisPayment.PtoHours = hours.PtoHours;
                thisPayment.StartDate = hours.WeekStartDate;
                thisPayment.EndDate = hours.WeekEndtDate;

                allPayments.Add(thisPayment);
            }

            return allPayments;
        }

        private double CalculatePaymentAmount(Employee employee, WeeklyHours weeklyHours)
        {
            double payRate = employee.PayRate;
            double regularHours = weeklyHours.RegularHours;
            double overtimeHours = weeklyHours.OvertimeHours * OVERTIME_BONUS;
            double ptoHours = weeklyHours.PtoHours;

            return (regularHours + overtimeHours + ptoHours) * payRate;
        }
    }
}
