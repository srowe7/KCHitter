using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCHitterApp.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        public String PlayerName { get; set; }

        public float ExitVelocity { get; set; }

        public float Trajectory { get; set; }

        public float QualityContact { get; set; }

        public virtual Admin Admin { get; set; }

    }
}