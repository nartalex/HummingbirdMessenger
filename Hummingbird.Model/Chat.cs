using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hummingbird.Model
{
    public class Chat
    {
        public Guid ID { get; set; }
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        [Required] public ICollection<ChatMember> Members { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
