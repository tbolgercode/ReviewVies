using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review_vies.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null;
        public List<string> Directors { get; set; } = null;
        public List<string> Actors { get; set; } = null;
        public string Rating { get; set; } = null; //PG, G, PG-13, etc.
        public int Stars { get; set; } = 0;
        public string Synopsis { get; set; } = null;
        public string Description { get; set; } = null;

    }
}
