using Hourglass_CIS174_WesBrown.BusinessLogic;
using Hourglass_CIS174_WesBrown.DAO;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using Xunit;

namespace Hourglass_TEST
{
    public class TestHoursManager
    {
        [Theory]
        [InlineData(40, 40, 0)]
        [InlineData(50, 40, 10)]
        [InlineData(30, 30, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(41, 40, 1)]
        public void SetHours(double totalHours, double expectedRegularHours, double expectedOvertimeHours)
        {
            HoursManager manager = new HoursManager();
            SubmitWeeklyHours hours = new SubmitWeeklyHours();
            hours.TotalHours = totalHours;

            hours = manager.SetHours(hours);

            Assert.Equal(expectedRegularHours, hours.RegularHours);
            Assert.Equal(expectedOvertimeHours, hours.OvertimeHours);
        }
    }
}
