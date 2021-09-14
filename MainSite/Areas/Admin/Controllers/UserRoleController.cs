﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.Dal.Domain.Users;
using Application.Services.Permissions;
using Application.Services.Users;
using Application.Services.Utils;
using MainSite.Areas.Admin.Factories;
using MainSite.Areas.Admin.Models.Users;
using MainSite.Filters;

namespace MainSite.Areas.Admin.Controllers
{

    public class UserRoleController : BaseAdminController
    {
        #region fields

        private readonly IPermissionService _permissionService;
        private readonly IUsersService _userService;
        private readonly IUserRoleModelFactory _userRoleModelFactory;
        #endregion

        #region CTOR

        public UserRoleController(IPermissionService permissionService, IUsersService userService, IUserRoleModelFactory userRoleModelFactory)
        {
            _permissionService = permissionService;
            _userService = userService;
            _userRoleModelFactory = userRoleModelFactory;
        }
        #endregion

        [Route("Admin/UserRoles/Index")]
        [HttpGet]
        public virtual IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }
        [Route("Admin/UserRoles/List")]
        [HttpGet]
        public virtual IActionResult List()
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user))
                return AccessDeniedView();
#endif


            //prepare model
            var roles = _userService.GetAllUserRoles(true);
            var model = roles.Select(role => _userRoleModelFactory.PrepareUserRoleModel(new UserRoleModel(), role));
            return View("List", model);
        }



        [Route("Admin/UserRoles/Create")]
        [HttpGet]
        public virtual IActionResult Create()
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user)
                || !_permissionService.Authorize(StandardPermissionProvider.ManageAcl, user))
                return AccessDeniedView();
#endif
            //prepare model
            var model = _userRoleModelFactory.PrepareUserRoleModel(new UserRoleModel(), null);

            return View(model);
        }
        [Route("Admin/UserRoles/Create")]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Create(UserRoleModel model)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user)
                || !_permissionService.Authorize(StandardPermissionProvider.ManageAcl, user))
                return AccessDeniedView();
#endif


            if (ModelState.IsValid)
            {
                var UserRole = new UserRole
                {
                    Name = model.Name,
                    Id = model.Id,
                    Active = true,
                    IsSystemRole = model.IsSystemRole,
                    SystemName = new TranslitMethods.Translitter().Translit(model.Name, TranslitMethods.TranslitType.Gost)
                };
                _userService.InsertUserRole(UserRole);


                //_notificationService.SuccessNotification(_localizationService.GetResource("Admin.Users.UserRoles.Added"));

                return RedirectToAction("List");
            }

            //prepare model
            model = _userRoleModelFactory.PrepareUserRoleModel(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }
      
        [Route("Admin/UserRoles/Edit")]
        [HttpGet]
        public virtual IActionResult Edit(string id)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user)
                || !_permissionService.Authorize(StandardPermissionProvider.ManageAcl, user))
                return AccessDeniedView();
#endif
            //try to get a customer role with the specified id
            var UserRole = _userService.GetUserRoleById(id);
            if (UserRole == null)
                return RedirectToAction("List");

            //prepare model
            var model = _userRoleModelFactory.PrepareUserRoleModel(null, UserRole);

            return View(model);
        }
      
        [Route("Admin/UserRoles/Edit")]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Edit(UserRoleModel model, bool continueEditing)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user)
                || !_permissionService.Authorize(StandardPermissionProvider.ManageAcl, user))
                return AccessDeniedView();
#endif


            //try to get a customer role with the specified id
            var UserRole = _userService.GetUserRoleById(model.Id);
            if (UserRole == null)
                return RedirectToAction("List");

            try
            {
                if (ModelState.IsValid)
                {
                    if (UserRole.IsSystemRole && !model.Active)
                        throw new Exception("CantEditSystem");
                    var roleTranslit =
                        new TranslitMethods.Translitter().Translit(model.Name, TranslitMethods.TranslitType.Gost);
                    if (UserRole.IsSystemRole && !UserRole.SystemName.Equals(roleTranslit, StringComparison.InvariantCultureIgnoreCase))
                        throw new Exception("CantEditSystem");


                    //change all parameters available from the view
                    UserRole.Active = model.Active;
                    UserRole.Name = model.Name;
                    UserRole.SystemName = roleTranslit;

                    _userService.UpdateUserRole(UserRole);

                    //activity log
                    //_customerActivityService.InsertActivity("EditUserRole",
                    //    string.Format(_localizationService.GetResource("ActivityLog.EditUserRole"), UserRole.Name), UserRole);

                    //_notificationService.SuccessNotification(_localizationService.GetResource("Admin.Users.UserRoles.Updated"));

                    return continueEditing ? RedirectToAction("Edit", new { id = UserRole.Id }) : RedirectToAction("List");
                }

                //prepare model
                model = _userRoleModelFactory.PrepareUserRoleModel(model, UserRole);

                //if we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception)
            {
                //   _notificationService.ErrorNotification(exc);
                return RedirectToAction("Edit", new { id = UserRole.Id });
            }
        }

        [HttpPost]
        [Route("Admin/UserRoles/Delete")]
        public virtual IActionResult Delete(string id)
        {
#if RELEASE
            var user = _userService.GetUserBySystemName(User);
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers, user)
                || !_permissionService.Authorize(StandardPermissionProvider.ManageAcl, user))
                return AccessDeniedView();
#endif


            //try to get a customer role with the specified id
            var UserRole = _userService.GetUserRoleById(id);
            if (UserRole == null)
                return RedirectToAction("List");

            try
            {
                _userService.DeleteUserRole(UserRole);


                //_notificationService.SuccessNotification(_localizationService.GetResource("Admin.Users.UserRoles.Deleted"));

                return RedirectToAction("List");
            }
            catch (Exception)
            {
                // _notificationService.ErrorNotification(exc.Message);
                return RedirectToAction("Edit", new { id = UserRole.Id });
            }
        }
    }
}

