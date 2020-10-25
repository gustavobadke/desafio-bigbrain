using BigBrain.Domain.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBrain.Domain.Services
{
    public class UserService
    {
        private readonly GraphServiceClient client;

        public UserService()
        {
            this.client = new ClientService().GetClientAuthenticated();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync(string searchName)
        {
            var request = client.Users
                .Request()
                .Select("displayName,mail")
                .Top(12);

            if (!string.IsNullOrWhiteSpace(searchName))
                request.Filter($"startswith(displayName,'{searchName}')");

            var users = await request.GetAsync();

            return users.CurrentPage.Select(m => new UserModel
            {
                DisplayName = m.DisplayName,
                Mail = m.Mail
            });
        }
    }
}
