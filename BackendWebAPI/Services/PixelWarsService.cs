using BackendWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;

namespace BackendWebAPI.Services
{
    public class PixelWarsService
    {
        private readonly IMongoCollection<PixelWarsCollection> _PixelWarsCollectionName;

        public PixelWarsService(
            IOptions<PixelWarsDatabaseSettings> pixelwarsdatabasesettings)
        {
            var mongoClient = new MongoClient(
                pixelwarsdatabasesettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                pixelwarsdatabasesettings.Value.DatabaseName);

            _PixelWarsCollectionName = mongoDatabase.GetCollection<PixelWarsCollection>(
                pixelwarsdatabasesettings.Value.PixelWarsCollectionName);
        }

        public async Task<List<PixelWarsCollection>> GetAsync() =>
                await _PixelWarsCollectionName.Find(_ => true).ToListAsync();

        public async Task<PixelWarsCollection?> GetAsync(string id) =>
            await _PixelWarsCollectionName.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PixelWarsCollection newObject) =>
            await _PixelWarsCollectionName.InsertOneAsync(newObject);
    }
}
