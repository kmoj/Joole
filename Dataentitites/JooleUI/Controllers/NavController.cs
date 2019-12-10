using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult SetUserInfo()
        {
            ViewBag.userName = Session["userName"];
            ViewBag.userImgUrl = Session["userImgUrl"];
            return PartialView("_NavPartial2");
        }
    }
}