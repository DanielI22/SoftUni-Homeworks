using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string browse(string browseUrl)
        {
            return $"Browsing: {browseUrl}!";
        }

        public string callNumber(string number)
        {
            return $"Calling... {number}";
        }
    }
}
