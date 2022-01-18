using Application.Dal;
using Application.Dal.Domain.PlanCalendar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.PlanCalendar
{
    public class PlanCalendarSevice: IPlanCalendarSevice
    {
        private readonly PlanCalendarRepository _planCalendarRepository;

        public PlanCalendarSevice(PlanCalendarRepository planCalendarRepository)
        {
            _planCalendarRepository = planCalendarRepository;
        }

        public void CreatePlanCalendar(Dal.Domain.PlanCalendar.PlanCalendar item)
        {
            if(item != null)
                _planCalendarRepository.Add(item);
        }

        public void UpdatePlanCalendar(Dal.Domain.PlanCalendar.PlanCalendar item)
        {
            _planCalendarRepository.Update(item);
        }

        public void DeletePlanCalendar(Dal.Domain.PlanCalendar.PlanCalendar item)
        {
            _planCalendarRepository.Delete(item);
        }

        public Dal.Domain.PlanCalendar.PlanCalendar GetPlanCalendar(string itemId)
        {
            return _planCalendarRepository.Get(itemId);        
        }

        public List<Dal.Domain.PlanCalendar.EventCalendar> GetEventsForWeek()
        {
            var currentDate = DateTime.Today;

            int daysOffsetEnd = DayOfWeek.Saturday - currentDate.DayOfWeek;
            int dayOffsetStart = currentDate.DayOfWeek - DayOfWeek.Monday;

            var startDate = currentDate.AddDays(dayOffsetStart * -1);
            var endDate = currentDate.AddDays(daysOffsetEnd);

            List<EventCalendar> result = new List<EventCalendar>();

            var i = 0;
            var tempDate = endDate;
            while (startDate != tempDate)
            {
                if (i < -7)
                {
                    return null;
                }
                tempDate = endDate.AddDays(i);
                i--;
                var resTemp = _planCalendarRepository.GetPlanCanedraForEvents(tempDate.Month, tempDate.Year);
                if (resTemp != null) result.AddRange(resTemp.Events.Where(e => TryParseDay(e.Day, tempDate.Day)).ToList());
            }

            return result;

        }

        public List<Dal.Domain.PlanCalendar.EventCalendar> GetEventsByYearAndMonth(int year, int month)
        {
            return _planCalendarRepository.GetPlanCanedraForEvents(month, year)?.Events.Where(e => int.TryParse(e.Day, out var tesult)).ToList();
        }

         private bool TryParseDay(string dbDay, int dateDay)
        {
            var isNumber = int.TryParse(dbDay, out int tryDay);

            if(!isNumber || tryDay != dateDay) return false;

            return true;
        }    
    }
}
