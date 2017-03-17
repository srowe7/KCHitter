using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCHitterApp.Models
{
    public class Admin
    {

        public int AdminID { get; set; }

        public String AdminName { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}