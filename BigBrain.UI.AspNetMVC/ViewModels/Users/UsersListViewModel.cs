using BigBrain.Domain.Models;
using System.Collections.Generic;

namespace BigBrain.ViewModels
{
    public class UsersListViewModel
    {
        public string SearchName { get; set; }

        public IEnumerable<UserModel> Users { get; set; }
    }
}