using Application.Dal.Domain.ExternalLinks;
using Application.Services.ExternalLinks;
using Application.Services.Files;
using Application.Services.Permissions;
using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MainSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExternalLinksController : BaseAdminController
    {
        private readonly IExternalLinkService _externalLinkService;
        private readonly IUsersService _userService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _uploadService;

        public ExternalLinksController(IExternalLinkService externalLinkService, IUsersService userService, IPermissionService permissionService, IPictureService uploadService)
        {
            _externalLinkService = externalLinkService;
            _userService = userService;
            _permissionService = permissionService;
            _uploadService = uploadService;
        }

        [Route("Admin/ExternalLinks")]
        public IActionResult Index()
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMenu, user))
                return AccessDeniedView();
#endif

            var items = _externalLinkService.GetAll();

            return View(items);
        }

        [Route("Admin/ExternalLinks/Create")]
        [HttpGet]
        public IActionResult Create(string id)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMenu, user))
                return AccessDeniedView();
#endif
            ExternalLink model = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                model = _externalLinkService.Get(id);
            }

            return View(model);
        }

        [Route("Admin/ExternalLinks/Create")]
        [HttpPost]
        public IActionResult Create([FromForm] ExternalLink model)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMenu, user))
                return AccessDeniedView();
#endif

            if (ModelState.IsValid)
            {
                var fileForm = Request.Form.Files.Any() ? Request.Form.Files[0] : null;

                if (fileForm != null)
                {
                    var file = _uploadService.InsertPicture(fileForm);
                    _uploadService.GetPictureUrl(file.Id);

                    model.PathIcon = _uploadService.GetPictureUrl(file.Id);
                }

                var entity = model.Id != null ? _externalLinkService.Get(model.Id) : null; 

                if(entity != null)
                {
                    entity.Name = model.Name;
                    entity.Url = model.Url;

                    if (!String.IsNullOrWhiteSpace(model.PathIcon)) entity.PathIcon = model.PathIcon;

                    _externalLinkService.UpdateItem(entity);
                }
                else
                {
                    _externalLinkService.InsertItem(model);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        [Route("Admin/ExternalLinks/Delete")]
        public IActionResult Delete(string id)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageMenu, user))
                return AccessDeniedView();
#endif
            var item = _externalLinkService.Get(id);
            if (item != null)
            {
                _externalLinkService.DeleteItem(item);
            }

            return RedirectToAction("Index");
        }
    }
}
