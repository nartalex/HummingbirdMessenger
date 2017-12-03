using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hummingbird.Model
{
    public class User
    {
        public Guid ID { get; set; }
        [Required] public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string PasswordHash { get;  set; }
        public bool Disabled { get; set; }

        public ICollection<ChatMember> Chats { get; set; }

        public override string ToString()
        {
            return $"{Nickname} ({Login})";
        }
    }
}
