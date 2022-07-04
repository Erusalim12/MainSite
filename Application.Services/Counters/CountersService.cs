using System;
using System.Linq;
using Application.Dal;
using Application.Dal.Domain.Counters;

namespace Application.Services.Counters
{
    public class CountersService
    {

        private static int _todayCounter { get; set; }
        private static int _totalCounter { get; set; }
        private static DateTime _currentDate { get; set; }
        private readonly IRepository<VisitorsCounter> _context;

        public CountersService(IRepository<VisitorsCounter> context)
        {
            _context = context;

            LoadCounters();
        }
        /// <summary>
        /// Возвращает новый экземпляр модели счетчиков
        /// </summary>
        /// <returns></returns>
        public static SimpleCounterModel GetCounter()
        {
            return new SimpleCounterModel(TodayUniqueUsers(), TotalUniqueUsers());
        }
        /// <summary>
        /// возвращает список уникальных посетителей за сегодня
        /// </summary>
        /// <returns></returns>
        public static int TodayUniqueUsers()
        {
            return _todayCounter;
        }

        /// <summary>
        /// возвращает общее количество уникальных поситителей
        /// </summary>
        /// <returns></returns>
        public static int TotalUniqueUsers()
        {
            return _totalCounter;
        }
        /// <summary>
        /// Увеличивает значения счетчиков
        /// </summary>
        public static void IncrementCounter()
        {

            DropTodayCounter();
            _totalCounter++;
            _todayCounter++;
        }
        /// <summary>
        /// сбрасывает текущее значение счетчика, если текущая дата изменилась. в противном случае ничего не делает
        /// </summary>
        /// <param name="force">if true, принудительное обнуление</param>
        private static void DropTodayCounter(bool force = false)
        {
            //если пользователь зашел, а последняя дата не равна сегодняшнему дню => новый день, обнулить счетчик
            if (DateTime.Today.Day == _currentDate.Day && !force) return;

            _todayCounter = 0;
            _currentDate = DateTime.Today;
        }


        /// <summary>
        /// обновление статистики в бд
        /// </summary>
        public void SaveCounters()
        {

            var data = _context.GetAll.FirstOrDefault(c => c.LastDate == DateTime.Today);
            if (data != null)
            {
                data.TotalCount = _totalCounter;
                data.TodayCount = _todayCounter;

                _context.Update(data);
                return;
            }
            var storedData = new VisitorsCounter
            {
                LastDate = _currentDate,
                TodayCount = _todayCounter,
                TotalCount = _totalCounter
            };
            _context.Add(storedData);
            
        }

        /// <summary>
        /// Загрузка данных из бд
        /// </summary>
        public void LoadCounters()
        {
            var storedData = _context.GetAll.FirstOrDefault();
            if (storedData == null) return;
            if (storedData.TodayCount > _todayCounter)
                _todayCounter = storedData.TodayCount + _todayCounter;
            if (storedData.TotalCount > _totalCounter)
                _totalCounter = storedData.TotalCount + _totalCounter;

            _currentDate = storedData.LastDate;


            Console.WriteLine("visitor's counter was been loaded");
        }
    }
}