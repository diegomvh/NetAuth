using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using NetAuth.IdentityServer.Mongo.Repositories;

namespace NetAuth.IdentityServer.Mongo.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IContext _context;
        private readonly ClientRepository _repository;

        public ClientStore(IContext context)
        {
            _context = context;
            _repository = _context.GetRepository<NetAuth.IdentityServer.Mongo.Models.Client>() as ClientRepository;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _repository.GetClient(clientId);

            if (client == null)
            {
                return Task.FromResult<IdentityServer4.Models.Client>(null);
            }

            return Task.FromResult(new IdentityServer4.Models.Client()
            {
                ClientId = client.ClientId,
                AllowedGrantTypes = client.GrantTypes,
                AllowedScopes = client.Scopes,
                RedirectUris = client.RedirectUris,
                ClientSecrets = client.Secrets.Select(s => new Secret(s.Value.Sha256())).ToList()
            });
        }
    }
}
