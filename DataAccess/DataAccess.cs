using MongoDB.Driver;
using MongoDB.Bson;
using HeroGritSheet.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration; // Required for IConfiguration

namespace BlazorServerApp.DataAccess
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Character> _collection;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB");
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("herogritdb");
            _collection = database.GetCollection<Character>("Characters");
        }

        public async Task InsertAsync(Character characterModel)
        {
            await _collection.InsertOneAsync(characterModel);
        }

        public List<Character> GetCharacters()
        {
            var characters = _collection.AsQueryable().ToList();
            return characters;
        }

        // add other CRUD operations as needed
    }
}
