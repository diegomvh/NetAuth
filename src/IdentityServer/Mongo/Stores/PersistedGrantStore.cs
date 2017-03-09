using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using NetAuth.Mongo;
using NetAuth.Mongo.Repositories;

namespace NetAuth.IdentityServer.Mongo.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly Context _context;
        private readonly PersistedGrantRepository _repository;

        public PersistedGrantStore(NetAuth.Mongo.Context context)
        {
            _context = context;
            _repository = _context.PersistedGrants;
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