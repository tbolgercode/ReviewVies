using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review_vies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null;
        public string Director { get; set; } = null;
        public string Year { get; set; } = null;
        public string Rating { get; set; } = null; //PG, G, PG-13, etc.
        public short Scale { get; set; } = 0;
    }
}
