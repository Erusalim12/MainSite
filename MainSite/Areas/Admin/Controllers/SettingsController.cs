﻿using Application.Dal.Domain.Settings;
using Application.Services.Permissions;
using Application.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MainSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : BaseAdminController
    {
        private readonly ISettingsService _settingsService;
        private readonly FirstConfigService _configDbService;
        private readonly IPermissionService _permissionService;

        public SettingsController(ISettingsService settingsService, IPermissionService permissionService, FirstConfigService configDbService)
        {
            _settingsService = settingsService;
            _permissionService = permissionService;
            _configDbService = configDbService;
        }

        // GET: SettingsController
        [HttpGet]
        public ActionResult Index()
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif


            var settings = _settingsService.GetAllSettings();
            return View(settings);
        }

        [HttpGet]
        public ActionResult Create()
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif

            return View();
        }

        // POST: SettingsController/Create
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Setting setting)
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif
            if (ModelState.IsValid)
            {
                _settingsService.SetParameter(setting);
                return RedirectToAction(nameof(Index));
            }
            return View(setting);

        }
        [HttpGet]
        public IActionResult Update(string id)
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif
            return View(_settingsService.GetSettingById(id));
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif
            var entity = _settingsService.GetSettingById(setting.Id);
            if (entity == null) ModelState.AddModelError("", "Запись не найдена");
            if (ModelState.IsValid)
            {
                entity.Value = setting.Value;
                _settingsService.SetParameter(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(setting);
        }

        [HttpGet]
        public IActionResult CreateIndex()
        {
            _configDbService.CreateIndex();

            return RedirectToAction("Index");
        }

        // GET: SettingsController/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
#if RELEASE
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageSettings, User))
                return AccessDeniedView();
#endif
            _settingsService.DeleteSetting(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Admin/GetSettings")]
        public string GetSettings()
        {
            var model = _settingsService.GetAllSettings();

            return JsonConvert.SerializeObject(model);
        }

    }
}
