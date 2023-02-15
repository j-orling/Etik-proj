using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    public class Item
    {
        public int id;
        public int weight;
        public int value;

        public Item()
        {
            id = 0;
            weight = 0;
            value = 0;
        }

        public Item(int id, int weight, int value)
        {
            this.id = id;
            this.weight = weight;
            this.value = value;
        }
    }
}
