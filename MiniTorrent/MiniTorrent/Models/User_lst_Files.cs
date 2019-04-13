using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniTorrent.Models
{
    public class User_lst_Files
    {
        public User User { get; set; }
        public List<MyFile> lstFiles { get; set; }
    }
}