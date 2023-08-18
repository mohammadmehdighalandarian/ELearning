using DataLayer.Entities.User;
using LearningWeb_Core.Convertors;
using LearningWeb_Core.DTOs.Account;
using LearningWeb_Core.Generator;
using LearningWeb_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningSite.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(register);
            //}

            if (_userServices.IsEmailExist(FixingObject.FixingEmail(register.Email)))
            {
                ModelState.AddModelError("Email","ایمیل معتبر نمی باشد");
                return View(register);
            }

            if (_userServices.IsUserNameExist(register.userName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(register);
            }

            User user = new User()
            {
                UserName = register.userName,
                Email = FixingObject.FixingEmail(register.Email),
                ActivateCode = ActivationCode.GenerateActivationCode(),
                IsActive = false,
                Password = register.Password,
                RegisterDate = DateTime.Now,
                UserAvatar = "Defualt.png",
            };

            _userServices.AddUser(user);

            return View("SuccesRegister",user);
        }

        #endregion

        #region Login

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        #endregion


    }
}
