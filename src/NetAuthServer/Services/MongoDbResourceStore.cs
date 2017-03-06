using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace NetAuthServer.Services
{
    public class MongoDbResourceStore : IResourceStore
    {
        Task<ApiResource> IResourceStore.FindApiResourceAsync(string name)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ApiResource>> IResourceStore.FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IdentityResource>> IResourceStore.FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        Task<Resources> IResourceStore.GetAllResources()
        {
            throw new NotImplementedException();
        }
    }
}
