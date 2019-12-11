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
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Charecteristics { get; set; }
        public string Model { get; set; }
        public int AirFLow { get; set; }
        public int PowerMax { get; set; }
        public int PowerMin { get; set; }
        public int OVMax { get; set; }
        public int OVMin { get; set; }
        public int FanSpeedMax { get; set; }
        public int FanSpeedMin { get; set; }
        public int MaxSpeedSound { get; set; }
        public int SweepDiameter { get; set; }

        public string Manufacturer_Name { get; set; }
        public string Manufacturer_Department { get; set; }
        public string Manufacturer_Web { get; set; }

        public string UseType { get; set; }
        public string Application { get; set; }
        public string MountingLocation { get; set; }
        public string Accessories { get; set; }
        public string ModelYear { get; set; }



        public string Object { get; set; }
    }
}