using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WRLD_Programming_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContent = File.ReadAllText(@"problem_small.txt");
            var array = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string line in array)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line);
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
