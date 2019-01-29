using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;
using Tekstowo.WebUI.Models;

namespace Tekstowo.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository;

        // GET: UserRegistration

        public UserController(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public ViewResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Registration(User user)
        {
            if (user.UserPassword != user.UserType)
            {
                TempData["warrning"] = "Błędne hasło";
                return View();
            }
            else
            {
                UserListViewModels tempUser = new UserListViewModels { Users = UserRepository.Users.Where(u => u.UserNickname == user.UserNickname) };
                if (tempUser.Users.Count() != 0)
                {

                    TempData["warrning"] = "Podany użytkownik już istnieje";
                    return View();
                }
                else
                {
                    user.UserType = "Normal";
                    UserRepository.RegisterUser(user);
                    TempData["message"] = user.UserNickname + " " + user.UserPassword + " " + user.UserType;
                    return View();
                }
            }
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.UserNickname == null || user.UserPassword == null)
            {
                TempData["warrning"] = "Nieprawidłowy login lub hasło";
                return View();
            }

            UserListViewModels tempUser =new UserListViewModels { Users=UserRepository.Users.Where(u => u.UserNickname == user.UserNickname) };
            if(tempUser.Users.Count()!=1)
            {
                TempData["warrning"] = "Nieprawidłowy login";
                return View();
            }
            if (tempUser.Users.First().UserPassword != user.UserPassword)
            {
                TempData["warrning"] = "Nieprawidłowe hasło";
                return View();
            }
            TempData["message"] = "Zalogowano";
            Session["UserNickname"] = tempUser.Users.First().UserNickname;
            Session["UserType"] = tempUser.Users.First().UserType;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (Session["UserNickname"] != null)
            {
                Session["UserNickname"] = null;
                Session["UserType"] = null;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "User");
        }
    }
}