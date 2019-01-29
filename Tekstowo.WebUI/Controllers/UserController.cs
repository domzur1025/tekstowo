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
            if(user.UserPassword!=user.UserType)
            {

                TempData["warrning"] = "Błędne hasło";
                return View();
            }
            else
            {
                

                UserListViewModels tempUser = new UserListViewModels { Users=UserRepository.Users.Where(u=>u.UserNickname==user.UserNickname) } ;
                

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
    }
}