using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniTorrent.Models
{
    public class FileFinderObject
    {
        public double size { get; set; }
        public int ManyUser { get; set; }

        public User user { get; set; }
        public MyFile file { get; set; }
    }
}