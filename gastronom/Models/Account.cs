using System;
using System.Collections.Generic;
using System.Text;

namespace gastronom.Models
{
    public class Account : ModelsIdentity
    {
        public string UserName { get; set; }
        public int PinCode { get; set; } 
    }
}
