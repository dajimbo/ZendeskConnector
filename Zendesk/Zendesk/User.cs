using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendesk
{
    public class NewUser
    {
        public User user { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}
