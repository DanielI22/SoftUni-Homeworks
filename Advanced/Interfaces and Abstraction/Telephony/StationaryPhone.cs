﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string callNumber(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
