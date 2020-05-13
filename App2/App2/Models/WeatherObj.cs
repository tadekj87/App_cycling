using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{

    public class Main
    {
        public float temp { get; set; }
    }

    public class WeatherInfo
    {
        public Weather[] weather { get; set; }
        public Main main { get; set; }
        public int dt { get; set; }
        public string name { get; set; }
        public Wind wind { get; set; }

    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}


