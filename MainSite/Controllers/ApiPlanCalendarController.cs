using Application.Dal.Domain.PlanCalendar;
using Application.Services.PlanCalendar;
using MainSite.Areas.Admin.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPlanCalendarController : ControllerBase
    {
        private readonly IPlanCalendarSevice _planCalendarSevice;
        private readonly IPlanCalendarFactory _planCalendarFactory;

        public ApiPlanCalendarController(IPlanCalendarSevice planCalendarSevice, IPlanCalendarFactory planCalendarFactory)
        {
            _planCalendarFactory = planCalendarFactory;
            _planCalendarSevice = planCalendarSevice;
        }

        [Route("getPlanCalendar")]
        [HttpGet]
        public IActionResult GetPlanCalendar()
        {
            var collection = _planCalendarSevice.GetEventsForWeek();
            var collectionFlaw = new List<object>();

            if (collection != null) {
                var nowDate = DateTime.Today;
                var curDay = nowDate.Day;

                int dayOffsetStart = nowDate.DayOfWeek - DayOfWeek.Monday;
                int daysOffsetEnd = DayOfWeek.Saturday - nowDate.DayOfWeek;

                for(var i= curDay - dayOffsetStart; i < curDay + daysOffsetEnd; i++)
                { 
                    var date = nowDate.AddDays(i - curDay);

                    if (!collection.Any(a => int.Parse(a.Day) == date.Day))
                    {
                        collectionFlaw.Add(new  { 
                            Day = date.Day.ToString(),
                            Time = "",
                            Date = date
                        });
                    }
                }

                var res = collection.Select(w => new
                {
                    w.Id,
                    w.Location,
                    w.Time,
                    w.Name,
                    w.Day,
                    Date = DateTime.Parse($"{_planCalendarSevice.GetPlanCalendar(w.PlanCalendarId).Year},{_planCalendarSevice.GetPlanCalendar(w.PlanCalendarId).Month},{w.Day}")
                });

                // Перенести в сервисы
                return new JsonResult(res.Concat(collectionFlaw));
            }

            return new JsonResult(collection);
        }

        [Route("getPlanCalendarByYearAndMonth")]
        [HttpGet]
        public IActionResult GetPlanCalendarByYearAndMonth(int year, int month)
        {
            var collection = _planCalendarSevice.GetEventsByYearAndMonth(year, month);

            if (collection != null)
            {
                return new JsonResult(collection.Select(w => new
                {
                    w.Id,
                    w.Location,
                    w.Time,
                    w.Name,
                    w.Day,
                    w.Leader,
                    Date = DateTime.Parse($"{_planCalendarSevice.GetPlanCalendar(w.PlanCalendarId).Year},{_planCalendarSevice.GetPlanCalendar(w.PlanCalendarId).Month},{w.Day}")
                }));
            }

            return new JsonResult(collection);
        }
    }
}
