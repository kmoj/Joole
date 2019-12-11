using Dataentitites;
using JooleUI.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

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

        public ActionResult SetUserInfoSearchBar()
        {
            Service serv = new Service();
            List<Category> categories = new List<Category>();
            foreach (var tempCatego in serv.getCategories())
            {

                Category tempObj = new Category();
                tempObj.Category_ID = tempCatego.Category_ID;
                tempObj.Category_Name = tempCatego.Category_Name;
                categories.Add(tempObj);

            }
            ViewBag.Category = categories;
            ViewBag.userName = Session["userName"];
            ViewBag.userImgUrl = Session["userImgUrl"];
            return PartialView("_NavPartial3", categories);
        }

        public ActionResult NavBarSearchAction(int category, string productName)
        {
            Service serv = new Service();
            List<tblProduct> products = serv.GetProductByNameCateId(productName, category).ToList();
            Session["searchString"] = productName;
            return View("~/Views/Filter/Search.cshtml", products);
        }
    }
}