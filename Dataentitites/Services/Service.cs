﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoBLL;
using System.Data;
using Dataentitites;
using System.Data.Entity;

namespace Services
{
    public class Service
    {

        static string vals = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient; provider connection string='data source=DESKTOP-EROQ1RP\\SQLEXPRESS;initial catalog=Joole;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'";
        static DbContext context = new DbContext(vals);

        UnitofWork uow = new UnitofWork(context);

        /*
         * This method will authenticate user information and check if they are valid or not
         * return: true if the user existed, false otherwise
         * args: uname - will take the login username
         *       upass - will take the user password.
         */
        public bool authentication(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            if (fliteredList.Count > 0)
            {
                if (checker(uname) == "email")
                {
                    if (fliteredList.First().User_Email == uname && fliteredList.First().User_Password == upass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (fliteredList.First().User_Name == uname && fliteredList.First().User_Password.Trim() == upass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public void createUser(string uname, string uemail, string upass)
        {
            tblUser temp = new tblUser();
            temp.User_Name = uname;
            temp.User_Email = uemail;
            temp.User_Password = upass;
            //byte[] imgdata = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("C:\\Users\\thekm\\Desktop\\Joole\\Joole-developer\\Dataentitites\\JooleUI\\Images\\52.jpg));
            //temp.User_Image = imgdata;
            temp.User_Image = System.Text.Encoding.UTF8.GetBytes("1");
            temp.Credential_ID = 1;
            uow.users.add(temp);
        }

        /*
         * This method will take username and email to perform the query and
         * return filtered list based on the given paramenter
         * return List<tblUser>
         * args: uname - username or email
         *       upass - password
         */
        private List<tblUser> filteredList(string uname, string upass)
        {
            tblUser temp = new tblUser();
            if (checker(uname) == "email")
            {
                temp.User_Email = uname;

            }
            else
            {
                temp.User_Name = uname;
            }
            temp.User_Password = upass;
            return uow.users.find(temp).ToList();
        }

        /*
         * This method will check if a given login name is email or username
         * return: email - if it was an email
         *         username - otherwise
         * args: take a login name
         */
        private string checker(string loginName)
        {
            if (loginName.Contains("@"))
            {
                return "email";
            }
            else
            {
                return "username";
            }
        }

        /*
         * this method will return a userID based on the login name and the password given
         * return: userID
         */
        public int getSessionID(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            return fliteredList.First().User_ID;
        }
        public string Value()
        {
            var a = uow.users.Find(1);
            if (a.User_ID != 0)
                return a.User_Name;
            else
                return null;
        }

        public string ProductValue()
        {
            string s = "";
            var a = uow.products.Find(1);
            var b = uow.products.Find(2);
            var c = uow.products.Find(3);
            var d = uow.products.Find(4);
            var e = uow.products.Find(5);
            if (a.Product_ID != 0)
                s += a.Product_Name + " ";
            if (b.Product_ID != 0)
                s += b.Product_Name + " ";
            if (c.Product_ID != 0)
                s += c.Product_Name + " ";
            if (d.Product_ID != 0)
                s += d.Product_Name + " ";
            if (e.Product_ID != 0)
                s += e.Product_Name + " ";
            return s;
        }

        public string ProductSearch(string s)
        {
            string result = uow.products.Search(s);
            return result;
        }

        public IQueryable<tblProduct> GetDataSet(string filter)
        {
            return uow.products.DataSet(filter);
        }
        public tblProduct value(int c)
        {

            var a = uow.products.Find(c);

            return a;
        }

        public tblManufacturer manudetails(int c)
        {
            var a = uow.manu.Find(c);

            return a;
        }

        public tblType typedetails(int c)
        {
            var a = uow.prodtype.Find(c);

            return a;
        }

        public List<tblCategory> getCategories()
        {
            return uow.categorySearch.GetListCategory().ToList();
        }

        public List<tblSubCategory> GetSubCategories(int categoryID)
        {
            return uow.subCategorySearch.getSubCategoBasedOnCatego(categoryID).ToList();
        }
        public IQueryable<tblType> GetTypeDataSet(string filter)
        {
            return uow.types.DataSet(filter);
        }

        public IQueryable<tblProduct> getFanFilter(string filter, int[] props)
        {
            return uow.fanProduct.SearchByFilter(filter, props);
        }

    }
}