using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleUI.Models;
using Newtonsoft.Json;
using Services;

namespace JooleUI.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public PartialViewResult Login()
        {
            UserLogin temp = new UserLogin();
            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Login(UserLogin temp)
        {
            Service serv = new Service();

            if (ModelState.IsValid)
            {
                if (serv.authentication(temp.Login_Name, temp.User_Password))
                {
                    Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
                    ViewBag.userName = temp.Login_Name;
                    ViewBag.userImgUrl = serv.getUserImgUrl(temp.Login_Name, temp.User_Password);
                    //return RedirectToAction("Summary", "Product");
                    return RedirectToAction("Index", "Search");
                }
                else
                {
                    temp.LoginErrorMessage = "Incrrect username or password.";
                    return View("Login", temp);
                }
            }
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            UserRegister user = new UserRegister();
            return PartialView(user);
        }

        [HttpPost]
        public ActionResult Register(UserRegister user)
        {

            if (ModelState.IsValid)
            {
                Service serv = new Service();
                var imageUrl = "/Images/User/default.png";
                if (user.userImgUrl != null && user.userImgUrl.ContentLength > 0)
                    {
                    var uploadDir = "~/Images/User/";
                    DateTime uploadTime = DateTime.UtcNow;
                    String imageName = uploadTime.ToString("yyyyMMddHHmmssffff") + user.userImgUrl.FileName;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), imageName);
                    imageUrl = Path.Combine(uploadDir, imageName);
                    user.userImgUrl.SaveAs(imagePath);
                }
                serv.createUser(user.userName, user.userEmail, user.userPassword, imageUrl.TrimStart('~'));
                return RedirectToAction("Login");
            }
            else
            {
                user.RegisterErrorMessage = "Please check your information.";
                return PartialView(user);
            }
        }
        //public ActionResult FileUploads(LoginPage temp)
        //{
        //    Service serv = new Service();
        //    var imageUrl = "/Images/User/default.png";

        //    if (temp.RegisterUserImage != null && temp.RegisterUserImage.ContentLength > 0)
        //    {
        //        var uploadDir = "~/Images/User/";
        //        DateTime dateime = DateTime.UtcNow;
        //        string imageName = dateime.ToString("yyyyMMddHHmmssffff") + temp.RegisterUserImage.FileName;

        //        var imagePath = Path.Combine(Server.MapPath(uploadDir), imageName);
        //        imageUrl = Path.Combine(uploadDir, imageName);
        //        temp.RegisterUserImage.SaveAs(imagePath);
        //    }
        //    serv.createUser(temp.RegisterUsername, temp.RegisterEmail, temp.RegisterPassword, imageUrl.TrimStart('~'));
        //    return RedirectToAction("/");
        //}

        public ActionResult LogOut()
        {
            return View("Login");
        }
    }
}