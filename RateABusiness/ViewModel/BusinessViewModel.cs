using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateABusiness.ViewModel
{
    public class BusinessViewModel
    {
        public int BusinessId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City  { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Type { get; set; }

    }
}