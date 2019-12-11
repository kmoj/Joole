using JooleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Dataentitites;

namespace JooleUI.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter

        Service service = new Service();
        IQueryable<tblProduct> products;
        public ActionResult Search(string searchSrting)
        {
            if (products == null)
            {
                products = service.GetProductBySubCategory(searchSrting);

            }
            List<tblProduct> list = new List<tblProduct>();

            if (products != null)
            {
                foreach (var x in products)
                {
                    list.Add(x);
                }
            }

            return View(list);
        }


        public ActionResult Save(FilterView filterView)
        {

            var dataSet = service.GetTblProductsByFilter(filterView.startYear,
                filterView.endYear, filterView.minAirflow, filterView.maxAirflow,
                filterView.minPower, filterView.maxPower, filterView.minSound, filterView.maxSound, filterView.minFanDiameter,
                filterView.maxFanDiameter);
            List<tblProduct> list = new List<tblProduct>();
            foreach (var x in dataSet)
            {
                list.Add(x);

            }
            return PartialView("SearchResult", list);
        }

        public ActionResult SearchResult(int[] compare)
        {
            TempData["camp"] = compare;

            // return View("Comps",Black(compare));
            return RedirectToAction("Black", "Home");
        }


    }
}