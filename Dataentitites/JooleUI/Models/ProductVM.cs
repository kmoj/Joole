using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleUI.Models
{
    public class ProductVM
    {
        public int productID { get; set; }
        public int manufacturerID { get; set; }
        public int subCategoryID { get; set; }
        public string productName { get; set; }
        //public image productImage { get; set; }
        public string series { get; set; }
        public string model { get; set; }
        public int productTypeID { get; set; }
        public string characteristics { get; set; }

        public ProductVM(int pid, int mid, int scid, string pn, string s, string m, int ptid, string c)
        {
            productID = pid;
            manufacturerID = mid;
            subCategoryID = scid;
            productName = pn;
            series = s;
            model = m;
            productTypeID = ptid;
            characteristics = c;
        }

        public ProductVM()
        {

        }
    }
}