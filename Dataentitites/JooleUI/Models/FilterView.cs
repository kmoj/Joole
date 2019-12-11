using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleUI.Models
{
    [Serializable]
    public class FilterView
    {
        public string startYear { get; set; }

        public string endYear { get; set; }

        public int minAirflow { get; set; }

        public int maxAirflow { get; set; }

        public int minPower { get; set; }

        public int maxPower { get; set; }

        public int minSound { get; set; }

        public int maxSound { get; set; }

        public int minFanDiameter { get; set; }

        public int maxFanDiameter { get; set; }

        
    }
}