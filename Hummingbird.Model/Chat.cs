﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hummingbird.Model
{
    public class Chat
    {
        public Guid ID { get; set; }
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        [Required] public ICollection<User> Members { get; set; }

        public virtual ICollection<Chat> Messages { get; set; }
    }
}
