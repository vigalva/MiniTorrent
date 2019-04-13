using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniTorrent.Models
{
    public class MyFile
    {
        [Key]
        public int Id { get; set; }


        public int IdUser { get; set; }
        public string name { get; set; }
        public double size { get; set; }
        public string description { get; set; }
    }
}