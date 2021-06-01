using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
   
    public class Turnir
    {
        public string begin_at { get; set; }
        public string end_at { get; set; }

      public liga league { get; set; }

        public List<MT> matches { get; set; }
        public string name { get; set; }
        public string prizepool { get; set; }
        //public List<SR> serie { get; set; }
        public List<TM> teams { get; set; }
        public int? winner_id { get; set; }
        
    }
    public class liga
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MT
    {
        public string begin_at { get; set; }
        public string end_at { get; set; }
        public long id { get; set; }
        public string match_type { get; set; }
        public string name { get; set; }
        public string official_stream_url { get; set; }
        public long tournament_id { get; set; }
        public int? winner_id { get; set; }
    }

    /*public class SR
    {
        public string begin_at { get; set; }
        public string end_at { get; set; }
        public string full_name { get; set; }
        public string season { get; set; }
        public string tier { get; set; }
        public int year { get; set; }
    }*/
    public class TM
    {
        public long id { get; set; }
        public string name { get; set; }
    }
  
   
}
