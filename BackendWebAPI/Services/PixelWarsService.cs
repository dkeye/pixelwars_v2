using BackendWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;

namespace BackendWebAPI.Services
{
    public class PixelWarsService
    {
        private readonly IMongoCollection<Test> _PixelWarsCollectionName;

        public PixelWarsService(
            IOptions<PixelWarsDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _PixelWarsCollectionName = mongoDatabase.GetCollection<Test>(
                bookStoreDatabaseSettings.Value.PixelWarsCollectionName);
        }

        public async Task<List<Test>> GetAsync() =>
            await _PixelWarsCollectionName.Find(_ => true).ToListAsync();

        public async Task<Test?> GetAsync(string id) =>
            await _PixelWarsCollectionName.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Test newTest) =>
            await _PixelWarsCollectionName.InsertOneAsync(newTest);

        public async Task UpdateAsync(string id, Test updatedTest) =>
            await _PixelWarsCollectionName.ReplaceOneAsync(x => x.Id == id, updatedTest);

        public async Task RemoveAsync(string id) =>
            await _PixelWarsCollectionName.DeleteOneAsync(x => x.Id == id);
    }
}
