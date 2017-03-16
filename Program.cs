using System;
using System.Xml.Linq;

namespace trx_reader
{
    class Program
    {
        private static readonly string separator = "---------";

        static void Main(string[] args)
        {
            var x = XDocument.Load("testresults.trx");
            var a = new TrxAnalyzer(x);

            Console.WriteLine(separator);
            foreach (var item in a.GetSummary())
            {
                Console.WriteLine($"{item.Outcome}: {item.NumberOfTests}");
            }

            Console.WriteLine(separator);
            foreach (var failed in a.GetFailed()) {
                Console.WriteLine($"{failed.Message}");
                Console.WriteLine(separator);                
                Console.WriteLine($"{failed.StackTrace}");
            }
            Console.WriteLine(separator);            
        }
    }
}
