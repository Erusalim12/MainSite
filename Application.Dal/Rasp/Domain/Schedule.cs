using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dal.Rasp.Domain
{
    [Table("Schedule_t")]
    public class Schedule
    {
        [Column("Schedule_tId")]
        public int Id { get; private set; }
        public int DateId { get; private set; }

        [Column("Data_from_serv")]
        public string Data { get; private set; }
        public int NumLesson { get; private set; }
        public string Group { get; private set; }
        public string SchLocation { get; private set; }
        public string NameLesson { get; private set; }
        public string CorpusNum { get; private set; }
        public int ClothesId { get; private set; }
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
