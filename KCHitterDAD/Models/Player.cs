using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCHitterDAD.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        public string PlayerName { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

    }
}