using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
   
    public class TeamById
    {
        public int team_id { get; set; }
        public double rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public string name { get; set; }
        public string logo_url { get; set; }
    }
}
