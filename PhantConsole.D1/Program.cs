using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantConsole.D1
{
    class Program
    {
        static void Main(string[] args)
        {
            PhantClient myPhantClient = new PhantClient();

            Console.WriteLine(myPhantClient.AddData("15", "60"));
            
            Console.ReadLine();
        }
    }
}
