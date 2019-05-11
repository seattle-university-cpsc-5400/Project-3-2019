using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ASTBuilder
{
    class Program
    {
                static void Main(string[] args)
        {
            var parser = new TCCLParser();
            string name;
            while (true)
            {
                Console.Write("Enter a file name: ");
                name = Console.ReadLine();
                Console.WriteLine("Compiling file " + name);
                parser.Parse(name + ".txt");
                Console.WriteLine("Semantic checking complete");
            }

        }
    }
}
