using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review_vies.Models
{
    public class BingSearchResult
    {
        public List<BingImage> Value { get; set; }
    }
    public class BingImage 
    {
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public string contentUrl { get; set; }
    }

}
