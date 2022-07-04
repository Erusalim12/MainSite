using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dal.Rasp.Domain
{
    /// <summary>
    /// Учебная пара
    /// </summary>
    [Table("Schedule_t")]
    public class Schedule
    {
        [Column("Schedule_tId")]
        public int Id { get; private set; }
        public int DateId { get; private set; }
 
        /// <summary>
        /// Номер урока в дне
        /// </summary>
        public int NumLesson { get; private set; }
        public string Group { get; private set; }
        public string SchLocation { get; private set; }
        public string NameLesson { get; private set; }

        /// <summary>
        /// ФИО преподавателя
        /// </summary>
#warning УБЕРИ АТРИБУТ ПОСЛЕ ДОБАВЛЕНИЯ ПОЛЕЙ В БД!
        [NotMapped]
        public string TeacherFio { get; set; }
        /// <summary>
        /// Вид занятия (лекция, практика, семинар)
        /// </summary>
#warning УБЕРИ АТРИБУТ ПОСЛЕ ДОБАВЛЕНИЯ ПОЛЕЙ В БД!
        [NotMapped]
        public string Type { get; set; }

        /// <summary>
        /// Тема лекции
        /// </summary>
#warning УБЕРИ АТРИБУТ ПОСЛЕ ДОБАВЛЕНИЯ ПОЛЕЙ В БД!
        [NotMapped]
        public string Theme { get; set; }
        /// <summary>
        /// Номер лекции
        /// </summary>
#warning УБЕРИ АТРИБУТ ПОСЛЕ ДОБАВЛЕНИЯ ПОЛЕЙ В БД!
        [NotMapped]
        
        public string LectionNum { get; set; }

    }

    [Table("Schedule_day_t")]
    public class ScheduleDay
    {
        [Column("Schedule_dayId")]
        public int Id { get; private set; }
        public string Date { get; private set; }
        public int MonthId { get; private set; }
    }
}
