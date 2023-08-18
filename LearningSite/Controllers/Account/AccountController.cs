﻿using DataLayer.Entities.User;
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
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
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

            return View("SuccesRegister", user);
        }

        #endregion

        #region Login

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel NewUser)
        {
            if (!ModelState.IsValid)
            {
                return View(NewUser);
            }

            var User = _userServices.loginUser(NewUser);

            ViewBag.IsSuccess = "False";
            if (User != null)
            {
                if (User.Password.Equals(NewUser.Password))
                {
                    if (User.IsActive)
                    {
                        ViewBag.IsSuccess = "True";
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "کاربر فعال نمی باشد";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "نام کاربری با رمز عبور تطابق ندارد";
                    return View();
                }

            }
            ViewBag.ErrorMessage = "کاربر یافت نشد";
            return View();
        }

        #endregion


    }
}
