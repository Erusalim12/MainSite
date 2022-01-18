using System;
using System.Collections.Generic;
using System.Linq;
using Application.Dal;
using Application.Dal.Domain.Counters;
using Application.Dal.Repositories.Infrastructure;
using Application.Services.Counters;
using Application.Services.News;
using MainSite.Areas.Admin.Models.Counters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace MainSite.Areas.Admin.Components
{
    public class CounterComponent : ViewComponent
    {
        private readonly IRepository<VisitorsCounter> _counterRepository;

        public CounterComponent(IRepository<VisitorsCounter> counterRepository)
        {
            _counterRepository = counterRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = PrepareCountersData();
            ViewBag.CardName = "Статистика пользователей";
            return View("Counter", model);
        }

        public CounterView PrepareCountersData()
        {

            var data = _counterRepository.GetAll;


            var threeDay = data.Where(c => c.LastDate > DateTime.Now.Date.AddDays(-3));

            var model = new CounterView
            {
                TodayCount = CountersService.TodayUniqueUsers(),
                TotalCount = CountersService.TotalUniqueUsers(),
                PrevDayCount = data.FirstOrDefault(c => c.LastDate > DateTime.Now.Date.AddDays(-1)).TodayCount,
                WeekCount = CurWeekCount(data),
                ThreeDayCount = threeDay.Sum(c => c.TodayCount),
                WeekDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1),
                TodayDate = DateTime.Today,
                ThreeDayDate = DateTime.Today.AddDays(-2),
                PrevWeekCount = PrevWeekCount(data),
                CurrentMonthCount = CurrentMonthCount(data),
                PrevMonthCount = PrevMonthCount(data)

            };


            return model;
        }

        private int CurWeekCount(IEnumerable<VisitorsCounter> dataModel)
        {
            var currData = (int)DateTime.Today.DayOfWeek;
            var currWeekStart = DateTime.Today.AddDays(-currData);
            return dataModel.Where(c => c.LastDate > currWeekStart).Sum(c => c.TodayCount);
        }

        private int PrevWeekCount(IEnumerable<VisitorsCounter> dataModel)
        {
            var currData = (int)DateTime.Today.DayOfWeek;
            var prevWeekstart = DateTime.Today.AddDays(-currData).AddDays(-7);
            var prevWeekEnd = DateTime.Today.AddDays(-currData);
            return dataModel.Where(c => c.LastDate > prevWeekstart && c.LastDate <= prevWeekEnd).Sum(c => c.TodayCount);
        }

        private int CurrentMonthCount(IEnumerable<VisitorsCounter> dataModel)
        {
            var currMonthStart = DateTime.Today.AddDays(-DateTime.Today.Day);
            return dataModel.Where(c => c.LastDate > currMonthStart).Sum(s => s.TodayCount);
        }

        private int PrevMonthCount(IEnumerable<VisitorsCounter> datamodel)
        {
            var prevMonth = DateTime.Today.AddMonths(-1);
            var prevMonthEnd = DateTime.Today.AddDays(-(DateTime.Today.Day));
            var prevmonthFirstDay = prevMonth.AddDays(-prevMonth.Day);//первое число прошлого месяца
            return datamodel.Where(c => c.LastDate > prevmonthFirstDay && c.LastDate <= prevMonthEnd)
                .Sum(c => c.TodayCount);
        }

    }

    public class DailyStaticsComponent : ViewComponent
    {
        private readonly IRepository<VisitorsCounter> _counterRepository;

        public DailyStaticsComponent(IRepository<VisitorsCounter> counterRepository)
        {
            _counterRepository = counterRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CalendarCounterView();
            var data = _counterRepository.GetAll.Where(c => c.LastDate >= DateTime.Today.AddDays(-6).Date);
            var modelData = new List<DailyCounter>();
            int prevconter = 0;
            foreach (var counter in data)
            {
                modelData.Add(PrepareCounter(counter, prevconter));
                prevconter = counter.TodayCount;
            }
            return View("DailyStat", modelData.Distinct().OrderByDescending(c => c.date));
        }

        private DailyCounter PrepareCounter(VisitorsCounter counter, int prev = 0)
        {

            var model = new DailyCounter
            {
                date = counter.LastDate,
                Count = counter.TodayCount,
                ToPrev = counter.TodayCount - prev
            };
            return model;
        }

    }

    //нарастающий счетчик 
    public class NewsGenerationStatisticsComponent : ViewComponent
    {
        private readonly INewsService _newsService;

        public NewsGenerationStatisticsComponent(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IViewComponentResult Invoke()
        {
            var model = PrepareCountersData();
            ViewBag.CardName = "Статистика сообщений";
            return View("/Areas/Admin/Views/Home/Components/CounterComponent/Counter.cshtml", model);
        }

        public CounterView PrepareCountersData()
        {

            var data = _newsService.GetNewsItem(new FilterNewsItemParameters());



            var model = new CounterView
            {
                WeekDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1),
                TodayDate = DateTime.Today,
                ThreeDayDate = DateTime.Today.AddDays(-2),

                TodayCount = _newsService.GetNewsItem(TodayFilter())?.Count() ?? 0,//сегодня
                PrevDayCount = _newsService.GetNewsItem(DayBeforeFilter())?.Count() ?? 0,//вчера

                WeekCount = _newsService.GetNewsItem(CurWeekFilter())?.Count() ?? 0,//тек. неледя
                PrevWeekCount = _newsService.GetNewsItem(PrevWeekFilter())?.Count() ?? 0,//-неделя

                CurrentMonthCount = _newsService.GetNewsItem(CurrentMonthFilter())?.Count() ?? 0,//тек. месяц
                PrevMonthCount = _newsService.GetNewsItem(PrevMonthFilter())?.Count() ?? 0,//-месяц

                TotalCount = _newsService.GetNewsItem(TotalFilter())?.Count() ?? 0,//ИТОГО
            };


            return model;
        }

        private FilterNewsItemParameters TotalFilter()
        {
            return new FilterNewsItemParameters
            {
                StartDate = DateTime.MinValue
            };
        }

        private FilterNewsItemParameters TodayFilter()
        {
            return new FilterNewsItemParameters { StartDate = DateTime.Today.Date };
        }

        private FilterNewsItemParameters DayBeforeFilter()
        {
            return new FilterNewsItemParameters { StartDate = DateTime.Today.AddDays(-1).Date, EndDate = DateTime.Today };
        }
        private FilterNewsItemParameters CurWeekFilter()
        {
            var currData = (int)DateTime.Today.DayOfWeek;
            var currWeekStart = DateTime.Today.AddDays(-currData);
            return new FilterNewsItemParameters
            {
                StartDate = currWeekStart
            };
        }

        private FilterNewsItemParameters PrevWeekFilter()
        {
            var currData = (int)DateTime.Today.DayOfWeek;
            var prevWeekstart = DateTime.Today.AddDays(-currData).AddDays(-7);
            var prevWeekEnd = DateTime.Today.AddDays(-currData);
            return
                new FilterNewsItemParameters
                {
                    StartDate = prevWeekstart,
                    EndDate = prevWeekEnd
                };
        }

        private FilterNewsItemParameters CurrentMonthFilter()
        {
            var currMonthStart = DateTime.Today.AddDays(-DateTime.Today.Day);
            return new FilterNewsItemParameters { StartDate = currMonthStart };
        }

        private FilterNewsItemParameters PrevMonthFilter()
        {
            var prevMonth = DateTime.Today.AddMonths(-1);
            var prevMonthEnd = DateTime.Today.AddDays(-(DateTime.Today.Day));
            var prevmonthFirstDay = prevMonth.AddDays(-prevMonth.Day);//первое число прошлого месяца
            //return datamodel.Where(c => c.LastDate > prevmonthFirstDay && c.LastDate <= prevMonthEnd)
            //    .Sum(c => c.TodayCount);
            return new FilterNewsItemParameters
            {
                StartDate = prevmonthFirstDay,
                EndDate = prevMonthEnd
            };
        }


    }

}
