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
        /*
         * 
         * This method will be called by the page when the user load the page at first. 
         */
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View(new LoginPage());
        }

        /*
         *
         * This method will retrive the login information from user and check if the login is accurate
         */
        [HttpPost]
        public ActionResult LoginPage(LoginPage temp)
        {
            Service serv = new Service();
                    if (serv.authentication(temp.Login_Name, temp.User_Password))
                    {
                        Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
                    //return RedirectToAction("Summary", "Product");
                    return RedirectToAction("Index", "Search");
                }
                    else
                    {
                        temp.LoginErrorMessage = "Incrrect username or password.";
                        return View("LoginPage", temp);
                    }
         
            return View();
        }

        //public JsonResult CreateUserRequest(string uname, string uemail, string upass)
        //{
        //    string c = Server.MapPath("Images");
        //    var file = Request.Files;
        //    //string path = Path.Combine(Server.MapPath("~/Images/Users"), Path.GetFileName(file.FileName));
        //    Service serv = new Service();
        //    serv.createUser(uname, uemail, upass);

        //    var chak = JsonConvert.SerializeObject("OK");

        //    return Json(chak, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult FileUploads(LoginPage temp)
        {
            Service serv = new Service();
            var imageUrl = "/Images/User/default.png";

            if (temp.RegisterUserImage != null && temp.RegisterUserImage.ContentLength > 0)
            {
                var uploadDir = "~/Images/User/";
                DateTime dateime = DateTime.UtcNow;
                string imageName = dateime.ToString("yyyyMMddHHmmssffff") + temp.RegisterUserImage.FileName;
                
                var imagePath = Path.Combine(Server.MapPath(uploadDir), imageName);
                imageUrl = Path.Combine(uploadDir, imageName);
                temp.RegisterUserImage.SaveAs(imagePath);
            }
            serv.createUser(temp.RegisterUsername, temp.RegisterEmail, temp.RegisterPassword, imageUrl.TrimStart('~'));
            return RedirectToAction("/");
        }
    }
}