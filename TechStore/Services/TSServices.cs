using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStore.Services
{
    public class TSServices
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly IMongoCollection<Order> _orderCollection;

        public TSServices(
            IOptions<TSDbConnectionSettings> tsdbConnectionSettings)
        {
            var mongoClient = new MongoClient(
                tsdbConnectionSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(
                tsdbConnectionSettings.Value.DbName);

            _userCollection = mongoDB.GetCollection<User>(
                tsdbConnectionSettings.Value.ProductCollection);

            _orderCollection = mongoDB.GetCollection<Order>(
                tsdbConnectionSettings.Value.OrderCollection);
        }

        // Find All
        public async Task<List<User>> GetAllUsersAsync() => 
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<List<Order>> GetAllOrdersAsync() =>
            await _orderCollection.Find(_ => true).ToListAsync();

        // Find by ID
        public async Task<User?> GetOneUserAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Order?> GetOneOrderAsync(string id) =>
            await _orderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Add query
        public async Task AddUser(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);
        public async Task AddOrder(Order newOrder) =>
            await _orderCollection.InsertOneAsync(newOrder);
    }
}
