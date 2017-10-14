using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hummingbird.Model
{
    public class User
    {
        public Guid ID { get; set; }
        [Required] public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string PasswordHash { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
