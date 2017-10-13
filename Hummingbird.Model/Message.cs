using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hummingbird.Model
{
    class Message
    {
        public enum AttachTypes
        {
            Image,
            File
        }

        public Guid ID { get; set; }
        public User UserFrom { get; set; }
        public Chat ChatTo { get; set; }
        public DateTime Time { get; set; }
        public int TimeToLive { get; set; }
        public string Text { get; set; }
        public AttachTypes AttachType { get; set; }
        public string AttachPath { get; set; }
        public bool Edited { get; set; }

    }
}
