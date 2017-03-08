using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace NetAuth.IdentityServer.Mongo.Stores
{
    public class ResourceStore : IResourceStore
    {
        Task<ApiResource> IResourceStore.FindApiResourceAsync(string name)
        {
            System.Console.Write("FindApiResourceAsync");
            throw new NotImplementedException();
        }

        Task<IEnumerable<ApiResource>> IResourceStore.FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            System.Console.Write("FindApiResourcesByScopeAsync");
            throw new NotImplementedException();
        }

        Task<IEnumerable<IdentityResource>> IResourceStore.FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            System.Console.Write("FindIdentityResourcesByScopeAsync");
            throw new NotImplementedException();
        }

        Task<Resources> IResourceStore.GetAllResources()
        {
            System.Console.Write("GetAllResources");
            throw new NotImplementedException();
        }
    }
}
