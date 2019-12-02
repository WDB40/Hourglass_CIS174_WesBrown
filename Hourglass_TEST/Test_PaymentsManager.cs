using Hourglass_CIS174_WesBrown.BusinessLogic;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hourglass_TEST
{
    public class Test_PaymentsManager
    {
        [Theory]
        [InlineData(10, 40, 0, 0, 400)]
        [InlineData(10, 30, 0, 0, 300)]
        [InlineData(10, 40, 10, 0, 550)]
        [InlineData(10, 40, 0, 10, 500)]
        [InlineData(10, 40, 10, 10, 650)]
        public void CalculatePaymentAmount(double payRate, double regularHours, double overtimeHours, double ptoHours, double expectedResult)
        {
            PaymentsManager manager = new PaymentsManager(); 
            Employee employee = new Employee();
            employee.PayRate = payRate;
            WeeklyHours hours = new WeeklyHours();
            hours.RegularHours = regularHours;
            hours.OvertimeHours = overtimeHours;
            hours.PtoHours = ptoHours;

            double result = manager.CalculatePaymentAmount(employee, hours);

            Assert.Equal(expectedResult, result);
        }
    }
}
