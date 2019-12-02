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
    public class HoursManager
    {
        private readonly WeeklyHoursDataService weeklyHoursDataService;
        private const int OVERTIME_CUT_OFF = 40;
        private ILogger _logger;

        public HoursManager(WeeklyHoursDataService dataService, ILogger<HoursManager> logger)
        {
            weeklyHoursDataService = dataService;
            _logger = logger;
        }

        public SubmitWeeklyHours CreateWeeklyHours(SubmitWeeklyHours submitWeeklyHours)
        {
            SubmitWeeklyHours setHours = SetHours(submitWeeklyHours);
            WeeklyHours hours = new WeeklyHours();
            hours.EmployeeId = setHours.EmployeeId;
            hours.TotalHours = setHours.TotalHours;
            hours.RegularHours = setHours.RegularHours;
            hours.OvertimeHours = setHours.OvertimeHours;
            hours.PtoHours = setHours.PtoHours;
            hours.WeekStartDate = setHours.WeekStartDate;
            hours.WeekEndtDate = setHours.WeekEndtDate;
            hours.Paid = false;
            hours.IsDeleted = false;

            hours = weeklyHoursDataService.CreateWeeklyHours(hours);
            _logger.LogInformation("New Week Submitted with ID: {hoursID} for Employee ID: {employeeID}", hours.Id, hours.EmployeeId);
            return setHours;
        }

        public SubmitWeeklyHours UpdateWeeklyHours(SubmitWeeklyHours submitWeeklyHours)
        {
            SubmitWeeklyHours setHours = SetHours(submitWeeklyHours);
            WeeklyHours hours = new WeeklyHours();
            hours.Id = setHours.Id;
            hours.EmployeeId = setHours.EmployeeId;
            hours.TotalHours = setHours.TotalHours;
            hours.RegularHours = setHours.RegularHours;
            hours.OvertimeHours = setHours.OvertimeHours;
            hours.PtoHours = setHours.PtoHours;
            hours.WeekStartDate = setHours.WeekStartDate;
            hours.WeekEndtDate = setHours.WeekEndtDate;
            hours.Paid = setHours.Paid;
            hours.IsDeleted = false;

            weeklyHoursDataService.UpdateWeeklyHours(hours);
            _logger.LogInformation("Week Updated with ID: {hoursID} for Employee ID: {employeeID}", hours.Id, hours.EmployeeId);
            return setHours;
        }

        public SubmitWeeklyHours GetWeeklyHours(int id)
        {
            WeeklyHours weeklyHours = weeklyHoursDataService.GetWeeklyHours(id);
            SubmitWeeklyHours hours = new SubmitWeeklyHours();
            hours.Id = weeklyHours.Id;
            hours.EmployeeId = weeklyHours.EmployeeId;
            hours.TotalHours = weeklyHours.TotalHours;
            hours.RegularHours = weeklyHours.RegularHours;
            hours.OvertimeHours = weeklyHours.OvertimeHours;
            hours.PtoHours = weeklyHours.PtoHours;
            hours.WeekStartDate = weeklyHours.WeekStartDate;
            hours.WeekEndtDate = weeklyHours.WeekEndtDate;
            hours.Paid = weeklyHours.Paid;
            hours.IsDeleted = weeklyHours.IsDeleted;

            return hours;
        }

        public void DeleteWeeklyHours(int id)
        {
            weeklyHoursDataService.DeleteWeeklyHours(id);
            _logger.LogInformation("Week Deleted with ID: {hoursID}.", id);
        }

        public IList<WeeklyHours> GetAllWeeklyHours()
        {
            return weeklyHoursDataService.GetAllWeeklyHours();
        }

        public IList<WeeklyHours> GetAllPaidWeeklyHours()
        {
            return weeklyHoursDataService.GetAllPaidWeeklyHours();
        }

        public IList<WeeklyHours> GetAllUnPaidWeeklyHours()
        {
            return weeklyHoursDataService.GetAllUnPaidWeeklyHours();
        }

        public IList<WeeklyHours> GetAllUnPaidWeeklyHoursForEmployee(int id)
        {
            return weeklyHoursDataService.GetAllUnPaidWeeklyHoursForEmployee(id);
        }

        private SubmitWeeklyHours SetHours(SubmitWeeklyHours hours)
        {
            double totalHours = hours.TotalHours;

            if(totalHours > OVERTIME_CUT_OFF)
            {
                hours.RegularHours = 40;
                hours.OvertimeHours = totalHours - 40;
            } else
            {
                hours.RegularHours = totalHours;
                hours.OvertimeHours = 0;
            }

            return hours;
        }
    }
}
