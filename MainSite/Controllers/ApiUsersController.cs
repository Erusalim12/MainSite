using Application.Services.Birthday;
using Application.Services.Settings;
using Application.Services.Users;
using MainSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MainSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUsersController : ControllerBase
    {
        private readonly IBirthdayService _birthdayService;
        private readonly ISettingsService _settingsService;
        private readonly IUsersService _userService;
        private readonly MainModel _mainMode;

        public ApiUsersController(IBirthdayService birthdayService, ISettingsService settingsService, IUsersService userService, MainModel mainModel)
        {
            _birthdayService = birthdayService;
            _settingsService = settingsService;
            _userService = userService;
            _mainMode = mainModel;
        }

        [Route("GetBirthdayUsers")]
        [HttpGet]
        public string GetBirthdayUsers()
        {
            var model = _birthdayService.GetTodayBirth().ToList();
            if (model.Any())
            {
                return JsonConvert.SerializeObject(model);
            }
            return "[]";
        }
        [Route("InfoCurrentUser")]
        [HttpGet]
        public string GetInfoCurrentUser()
        {
            var infoUser = _userService.GetUserBySystemName(User);

            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            var model = new
            {
                Name = infoUser != null ? infoUser.Name : "Пользователь",
                SystemName = User.Identity.Name,
                IsAdmin = _userService.IsAdmin(infoUser),
                Id = infoUser.Id
            };

            return JsonConvert.SerializeObject(model);
        }

        [Route("IsPermission")]
        [HttpGet]
        public bool IsPermissionForCategory(string categoryId)
        {
            bool result = false;
            if (categoryId != null) result = _mainMode.GetUserPermissionForCategory(categoryId, HttpContext.User);

            return result;
        }
    }
}
