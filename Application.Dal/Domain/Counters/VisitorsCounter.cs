using System;

namespace Application.Dal.Domain.Counters
{
    /// <summary>
    /// represent counter data in db
    /// </summary>
    public class VisitorsCounter : BaseEntity
    {
        public DateTime LastDate { get; set; }
        public int TodayCount { get; set; }
        public int TotalCount { get; set; }

    }
}