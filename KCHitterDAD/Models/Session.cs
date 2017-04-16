using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCHitterDAD.Models
{
    public class Session
    {
        public int SessionID { get; set; }

        public string Date { get; set; }

        public int PlayerID { get; set; }

        public float Pitches { get; set; }

        public float TotalHits { get; set; }

        public float GoodContact { get; set; }

        public float BadContact { get; set; }

        public float ExitVelocity { get; set; }

        public float Trajectory { get; set; }

        public float Distance { get; set; }

        public virtual Player Player { get; set; }

    }
}