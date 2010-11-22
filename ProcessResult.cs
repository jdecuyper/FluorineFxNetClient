using System;
using System.Collections.Generic;

namespace FluorineFx
{
    public class ProcessResult
    {
        public static void ResultReceived<T>(T result) { 
            // Method does not work with complex data types such as DataTable.
            Console.WriteLine("Result: {0}", result);
        }
    }
}
