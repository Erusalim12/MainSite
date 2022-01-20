 
using Application.Dal.Rasp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Dal.Rasp
{
    public class RaspContext : DbContext
    {
        public RaspContext(DbContextOptions<RaspContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleDay> ScheduleDays { get; set; }
    }
}
