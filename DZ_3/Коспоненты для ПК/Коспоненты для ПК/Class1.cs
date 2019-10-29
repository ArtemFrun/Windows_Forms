using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Коспоненты_для_ПК
{
    [Serializable]
    public class Component
    {
        public string name { get; set; }
        public string properties { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}
