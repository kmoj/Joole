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
        /* 
         * This method will be called by the page when the user load the page at first. 
         */
        [HttpGet]
        public PartialViewResult Login()
        {
            UserLogin temp = new UserLogin();
            return PartialView(temp);
        }

        /*
         *
         * This method will retrive the login information from user and check if the login is accurate
         */
        [HttpPost]
        public ActionResult Login(UserLogin temp)
        {
            Service serv = new Service();

            if (ModelState.IsValid)
            {
                    if (serv.authentication(temp.Login_Name, temp.User_Password))
                    {
                        Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
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

        public PartialViewResult Register()
        {
            return PartialView();
        }

        public JsonResult CreateUserRequest(string uname, string uemail, string upass)
        {
            string c = Server.MapPath("Images");
            var file = Request.Files;
            //string path = Path.Combine(Server.MapPath("~/Images/Users"), Path.GetFileName(file.FileName));
            Service serv = new Service();
            serv.createUser(uname, uemail, upass);

            var chak = JsonConvert.SerializeObject("OK");

            return Json(chak, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FileUploads(string qqfile)
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase uploadFile = Request.Files[file] as HttpPostedFileBase;
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    uploadFile.SaveAs(path);
                }
            }
            return RedirectToAction("User");
        }
    }
}