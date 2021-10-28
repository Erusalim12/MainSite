using Application.Dal.Domain.PlanCalendar;
using Application.Services.PlanCalendar;
using MainSite.Areas.Admin.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            if (collection != null) {
                var nowDate = DateTime.Now;
                var curDay = nowDate.Day;

                int dayOffsetStart = nowDate.DayOfWeek - DayOfWeek.Monday;
                int daysOffsetEnd = DayOfWeek.Saturday - nowDate.DayOfWeek;

                for(var i= curDay - dayOffsetStart; i < curDay + daysOffsetEnd; i++)
                {
                    
                    if (i >=  curDay)
                    {
                        var date = nowDate.AddDays(i - curDay);
                        if (date.Month != nowDate.Month) break;
                    }

                    if (!collection.Any(a => int.Parse(a.Day) == i ))
                    {
                        collection.Append(new EventCalendar { 
                            Day = i.ToString(),
                            Time = ""
                        });
                    }
                }

                var res = collection
                    .ToLookup(z => z.Day)
                    .OrderBy(w => int.Parse(w.Key))
                    .Select(a => new { Day = a.Key, Events = a.Where(s => !String.IsNullOrWhiteSpace(s.Time)).ToList() });


                return new JsonResult(res);
            }

            return new JsonResult(collection);
        }
    }
}
