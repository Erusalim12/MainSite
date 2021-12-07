using System;
using System.Collections.Generic;

namespace MainSite.Areas.Admin.Models.Counters
{
    public class CounterView
    {
        public DateTime TodayDate { get; set; }
        public DateTime ThreeDayDate { get; set; }
        public DateTime WeekDate { get; set; }
        public int TodayCount { get; set; }
        public int PrevDayCount { get; set; }
        public int TotalCount { get; set; }
        public int WeekCount { get; set; }
        public int ThreeDayCount { get; set; }
        public int CurrentMonthCount { get; set; }
        public int PrevMonthCount { get; set; }
        public int PrevWeekCount { get; set; }
    }

    public class CalendarCounterView
    {
        public IEnumerable<DailyCounter> Counter { get; set; }

    }

    public class DailyCounter
    {
        public DateTime date { get; set; }
        public int Count { get; set; }
        public int ToPrev { get; set; }

        public bool? Trend
        {
            get
            {

                if (ToPrev > 0) return true;
                if (ToPrev == 0) return null;
                return false;

            }
        }
    }
}
