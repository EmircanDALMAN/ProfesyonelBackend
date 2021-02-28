using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
using Shared.CrossCuttingConcerns.Security.WebUI;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string userName, string password)
        {
            var result = _userService.GetByUserNameAndPassword(userName, password);
            var user = result.Data;
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Data.Select(u=>u.RoleName).ToArray(),
                    false,
                    user.FirstName,
                    user.LastName);
                return "User is authenticated!";
            }

            return result.Message;
        }
    }
}