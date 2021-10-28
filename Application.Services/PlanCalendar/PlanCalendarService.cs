using Application.Dal;
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

        public IEnumerable<Dal.Domain.PlanCalendar.EventCalendar> GetEventsForWeek()
        {

            return _planCalendarRepository.GetLast()?.Events.Where(a => IncludeDayInWeek(int.TryParse(a.Day, out int day), day));
        }

        private bool IncludeDayInWeek(bool isNumber, int day)
        {
            if(!isNumber) return false;

            var nowDate = DateTime.Now;

            //var startDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day);

            int daysOffsetStart = nowDate.DayOfWeek - DayOfWeek.Monday;
            int daysOffsetEnd = DayOfWeek.Saturday - nowDate.DayOfWeek;

            var endDate = nowDate.AddDays(daysOffsetEnd);
            var startDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day - daysOffsetStart);

            var dateToCheck = new DateTime(nowDate.Year, nowDate.Month, day);

            if (dateToCheck >= startDate && dateToCheck <= endDate)
            {
                return true;
            }

            return false;
        }

        private bool IsCorrectlyTime(string timeValue)
        {
            if(!String.IsNullOrWhiteSpace(timeValue))
            {
                return int.TryParse(timeValue[0].ToString(), out int num);
            }

            return false;
        }
    }
}
