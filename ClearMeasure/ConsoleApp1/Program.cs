using System;
using System.Collections.Generic;
using NumbersClassLibrary;

namespace ClearMeasure
{
    class Program
    {
        static Dictionary<int, string> defaultRules = new Dictionary<int, string>() { { 3, "fizz" }, { 5, "buzz" } };

        static void Main(string[] args)
        {
            var hexMaxSize = 0X7FEFFFFF;
            // from 1 to 100 if /3 "fizz" if /5 "buz"
            var cl = new Numbers();
            var result = cl.PrintNumbers(1, hexMaxSize, defaultRules);

            // Console.Write(result);

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.Read();
        }
    }
}
