using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using JooleUI.Models;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace JooleUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Summa()
        {
            return View();
        }

        public JsonResult Summ()
        {
            Service serv = new Service();
            List<Products> va = new List<Products>();
            for (int i = 1; i < 2; i++)
            {
                Products val = new Products();
                var a = serv.value(i);
                val.Product_Name = a.Product_Name;
                val.Model = a.Model;
                val.Series = a.Series;
                val.Product_Image = a.Product_Image;
                //JObject json = JObject.Parse(a.Characteristics);
                val.Object = a.Characteristics;
                //Response.Write(val.Object);
                var b = serv.manudetails(a.Manufacturer_ID);
                val.Manufacturer_Name = b.Manufacturer_Name;
                var c = serv.typedetails(a.ProductTypeID);
                val.UseType = c.UseType;
                val.Application = c.Application;
                val.ModelYear = c.ModelYear;
                val.MountingLocation = c.MountingLocation;
                va.Add(val);
            }
            var cha = JsonConvert.SerializeObject(va);
            return Json(cha, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Summary(string searchString, int? productType, string beginningYear, string endingYear, int[] compare)
        {
            Service serv = new Service();
            string vals = "";

            ViewBag.Message = vals;

            List <ProductVM> productList = new List<ProductVM>();
            var de = serv.GetDataSet(null).AsEnumerable();
            List<int> typeList = new List<int>();

            var tde = serv.GetTypeDataSet(null).AsEnumerable();
            if (compare != null && compare.Length > 0)
            {
                //var outs = JsonConvert.SerializeObject(Black(compare));
                //return Json(outs, JsonRequestBehavior.AllowGet);
                TempData["camp"] = compare;

               // return View("Comps",Black(compare));
               return RedirectToAction("Black","Home");
            }
            foreach (var product in de)
            {
                typeList.Add(product.ProductTypeID);
            }

            ViewBag.ProductTypes = new SelectList(typeList);


            if (!String.IsNullOrEmpty(searchString))
            {
                de = de.Where(product => product.Product_Name.Contains(searchString));
                //de = serv.GetDataSet(searchString);
            }

            if (productType > 0)
            {
                //System.Diagnostics.Debug.WriteLine(productType);
                de = from p in de
                     where p.ProductTypeID == productType
                     select p;
            }


            if (!String.IsNullOrEmpty(beginningYear) && !String.IsNullOrEmpty(endingYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) >= Convert.ToInt32(beginningYear)
                     && Convert.ToInt32(t.ModelYear) <= Convert.ToInt32(endingYear)
                     select p;
            }

            else if (!String.IsNullOrEmpty(beginningYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) >= Convert.ToInt32(beginningYear)
                     select p;
            }

            else if (!String.IsNullOrEmpty(endingYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) <= Convert.ToInt32(endingYear)
                     select p;
            }

            foreach (var product in de)
            {
                productList.Add(new ProductVM(product.Product_ID, product.Manufacturer_ID, product.SubCategory_ID,
                    product.Product_Name, product.Series, product.Model, product.ProductTypeID, product.Characteristics));
            }
            return View(productList);
        }

        public List<Products> Black(int[] comp)
        {
            Service serv = new Service();
            List<Products> va = new List<Products>();
            for (int i = 1; i < comp.Length; i++)
            {
                Products val = new Products();
                var a = serv.value(comp[i]);
                val.Product_Name = a.Product_Name;
                val.Model = a.Model;
                val.Series = a.Series;
                val.Product_Image = a.Product_Image;
                //JObject json = JObject.Parse(a.Characteristics);
                val.Object = a.Characteristics;
                //Response.Write(val.Object);
                var b = serv.manudetails(a.Manufacturer_ID);
                val.Manufacturer_Name = b.Manufacturer_Name;
                var c = serv.typedetails(a.ProductTypeID);
                val.UseType = c.UseType;
                val.Application = c.Application;
                val.ModelYear = c.ModelYear;
                val.MountingLocation = c.MountingLocation;
                va.Add(val);
            }
            //var outs = JsonConvert.SerializeObject(va);
            //return Json(outs, JsonRequestBehavior.AllowGet);
            return va;

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Summary(string searchString)
        //{
        //    Service serv = new Service();

        //    string vals = "Products found: " + serv.ProductSearch(searchString);
        //    ViewBag.Message = vals;

        //    return View(searchString);
        //}
    }
}