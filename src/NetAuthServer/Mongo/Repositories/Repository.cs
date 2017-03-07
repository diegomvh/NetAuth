using MongoDB.Driver;

namespace NetAuthServer.Mongo.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly string _collectionName;
        private readonly IMongoDatabase _db;
        public static readonly UpdateOptions PerformUpsert = new UpdateOptions() {IsUpsert = true};

        public Repository(IMongoDatabase db, string collectionName)
        {
            _db = db;
            _collectionName = collectionName;
        }

        public IMongoCollection<TEntity> Collection
        {
            get { return _db.GetCollection<TEntity>(_collectionName); }
        }
    }
}