using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hummingbird.Model
{
    public class ChatMember
    {
        [Key, Column(Order = 0)] public Guid ChatID { get; set; }
        [ForeignKey("ChatID")] public Chat Chat { get; set; }

        [Key, Column(Order = 1)] public Guid UserID { get; set; }
        [ForeignKey("UserID")] public User User { get; set; }
    }
}
