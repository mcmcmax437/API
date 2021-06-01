using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class MatchByIDResponce
    {

        public string Match_id { get; set; }
        public int Radiant_score { get; set; }
        public int Dire_score { get; set; }
      // public bool Radiant_win { get; set; }
       // public bool Dire_win { get; set; }
       public string Winner { get; set; }
        public string Replay_url { get; set; }

        public List<Playersss> Players { get; set; }

    }
    public class Playersss
    {
        public int hero_id { get; set; }
        public string kills { get; set; }
        public string deaths { get; set; }
        public string assists { get; set; }
        public string kda { get; set; }
        public string personaname { get; set; }

    }
}

