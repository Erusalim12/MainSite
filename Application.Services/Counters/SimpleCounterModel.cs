namespace Application.Services.Counters
{
    public class SimpleCounterModel
    {
        public SimpleCounterModel()
        {
            
        }

        public SimpleCounterModel(int todayCount, int totalCount)
        {
            TodayCount = todayCount;
            TotalCount = totalCount;
        }
        public int TodayCount { get; set; }
        public int TotalCount { get; set; }
    }
}