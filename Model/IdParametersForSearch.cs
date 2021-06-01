using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class IdParametersForSearch
    {
        public int id { get; set; }

     
    }
    public class ParamForDataBase
    {
        public string Hero { get; set; }
    }
    public class IdforMatch
    {
        public long matchid { get; set; }
    }
    public class TurnirPage
    {
        public int page { get; set; }
    }
    public class TeamId
    {
        public int id { get; set; }
    }
}
