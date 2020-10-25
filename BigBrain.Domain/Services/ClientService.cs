using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace BigBrain.Domain.Services
{
    public class ClientService
    {
        public GraphServiceClient GetClientAuthenticated()
        {
            return new GraphServiceClient(
                new ClientCredentialProvider(ConfidentialClientApplicationBuilder
                    .Create(Configuration.MicrosoftCredentials.AppId)
                    .WithTenantId(Configuration.MicrosoftCredentials.TenantId)
                    .WithClientSecret(Configuration.MicrosoftCredentials.Secret)
                    .Build()));
        }
    }
}