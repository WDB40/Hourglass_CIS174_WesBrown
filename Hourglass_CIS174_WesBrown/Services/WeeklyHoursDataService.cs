using Hourglass_CIS174_WesBrown.Data;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Services
{
    public class WeeklyHoursDataService
    {
        private readonly HourglassDBContext _context;

        public WeeklyHoursDataService(HourglassDBContext context)
        {
            _context = context;
        }

        public WeeklyHours CreateWeeklyHours(WeeklyHours weeklyHours)
        {
            weeklyHours = _context.WeeklyHours.Add(weeklyHours).Entity;
            _context.SaveChanges();
            return weeklyHours;
        }

        public WeeklyHours UpdateWeeklyHours(WeeklyHours updatedWeeklyHours)
        {
            _context.WeeklyHours.Update(updatedWeeklyHours);
            _context.SaveChanges();
            return updatedWeeklyHours;
        }

        public IList<WeeklyHours> GetAllWeeklyHours()
        {
            return _context.WeeklyHours
                .Where(hours => !hours.IsDeleted)
                .ToList();
        }

        public WeeklyHours GetWeeklyHours(int id)
        {
            return _context.WeeklyHours.Find(id);
        }

        public void DeleteWeeklyHours(int id)
        {
            _context.WeeklyHours.Find(id).IsDeleted = true;
            _context.SaveChanges();
        }

        public IList<WeeklyHours> GetAllPaidWeeklyHours()
        {
            return _context.WeeklyHours
                .Where(hours => !hours.IsDeleted && hours.Paid)
                .ToList();
        }

        public IList<WeeklyHours> GetAllUnPaidWeeklyHours()
        {
            return _context.WeeklyHours
                .Where(hours => !hours.IsDeleted && !hours.Paid)
                .ToList();
        }

        public IList<WeeklyHours> GetAllUnPaidWeeklyHoursForEmployee(int id)
        {
            return _context.WeeklyHours
                .Where(hours => !hours.IsDeleted && hours.EmployeeId == id && !hours.Paid)
                .ToList();
        }
    }
}
