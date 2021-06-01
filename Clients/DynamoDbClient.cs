using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2;
using System.Threading.Tasks;
using API.Model;
using Amazon.DynamoDBv2.Model;
using API.Extensions;

namespace API.Clients
{
    public class DynamoDbClient : IDynamoDbClient
    {
        public string _tableName;
        private readonly IAmazonDynamoDB _dynamoDb;
        public DynamoDbClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDb = dynamoDB;
            _tableName = Constants.TableName;
        }
        public async Task<HeroDBRepository> GetDataFromDB(string privateID)
        {


            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "id", new AttributeValue { S = privateID} }
                }

            };
            var responce = await _dynamoDb.GetItemAsync(item);
             if(responce.Item == null || !responce.IsItemSet)
             {
                 return null;
            }

            var result = responce.Item.ToClass<HeroDBRepository>();
            return result;
            
        }
        public async Task PostDataToDb(HeroDBRepository hero)
        {
           
            var request = new PutItemRequest
            {
                TableName = _tableName,
                  Item = new Dictionary<string, AttributeValue>
                  {
                     {"id", new AttributeValue {S = hero.id} },
                     {"Hero", new AttributeValue {S = hero.Hero} }
                  }
            };
            var responce = await _dynamoDb.PutItemAsync(request);
        }
    }
}
