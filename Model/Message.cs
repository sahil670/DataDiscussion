using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataDiscussion.Model
{
    public class Message
    {
        //Message id
        public int Id { get; set; }

        //Mesage text
        public string Text { get; set; }

        //Message sender
        public string Sender { get; set; }

        //Message time
        public DateTime time { get; set; }
    }
}
