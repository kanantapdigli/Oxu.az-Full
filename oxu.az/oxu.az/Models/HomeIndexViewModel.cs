using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Models
{
    public class HomeIndexViewModel
    {
        public List<News> FeaturedNews { get; set; }
        public List<News> GeneralNews { get; set; }
    }
}
