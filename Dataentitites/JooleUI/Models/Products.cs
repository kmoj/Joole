using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleUI.Models
{
    public class Products
    {

        public int Product_ID { get; set; }
        public string Manufacturer_Name { get; set; }
        public string Product_Name { get; set; }
        public byte[] Product_Image { get; set; }
        public string Series { get; set; }
        public string Charecteristics { get; set; }
        public string Model { get; set; }
        public string MountingLocation { get; internal set; }
        public string ModelYear { get; internal set; }
        public string Application { get; internal set; }
        public string UseType { get; internal set; }
        public string Object { get; set; }
    }
}