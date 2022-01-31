using System; 
using System.Globalization;
using System.Linq; 
using Application.Services.Schedule; 
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

        public ActionResult ForCursants(int facultetNum, int courseNum, int addWeeks = 0)
        {
            //получили предметы на указанную неделю
            var weeklyList = _scheduleService.GetScheduleForCursants(facultetNum, courseNum, addWeeks);
            var model = new
            {
                CourceNum = courseNum,
                FacultetNum = facultetNum,
                Header = FormatHeader(facultetNum, courseNum, weeklyList.Keys.First(), weeklyList.Keys.Last()),

                day = weeklyList.Select(daily => new
                {
                    date = daily.Key,
                    CurrentDay = daily.Key == DateTime.Today.Date,


                    //Проходим по всем урокам в дне, не учитывая учебные группы
                    lessons = daily.Value.Select(predmet => new   //проходит по всем группам, 
                    {
                        lessonNumber = predmet.NumLesson,
                        number = predmet.NumLesson,
                        predmetName = predmet.NameLesson,
                        teacherFio = predmet.TeacherFio?? "teacher!",
                        educationRoom = predmet.SchLocation,
                        type = predmet.Type??"!",
                        theme = predmet.Theme??"0",
                        lectionNum = predmet.LectionNum??"0"
                        
                    })
                        .GroupBy(d => d.lessonNumber)//находим уникальные (без учета групп)
                        .Select(s => new
                        { //формируем новый тип, в котором будут учтены все необхоимые поля, в т.ч. группы
                            lessonNumber = s.Key,
                            time = FormatEducationTime(s.Key),
                            predmets = s.Select(s1 => new
                            {
                                predmetName = s1.predmetName,
                                teacherFio = s1.teacherFio ,
                                educationRoom = s1.educationRoom,
                                type = s1.type ,
                                theme = s1.theme,
                                lectionNum = s1.lectionNum
                            }).Distinct().Select(s2 => new
                            { //формируем новый тип, в котором будут учтены все необхоимые поля, в т.ч. группы
                                predmetName = s2.predmetName,
                                teacherFio = s2.teacherFio,
                                educationRoom = s2.educationRoom,
                                type = s2.type,
                                theme = s2.theme,
                                lectionNum = s2.lectionNum,
                                groups = daily.Value.Where(c => c.SchLocation == s2.educationRoom && c.NumLesson == s.Key).Select(s => s.Group).Distinct()
                            })

                        })
                })
            };
            return Json(model);
        }

        [NonAction]
        private string FormatEducationTime(int number)
        {
            string tempate = "{0}-я пара занятий ({1})";
            if (number == 1)
                return string.Format(tempate, number, "9:00-10:30");
            if (number == 2)
                return string.Format(tempate, number, "10:45-12:15");
            if (number == 3)
                return string.Format(tempate, number, "12:30-14:00");

            return string.Format(tempate, number, "");
        }

        [NonAction]
        private string FormatHeader(int facultetNum, int courceNum, DateTime startDate, DateTime endDate)
        {
            string template = "Расписание учебных занятий {0} курса {1} факультета c {2} по {3} {4} года";

            return string.Format(template, courceNum, facultetNum,
                   startDate.ToString("dd MMMM ", CultureInfo.CurrentCulture),
                   endDate.ToString("dd MMMM ", CultureInfo.CurrentCulture), startDate.Year);
        }
    }
}
