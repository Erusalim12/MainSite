﻿using System;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MainSite.Models;
using MainSite.ViewModels.News;
using Newtonsoft.Json;
using System.Linq;
using Application.Dal;
using Application.Dal.Domain.Counters;
using Application.Dal.Domain.Menu;
using Application.Services.Menu;
using Application.Services.Files;
using Application.Services.Permissions;
using MainSite.Areas.Admin.Factories;
using MainSite.ViewModels.UI.Menu;
using Application.Services.Users;
using Application.Services.Utils;
using MainSite.Filters;

namespace MainSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly MainModel _mainMode;
        private readonly IMenuService _menuService;
        private readonly IPictureService _pictureService;
        private readonly IPermissionService _permissionService;
        private readonly ISecurityModelFactory _securityModelFactory;
 
        private readonly IUsersService _userService;


        public HomeController(MainModel mainMode, IUsersService userService, IMenuService menuService, IPictureService uploadService, IPermissionService permissionService, ISecurityModelFactory securityModelFactory)
        {
            _mainMode = mainMode;
            _menuService = menuService;
            _pictureService = uploadService;
            _permissionService = permissionService;
            _securityModelFactory = securityModelFactory;
            _userService = userService;
        }


        public IActionResult Index(int page = 0, string category = null)
        {
            _userService.GetUserBySystemName(User);
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] NewsItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UploadedFiles = Request.Form.Files.ToList();
                //if (model.IsAdvancedEditor)
                //{
                //    _mainMode.InsertAdvancedNewsItem(model);
                //}

                _mainMode.CreateNewNewsItem(model, User);
            }

            var entity = _mainMode.GetNewsItemViewModel(model.Id);
            return new JsonResult(entity);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] NewsItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UploadedFiles = Request.Form.Files.ToList();
                //if (model.IsAdvancedEditor)
                //{
                //    _mainMode.InsertAdvancedNewsItem(model);
                //}

                _mainMode.EditNewNewsItem(model, User);

                return new JsonResult(_mainMode.GetNewsItemViewModel(model.Id));
            }

            return new JsonResult(null);
        }

        [HttpGet]
        [Route("GetFile")]
        public IActionResult DownloadFile(string fileId)
        {
            return _mainMode.GetDownloadFile(fileId);
        }


        // POST: MenuService/Create
        [HttpPost]
        public IActionResult CreateCategory(MenuItem model)
        {
            if (ModelState.IsValid)
            {
                var fileForm = Request.Form.Files.Any() ? Request.Form.Files[0] : null;
                if (fileForm != null)
                {

                    var file = _pictureService.InsertPicture(fileForm);
                 
                    _pictureService.GetPictureUrl(file.Id);

                    model.UrlIcone = _pictureService.GetPictureUrl(file.Id);
                }
                model.ActionName = new TranslitMethods.Translitter().Translit(model.Name, TranslitMethods.TranslitType.Gost)
                  .Replace(' ', '_');
                _menuService.InsertItem(model);
                _permissionService.InsertPermissionRecord(_securityModelFactory.CreatePermissionRecordForMenu(model));

                var itemViewModel = new MenuItemViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ToolTip = model.ToolTip,
                    UrlIcon = model.UrlIcone,
                    ParentId = model.ParentId,
                    Index = model.Index

                };

                return Json(JsonConvert.SerializeObject(itemViewModel));
            }
            return Json(null);
        }

        /// <summary>
        /// Delete news item
        /// </summary>
        /// <param name="id">News item identifier</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return Error();
            var item = _mainMode.GetNewsItemViewModel(id);
            if (item == null) new JsonResult(null);

            try
            {
                _mainMode.DeleteNewsItem(id);
                return new JsonResult("Успешно");
            }
            catch(System.Exception ex)
            {

            }

            return new JsonResult(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult PinNews(string newsItemId, string currentCategoryId = null, int currentPage = 0)
        {
            _mainMode.PinNewsItem(newsItemId);
            return RedirectToAction("Index", new { page = currentPage, category = currentCategoryId });
        }

        [HttpPost]
        public IActionResult UnpinNews(string newsItemId, string currentCategoryId = null, int currentPage = 0)
        {
            _mainMode.UnpinNewsItem(newsItemId);
            return RedirectToAction("Index", new { page = currentPage, category = currentCategoryId });
        }
    }
}