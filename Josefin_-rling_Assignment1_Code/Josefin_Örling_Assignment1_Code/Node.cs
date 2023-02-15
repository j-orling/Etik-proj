using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    class Node
    {
        public Item viewedItem;
        public bool isIncluded;
        public Node parent;
        public int totalValue;
        public int totalWeight;

        public Node()
        {
            parent = null;
            totalValue = 0;
            totalWeight = 0;
            viewedItem = new Item();
        }

        public Node(Item item, Node parent, bool isIncluded)
        {
            if (parent != null)
            {
                this.parent = parent;
                viewedItem = item;
                this.isIncluded = isIncluded;
                if(isIncluded)
                {
                    totalValue += parent.totalValue + item.value;
                    totalWeight += parent.totalWeight + item.weight;
                }
                else
                {
                    totalValue += parent.totalValue;
                    totalWeight += parent.totalWeight;
                }
                
            }
        }

    }
}
