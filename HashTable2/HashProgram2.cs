using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProg
{
    class HashProgram2
    {
        static void Main(string[] args)
        {
            // Let M = 18
            // Init hash table
            HTableLink HashTable = new HTableLink(18);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Hash Table:");
            Console.WriteLine(HashTable.ToString());
            Console.WriteLine("-------------------------------------");

            // N = 18
            var keys = new int[18];
            Random rnd = new Random();
            for (var i = 0; i < 18; i++)
            {
                keys[i] = rnd.Next(32768);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Keys are: ");
            foreach (var key in keys) Console.WriteLine(key);
            Console.WriteLine("-------------------------------------");
            Console.ReadLine();


            foreach (var key in keys)
            {
                HashTable.Insert(key);
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Hash Table:");
            Console.WriteLine(HashTable.ToString());
            Console.WriteLine("-------------------------------------");

            while (true)
            {
                var input = Console.ReadLine();
                int inInt;
                try
                {
                    inInt = Convert.ToInt32(input);
                    HashTable.Find(inInt);
                }
                catch
                {
                    Console.WriteLine("Incorrect number");
                }
            }
        }
    }
}