using System;
using System.Collections.Generic;
using System.Text;

namespace gastronom.Models
{
    public class Products : ModelsIdentity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public int Type { get; set; }
        public float QuantityOrWeight { get; set; }
        public float Price { get; set; }
    }
}
