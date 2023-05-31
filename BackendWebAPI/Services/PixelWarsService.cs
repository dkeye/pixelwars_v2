using BackendWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BackendWebAPI.Services
{
    public class PixelWarsService
    {
        private readonly IMongoCollection<PixelWarsGrid> _PixelWarsCollectionName;

        public PixelWarsService(
            IOptions<PixelWarsDatabaseSettings> pixelwarsdatabasesettings)
        {
            var mongoClient = new MongoClient(
                pixelwarsdatabasesettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                pixelwarsdatabasesettings.Value.DatabaseName);

            _PixelWarsCollectionName = mongoDatabase.GetCollection<PixelWarsGrid>(
                pixelwarsdatabasesettings.Value.PixelWarsCollectionName);
        }

        public async Task<List<PixelWarsGrid>> GetAsync() =>
                await _PixelWarsCollectionName.Find(_ => true).ToListAsync();

        public async Task<PixelWarsGrid?> GetByIdAsync(string id) =>
            await _PixelWarsCollectionName.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<PixelWarsGrid?> GetByNameAsync(string name) =>
            await _PixelWarsCollectionName.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task<Square?> GetSquareAsync(string name, int x, int y)
        {
            var collectionfilter = new BsonDocument ("$and", new BsonArray { new BsonDocument("Name", name), new BsonDocument("Squares.x",x), new BsonDocument("Squares.y", y) });

            var squarefilter = await _PixelWarsCollectionName.Find(collectionfilter).FirstOrDefaultAsync();

            return squarefilter.Squares.FirstOrDefault(Square => Square.y == y && Square.x == x);
        }

        public async Task<UpdateResult> UpdateSquareColor(string name, int x, int y, string color)
        {
            var collectionfilter = new BsonDocument("$and", new BsonArray { new BsonDocument("Name", name), new BsonDocument("Squares.x", x), new BsonDocument("Squares.y", y) });

            var updatesettings = new BsonDocument("$set",new BsonDocument("Squares.$.color", color));

            return await _PixelWarsCollectionName.UpdateOneAsync(collectionfilter, updatesettings);
        }

        public async Task DeleteGridByName(string name) => await _PixelWarsCollectionName.DeleteOneAsync(new BsonDocument("Name",name));

        internal async Task GenerateGrid(string name, uint x, uint y)
        {
            var grid = new PixelWarsGrid();
            grid.Name = name;
            grid.Size = x.ToString() + "x" + y.ToString();

            var squares = new List<Square>();

            for (int i = 0; i < y; i++)
            {
                for (int z = 0; z < x; z++)
                {
                    var square = new Square();

                    square.x = i;
                    square.y = z;
                    square.Сolor = "White";

                    squares.Add(square);
                }
            }

            grid.Squares = squares.ToArray();

            await _PixelWarsCollectionName.InsertOneAsync(grid);
        }
    }
}
