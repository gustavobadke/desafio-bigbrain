using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrain.Domain.Models
{
    public class UserModel
    {
        public string DisplayName { get; set; }

        public string Mail { get; internal set; }

    }
}
