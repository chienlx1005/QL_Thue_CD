using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Counter
    {
        private string makh;
        private int count;

        public string Makh { get => makh; set => makh = value; }
        public int Count { get => count; set => count = value; }

        public Counter()
        {
        }

        public Counter(string makh, int count)
        {
            this.Makh = makh;
            this.Count = count;
        }

    }
}
