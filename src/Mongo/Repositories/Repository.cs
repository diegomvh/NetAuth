using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace NetAuth.Mongo.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly string _collectionName;
        private readonly IMongoDatabase _db;
        public static readonly UpdateOptions PerformUpsert = new UpdateOptions() {IsUpsert = true};

        public Repository(IMongoDatabase db, string collectionName)
        {
            _db = db;
            _collectionName = collectionName;
        }

        public IMongoCollection<TModel> Collection
        {
            get { return _db.GetCollection<TModel>(_collectionName); }
        }

        public void Add(TModel model)
        {
            this.Collection.InsertOne(model);
        }

        public Task AddAsync(TModel model)
        {
            return this.Collection.InsertOneAsync(model);
        }

        public IMongoQueryable<TModel> AsQueryable() {
            return this.Collection.AsQueryable();
        }
    }
}