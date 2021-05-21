﻿using MainSite.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MainSite.Areas.Admin.Factories
{
    public interface IPlanCalendarFactory
    {
        List<PlanCalendarModel> Start(IFormFile file);
        Application.Dal.Domain.PlanCalendar.PlanCalendar GetEntity(PlanCalendarModel planCalendarModel);
    }
}
