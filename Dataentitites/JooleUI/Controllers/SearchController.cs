using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleUI.Models;
using Newtonsoft.Json;
using Services;

namespace JooleUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: CategoryAndSub
        [HttpGet]
        public ActionResult Index(int? value)
        {
            List<Category> listObj = new List<Category>();
            foreach (var tempCatego in new Services.Service().getCategories())
            {

                Category tempObj = new Category();
                tempObj.Category_ID = tempCatego.Category_ID;
                tempObj.Category_Name = tempCatego.Category_Name;
                listObj.Add(tempObj);

            }
            ViewBag.Category = new SelectList(listObj, "Category_ID", "Category_Name");


            if (value != null)
            {
                SubCategory tempSubCategory = new SubCategory();

                List<string> subCategoList = new List<string>();
                int val = (int)value;
                foreach (var temp in new Services.Service().GetSubCategories(val))
                {
                    subCategoList.Add(temp.SubCategory_Name);
                }
                tempSubCategory.SubCategory_Name = subCategoList;
                ViewBag.subCategory = new SelectList(subCategoList);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string term, string Category)
        {
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("Summary", "Product",new { searchString = term });

            }
            else
            {
                return RedirectToAction("Summary", "Product", new { searchString = term });
            }
        }


        public JsonResult GetSubcategory(string term,string Category)
        {
            List<string> filteredItems = new List<string>();
            Service serv = new Service();
            if (Category == "")
            {

                var cha1k = JsonConvert.SerializeObject(filteredItems);

                return Json(cha1k, JsonRequestBehavior.AllowGet);
            }
            foreach (var temp in serv.GetSubCategories(Int32.Parse(Category)))
            {
                filteredItems.Add(temp.SubCategory_Name);
            }
            filteredItems.Contains(term);
            List<string> filt = new List<string>();
            
            foreach(var vals in filteredItems)
            {
                string normal = vals.ToLower();
                if (normal.Contains(term.ToLower()))
                {
                    filt.Add(vals);
                }
            } 

            var chak = JsonConvert.SerializeObject(filteredItems);

            return Json(chak, JsonRequestBehavior.AllowGet);
        }
    }
}