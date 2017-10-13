using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hummingbird.Model
{
    public class User
    {
        public Guid ID { get; set; }
        public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
