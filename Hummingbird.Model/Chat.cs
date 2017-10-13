using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hummingbird.Model
{
    class Chat
    {
        public Guid ID { get; set; }
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}
