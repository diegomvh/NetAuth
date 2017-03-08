using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

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

        public Task Add(TModel model)
        {
            return this.Collection.InsertOneAsync(model);
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return this.Collection.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.Collection.AsQueryable().Provider; }
        }
        
    }
}