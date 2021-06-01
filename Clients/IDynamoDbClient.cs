using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Clients
{
    public interface IDynamoDbClient
    {

        public Task<HeroDBRepository> GetDataFromDB(string privateID);
        public Task PostDataToDb(HeroDBRepository hero);
    }
}
