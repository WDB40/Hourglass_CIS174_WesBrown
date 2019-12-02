using Hourglass_CIS174_WesBrown.BusinessLogic;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hourglass_TEST
{
    public class Test_PtoManager
    {
        [Theory]
        [InlineData(10, 8, true)]
        [InlineData(100, 8, true)]
        [InlineData(8, 8, true)]
        [InlineData(7, 8, false)]
        [InlineData(0, 8, false)]
        public void HasEnoughPto(double remainingHours, double requestedHours, bool expectedResult)
        {
            PtoManager manager = new PtoManager();
            Employee employee = new Employee();
            employee.RemainingPtoHours = remainingHours;

            bool result = manager.HasEnoughPto(employee, requestedHours);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(4, 4, 8, true)]
        [InlineData(8, 4, 8, true)]
        [InlineData(0, 8, 8, true)]
        [InlineData(4, 3, 8, false)]
        [InlineData(0, 3, 8, false)]
        [InlineData(1, 7, 8, true)]
        public void HasEnoughPtoForUpdate(double remainingHours, double originalHours, double newHours, bool expectedResult)
        {
            PtoManager manager = new PtoManager();
            Employee employee = new Employee();
            employee.RemainingPtoHours = remainingHours;

            bool result = manager.HasEnoughPTOForUpdate(employee, originalHours, newHours);

            Assert.Equal(expectedResult, result);
        }
    }
}
