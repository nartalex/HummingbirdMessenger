using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace Hummingbird.DataLayer.SQL
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }

        private static string DecodeMessage(string[] lines)
        {
            List<string> list = new List<string>();
            foreach (var l in lines)
            {
                foreach (var w in l.Split(' '))
                {
                    if (Char.IsUpper(w[0]))
                        list.Insert(0, w);
                }
            }
            return list.ToString();
        }
    }
}
