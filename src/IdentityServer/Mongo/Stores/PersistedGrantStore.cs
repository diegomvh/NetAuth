using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using NetAuth.IdentityServer.Mongo.Repositories;

namespace NetAuth.IdentityServer.Mongo.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly IContext _context;
        private readonly PersistedGrantRepository _repository;

        public PersistedGrantStore(IContext context)
        {
            _context = context;
            _repository = _context.GetRepository<NetAuth.IdentityServer.Mongo.Models.PersistedGrant>() as PersistedGrantRepository;
        }

        Task<IEnumerable<PersistedGrant>> IPersistedGrantStore.GetAllAsync(string subjectId)
        {
            System.Console.Write("GetAllAsync");
            throw new NotImplementedException();
        }

        Task<PersistedGrant> IPersistedGrantStore.GetAsync(string key)
        {
            System.Console.Write("GetAsync");
            throw new NotImplementedException();
        }

        Task IPersistedGrantStore.RemoveAllAsync(string subjectId, string clientId)
        {
            System.Console.Write("RemoveAllAsync");
            throw new NotImplementedException();
        }

        Task IPersistedGrantStore.RemoveAllAsync(string subjectId, string clientId, string type)
        {
            System.Console.Write("RemoveAllAsync");
            throw new NotImplementedException();
        }

        Task IPersistedGrantStore.RemoveAsync(string key)
        {
            System.Console.Write("RemoveAsync");
            throw new NotImplementedException();
        }

        Task IPersistedGrantStore.StoreAsync(PersistedGrant grant)
        {
            System.Console.Write("StoreAsync");
            throw new NotImplementedException();
        }
    }
}