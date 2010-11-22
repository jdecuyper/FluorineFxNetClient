using System;
using System.Collections.Generic;

namespace FluorineFx
{
    class Program
    {
        static void Main(string[] args)
        {
            // change as appropriate
            string gateway = "http://localhost:59632/ws/Gateway.aspx";
            FluorineNetClient client = new FluorineNetClient(gateway);

            // Call is a generic method, you will need to specify the type of the return valueB
            client.Call<bool>("namespace.className.MethodName" /* optional parameters */ );
            
            Console.ReadKey();
        }
    }
}
