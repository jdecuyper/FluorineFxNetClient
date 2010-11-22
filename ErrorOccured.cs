using System;
using FluorineFx.Net;
using System.Collections.Generic;

namespace FluorineFx
{
    class ErrorOccured
    {
        public static void ErrorReceived(Fault f)
        {
            Dictionary<string, object> dc = f.Content as Dictionary<string, object>;
            foreach (KeyValuePair<string, object> pair in dc)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
