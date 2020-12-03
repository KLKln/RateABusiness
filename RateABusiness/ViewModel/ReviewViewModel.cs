using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateABusiness.ViewModel
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        public int BusinessId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}