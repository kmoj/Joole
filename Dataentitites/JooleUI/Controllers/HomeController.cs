﻿using System.Collections.Generic;
using System.Web.Mvc;
using Services;
using JooleUI.Models;
using Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Dataentitites;

namespace JooleUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Summa(int id)
        {
            Service serv = new Service();
            List<Category> listObj = new List<Category>();
            foreach (var tempCatego in serv.getCategories())
            {
                Category tempObj = new Category();
                tempObj.Category_ID = tempCatego.Category_ID;
                tempObj.Category_Name = tempCatego.Category_Name;
                listObj.Add(tempObj);
            }
            ViewBag.Category = new SelectList(listObj, "Category_ID", "Category_Name");
            tblProduct tblproduct = serv.value(id);
            Products prod = new Products();
            prod.Product_Name = tblproduct.Product_Name;
            prod.Product_Image = tblproduct.Product_Image;
            prod.Series = tblproduct.Series;
            prod.Charecteristics = tblproduct.Characteristics;
            prod.Model = tblproduct.Model;
            prod.AirFLow = tblproduct.AirFLow;
            prod.PowerMax = tblproduct.PowerMax;
            prod.PowerMin = tblproduct.PowerMin;
            prod.OVMax = tblproduct.PowerMax * 100 - 70;
            prod.OVMin = tblproduct.PowerMax * 100 - 20;
            prod.FanSpeedMax = tblproduct.PowerMax * 100 / 6;
            prod.FanSpeedMin = tblproduct.PowerMax * 100 - 40;
            prod.MaxSpeedSound = tblproduct.MaxSpeedSound;
            prod.SweepDiameter = tblproduct.SweepDiameter;
            prod.Manufacturer_Name = tblproduct.tblManufacturer.Manufacturer_Name;
            prod.Manufacturer_Department = tblproduct.tblManufacturer.Manufacturer_Department;
            prod.Manufacturer_Web = tblproduct.tblManufacturer.Manufacturer_Web;
            prod.UseType = tblproduct.tblType.UseType;
            prod.Application = tblproduct.tblType.Application;
            prod.MountingLocation = tblproduct.tblType.MountingLocation;
            prod.Accessories = tblproduct.tblType.Accessories;
            prod.ModelYear = tblproduct.tblType.ModelYear;

            TempData["ids"] = id;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Summa(string term, string Category)
        {
            if (string.IsNullOrEmpty(term))
            {
                //search based on the category
                return RedirectToAction("Summary", "Product", new { searchString = term });

            }
            else
            {
                return RedirectToAction("Summary", "Product", new { searchString = term });
            }
        }

        public JsonResult Autocomplete(string term, string Category)
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

            foreach (var vals in filteredItems)
            {
                string normal = vals.ToLower();
                if (normal.Contains(term.ToLower()))
                {
                    filt.Add(vals);
                }
            }

            var chak = JsonConvert.SerializeObject(filt);

            return Json(chak, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Summ()
        {
            int vag = (int)TempData["ids"];
            Service serv = new Service();
            List<Products> va = new List<Products>();
            {
                Products val = new Products();
                var a = serv.value(vag);
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

        
        public ActionResult Black()
        {
            Service serv = new Service();
            List<Category> listObj = new List<Category>();
            foreach (var tempCatego in serv.getCategories())
            {
                Category tempObj = new Category();
                tempObj.Category_ID = tempCatego.Category_ID;
                tempObj.Category_Name = tempCatego.Category_Name;
                listObj.Add(tempObj);
            }
            ViewBag.Category = new SelectList(listObj, "Category_ID", "Category_Name");

            int[] comp = (int[])TempData["camp"];
            List<Products> comparedProducts = new List<Products>();
            for (int i = 0; i < comp.Length; i++)
            {
                tblProduct tblproduct = serv.value(comp[i]);
                Products prod = new Products();
                prod.Product_Name = tblproduct.Product_Name;
                prod.Product_Image = tblproduct.Product_Image;
                prod.Series = tblproduct.Series;
                prod.Charecteristics = tblproduct.Characteristics;
                prod.Model = tblproduct.Model;
                prod.AirFLow = tblproduct.AirFLow;
                prod.PowerMax = tblproduct.PowerMax;
                prod.PowerMin = tblproduct.PowerMin;
                prod.OVMax = tblproduct.PowerMax * 100 - 70;
                prod.OVMin = tblproduct.PowerMax * 100 - 20;
                prod.FanSpeedMax = tblproduct.PowerMax * 100 / 6;
                prod.FanSpeedMin = tblproduct.PowerMax * 100 - 40;
                prod.MaxSpeedSound = tblproduct.MaxSpeedSound;
                prod.SweepDiameter = tblproduct.SweepDiameter;
                prod.Manufacturer_Name = tblproduct.tblManufacturer.Manufacturer_Name;
                prod.Manufacturer_Department = tblproduct.tblManufacturer.Manufacturer_Department;
                prod.Manufacturer_Web = tblproduct.tblManufacturer.Manufacturer_Web;
                prod.UseType = tblproduct.tblType.UseType;
                prod.Application = tblproduct.tblType.Application;
                prod.MountingLocation = tblproduct.tblType.MountingLocation;
                prod.Accessories = tblproduct.tblType.Accessories;
                prod.ModelYear = tblproduct.tblType.ModelYear;
                comparedProducts.Add(prod);
            }

                return View("Black", comparedProducts);
        }

        [HttpPost]
        public ActionResult Black(string term, string Category)
        {
            if (string.IsNullOrEmpty(term))
            {
                //search based on the category
                return RedirectToAction("Summary", "Product", new { searchString = term });

            }
            else
            {
                return RedirectToAction("Summary", "Product", new { searchString = term });
            }
        }

        public JsonResult Blacks()
        {
            int[] comp = (int[])TempData["camp"];
            Service serv = new Service();
            List<Products> va = new List<Products>();
            for (int i = 0; i < comp.Length; i++)
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
            var outs = JsonConvert.SerializeObject(va);
            return Json(outs, JsonRequestBehavior.AllowGet);
        }

    }
}