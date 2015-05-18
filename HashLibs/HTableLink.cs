using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProg
{
    public class HTableLink : HTable
    {
        private List<List<int>> Table;
        public HTableLink(int size) : base(size)
        {
            Size = size;
            Table = new List<List<int>>(size);
            for (var i = 0; i < size; i++)
            {
                Table.Add(new List<int>());
            }
        }

        public override void Insert(int key)
        {
            if (!Table[CalcHash(key)].Contains(key))
            {
                Console.WriteLine("Inserting key " + key + " to " + CalcHash(key));
                Table[CalcHash(key)].Add(key);
            }
        }

        public override void Find(int key)
        {
            if (Table[CalcHash(key)].Contains(key))
            {
                Console.WriteLine("Key " + key + " found at " + CalcHash(key) + ", " + Table[CalcHash(key)].IndexOf(key));
            }
            else
            {
                Console.WriteLine("Can't find key " + key);
            }
        }

        public override string ToString()
        {
            string outString = "";
            foreach (var h in Table)
            {
                var line = "[";
                foreach (var item in h)
                {
                    line = line + item + ',';
                }
                if (line[line.Length - 1] == ',')
                    line = line.Remove(line.Length - 1);
                outString = outString + line + "]\n";
            }
            return outString;
        }

    }
}
