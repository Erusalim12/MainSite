using Application.Dal.Domain.PlanCalendar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Dal
{
    public class PlanCalendarRepository :  EfRepository<PlanCalendar>
    {
        public PlanCalendarRepository(ApplicationContext context) : base(context)
        {

        }

        public IEnumerable<PlanCalendar> GetEventsForWeek()
        {
            return _context.PlanCalendars
                .OrderBy(c => c.Year)
                .ThenBy(c => c.Month)
                .Include(a => a.Events);
        }

        public PlanCalendar GetPlanCanedraForEvents(int month, int year)
        {
            return _context.PlanCalendars.Where(a => a.Month == month && a.Year == year).Include(w => w.Events).FirstOrDefault();
        }
    }
}
