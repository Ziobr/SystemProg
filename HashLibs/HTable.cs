using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProg
{
    public class HTable
    {
        //blabla
        private List<int> Table;
        public int Size{get; set;}

        public HTable(int size)
        {
            Size = size;
            Table = new List<int>();
            for (var i = 0; i < size; i++)
            {
                Table.Add(0);
            }
        }

        public int CalcHash(int key)
        {
            return key % Size;
        }

        public virtual void Insert(int key)
        {
            if (Table[CalcHash(key)] == 0)
            {
                Console.WriteLine("Inserting key " + key + " to " + CalcHash(key));
                Table[CalcHash(key)] = key;
            }
            else
            {
                var c = 3;
                var i = 0;
                try
                {
                    while (Table[CalcHash(key) + c * i] != 0)
                    {
                        Console.WriteLine("Can't insert key " + key + " to " + CalcHash(key + c * i) + " - already taken by " + Table[CalcHash(key + c * i)]);
                        i++;
                    }
                    Console.WriteLine("Inserting key " + key + " to " + CalcHash(key + c * i));
                    Table[CalcHash(key) + c * i] = key;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Can't insert key " + key + " to table - out of range");
                }
            }
        }

        public virtual void Find(int key)
        {
            if (Table[CalcHash(key)] == key)
            {
                Console.WriteLine("Key " + key + " found at " + CalcHash(key));
            }
            else
            {
                var c = 3;
                var i = 0;
                try
                {
                    while (Table[CalcHash(key) + c * i] != key)
                    {
                        //Console.WriteLine("Can't insert key " + key + " to " + CalcHash(key + c * i) + " - already taken by " + Table[CalcHash(key + c * i)]);
                        i++;
                    }
                    Console.WriteLine("Key " + key + " found at " + CalcHash(key) + c * i);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Can't find key " + key);
                }

            }
        }

        public override string ToString()
        {
            string outString = "";
            foreach (var h in Table)
            {
                outString = outString + h + "\n";
            }
            return outString;
        }
    }
}
