using System;
using System.Collections.Generic;
using System.Linq;
using Application.Dal.Rasp;

namespace Application.Services.Schedule
{
    public interface IScheduleService
    {
        Dictionary<DateTime, IEnumerable<Dal.Rasp.Domain.Schedule>> GetScheduleForCursants(int faculetNum, int cource, int addWeek = 0);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly RaspContext _raspContext;


        public ScheduleService(RaspContext raspContext)
        {
            _raspContext = raspContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="faculetNum">Факультет</param>
        /// <param name="cource">Курс</param>
        /// <param name="addWeek">Сдвиг, чтобы посмотреть расписание на другие недели</param>
        public Dictionary<DateTime, IEnumerable<Dal.Rasp.Domain.Schedule>> GetScheduleForCursants(int faculetNum, int cource, int addWeek = 0)
        {
            var currData = DateTime.Today.Date;

            //сдвигаем на столько недель, сколько передано в метод,
            //и в ту сторону, куда указывает знак(отрицательное число двигает в прошлое)
            var selectedWeek = currData.AddDays(addWeek * 7);
            //и находим первый день данной недели
            var firstDayofWeek = selectedWeek.AddDays((double) (0 - (selectedWeek.DayOfWeek-1)));

            //расписание есть только на 6 дней в неделе. всегда.
            var weeklist = new Dictionary<DateTime, IEnumerable<Dal.Rasp.Domain.Schedule>>();
            
            for (int i = 0; i < 6; i++)
            {
                var currResult = GetDailyRasp(firstDayofWeek.AddDays(i).ToShortDateString(), faculetNum, cource);
                weeklist.Add(firstDayofWeek.AddDays(i), currResult.ToList());
            }

            //возвращаем пары ключ-значение, где ключ день недели, а значение - все пары в этот день
            return weeklist;
        }
        /// <summary>
        /// Возвращает расписание на указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <param name="facultet"></param>
        /// <param name="cource"></param>
        /// <returns></returns>
        private IEnumerable<Dal.Rasp.Domain.Schedule> GetDailyRasp(string date, int facultet, int cource)
        {
            //номер группы складывается из записи "факультет+курс+группа" берем первые 2 слагаемых и сравниваем 
            //с началом номеров групп
            var groupident = string.Concat(facultet, cource);

            var query = from schedule in _raspContext?.Schedules
                        join day in _raspContext?.ScheduleDays on schedule.DateId equals day.Id
                        where day.Date == date &&
                            schedule.Group.StartsWith(groupident)  
                              
                        select schedule;

            var rasps = query.ToList();

            return rasps;
        }
        //расписание для преподавателей
        /// <summary>
        /// Возвращает учебное расписание для конкретной кафедры,
        /// </summary>
        /// <param name="cafNum"></param>
        public void GetRaspByCaf(string cafNum)
        {

        }

    }
}
