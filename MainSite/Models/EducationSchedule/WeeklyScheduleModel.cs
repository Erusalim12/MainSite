using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MainSite.Models.EducationSchedule
{
    /// <summary>
    /// Отображение плана на неделю
    /// </summary>
    public class WeeklyScheduleModel
    {
        string template = "Расписание учебных занятий {0} курса {1} факультета c {2} по {3} {4} года";

        public string Header =>
            string.Format(template, CourceNum, FacultetNum, DailyList.First().Date.ToString("dd MMMM ", CultureInfo.CurrentCulture),
                DailyList.Last().Date.ToString("dd MMMM ", CultureInfo.CurrentCulture), DailyList.First().Date.Year);

        public WeeklyScheduleModel()
        {
            DailyList = new List<DailyPlan>(6);
        }
        /// <summary>
        /// Факультет
        /// </summary>
        public int FacultetNum { get; set; }
        /// <summary>
        /// Курс
        /// </summary>
        public int CourceNum { get; set; }

        public List<DailyPlan> DailyList { get; set; }

        public class DailyPlan
        {
            public DateTime Date { get; set; }
            /// <summary>
            /// Флаг текущего дня
            /// </summary>
            public bool CurrentDay { get; set; }

            // мы знаем, что пар всегда конкретное количество
            public List<Lesson> lessons { get; set; }

            public class Lesson
            {
                /// <summary>
                /// Номер пары
                /// </summary>
                public int Number { get; set; }
                /// <summary>
                /// Наименование предмета
                /// </summary>
                public string PredmetName { get; set; }

                /// <summary>
                /// Фио преподавателя
                /// </summary>
                public string TeacherFio { get; set; }

                /// <summary>
                /// Аудитория
                /// </summary>
                public string EducationRoom { get; set; }

                /// <summary>
                /// Тип пары (лекция,колоквиум, практика)
                /// </summary>
                public string Type { get; set; }
                /// <summary>
                /// Номер группы
                /// </summary>
                public string GroupNum { get; set; }

                public string Theme { get; set; }
                public string LectionNum { get; set; }
            }
        }



    }
}



