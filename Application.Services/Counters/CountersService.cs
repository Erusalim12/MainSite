using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dal;
using Application.Dal.Domain.Counters;
using Microsoft.Extensions.Hosting;

namespace Application.Services.Counters
{
    public class CountersService
    {

        private static int _todayCounter { get; set; }
        private static int _totalCounter { get; set; }
        private static DateTime _currentDate { get; set; }
        private readonly IRepository<VisitorsCounter> _context;
        private readonly IHostApplicationLifetime _appLifetime;
        public CountersService(IRepository<VisitorsCounter> context )
        {
            _context = context;
        }
        /// <summary>
        /// Возвращает новый экземпляр модели счетчиков
        /// </summary>
        /// <returns></returns>
        public SimpleCounterModel GetCounter()
        {
            return new SimpleCounterModel(TodayUniqueUsers(), TotalUniqueUsers());
        }
        /// <summary>
        /// возвращает список уникальных посетителей за сегодня
        /// </summary>
        /// <returns></returns>
        private static int TodayUniqueUsers()
        {
            return _todayCounter;
        }

        /// <summary>
        /// возвращает общее количество уникальных поситителей
        /// </summary>
        /// <returns></returns>
        private static int TotalUniqueUsers()
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

            var storedData = _context.GetAll.FirstOrDefault();
            storedData.LastDate = _currentDate;
            storedData.TodayCount = _todayCounter;
            storedData.TotalCount = _totalCounter;

            _context.Update(storedData);
        }

        /// <summary>
        /// Загрузка данных из бд
        /// </summary>
        public void LoadCounters()
        {
            var storedData = _context.GetAll.FirstOrDefault();
            _todayCounter = storedData.TodayCount;
            _totalCounter = storedData.TotalCount;
            _currentDate = storedData.LastDate;

        }
    }
}