using System;
using System.Collections.Generic;
using System.Text;

namespace AppDating.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime Time { get; set; }
        public string Picture { get; set; }
        public string Audio { get; set; }
        public bool IsOriginNative { get; set; }
    }
}
