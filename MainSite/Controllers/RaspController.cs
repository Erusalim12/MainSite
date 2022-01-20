using System;
using System.Collections.Generic;
using Application.Dal.Rasp.Domain;
using Application.Services.Schedule;
using MainSite.Models.EducationSchedule;
using Microsoft.AspNetCore.Mvc;
 

namespace MainSite.Controllers
{
    public class RaspController : Controller
    {
        private readonly IScheduleService _scheduleService;
        public RaspController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: Rasp
        public ActionResult Index()
        {

            return View();
        }
        
        public ActionResult ForCursants(int facultetNum, int courseNum, int addWeeks = 0)
        {
            //получили предметы на указанную неделю
            var weeklyList = _scheduleService.GetScheduleForCursants(facultetNum, courseNum, addWeeks);
            //отобрать предметы для текущего факультета -> курса
            //смаппить в модель
            //отобразить на представлении
            var model = new WeeklyScheduleModel { CourceNum = courseNum, FacultetNum = facultetNum };
            foreach (var day in weeklyList.Keys)//проходим по всем дням недели
            {
                if (weeklyList.TryGetValue(day, out IEnumerable<Schedule> dayList))
                {
                    var predmets = new List<WeeklyScheduleModel.DailyPlan.Lesson>();
                    foreach (var schedule in dayList)
                    {
                        predmets.Add(new WeeklyScheduleModel.DailyPlan.Lesson
                        {
                            Number = schedule.NumLesson,
                            EducationRoom = schedule.SchLocation,
                            GroupNum = schedule.Group,
                            PredmetName =  schedule.NameLesson,
                            TeacherFio =  "Преподаватель не найден",
                            Type = "вид занятия",
                            IsCurrent = IsCurrent(schedule.NumLesson,day),
                            WasNext = IsNext(schedule.NumLesson,day)
                        });
                    }
                    model.DailyList.Add(new WeeklyScheduleModel.DailyPlan
                    {
                        Date = day,
                        CurrentDay = day.Date == DateTime.Today.Date,
                        lessons =  predmets
                    });
                }
            }
            return Json(model);

        }
        /// <summary>
        /// Возвращает значение, является ли пара текущей
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private bool IsCurrent(int num, DateTime date)
        {
            if (date.Date != DateTime.Today.Date) return false;
            return false;

        }
        private bool IsNext(int num, DateTime date)
        {
            return false;
        }

    }
}
