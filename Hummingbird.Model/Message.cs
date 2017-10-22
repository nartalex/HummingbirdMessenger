using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hummingbird.Model
{
    public class Message
    {
        public enum AttachTypes
        {
            Null,
            Image,
            File
        }

        public Guid ID { get; set; }

        [Required] public Guid UserFromID { get; set; }
        [ForeignKey("UserFromID")] public User User { get; set; }

        [Required] public Guid ChatToID { get; set; }
        [ForeignKey("ChatToID")] public Chat Chat { get; set; }

        [Required] public DateTime Time { get; set; }
        public int TimeToLive { get; set; }
        public string Text { get; set; }
        public AttachTypes AttachType { get; set; }
        public string AttachPath { get; set; }
        public bool Edited { get; set; }
    }
}
