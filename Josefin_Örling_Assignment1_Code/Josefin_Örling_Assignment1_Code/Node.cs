using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    class Node
    {
        public List<Item> allItems;
        public List<Item> itemsPacked = new List<Item>();
        public Node parent;
        public List<Node> children = new List<Node>();
        public int totalValue;
        public int totalWeight;

        public Node(Node parent, List<Item> allItems, List<Item> itemsPacked)
        {
            this.allItems = allItems;
            if(itemsPacked != null)
            {
                this.itemsPacked = itemsPacked;
            }
            
            for(int i = 0; i < this.itemsPacked.Count; i++)
            {
                totalValue += this.itemsPacked[i].value;
                totalWeight += this.itemsPacked[i].weight;
            }
            if(parent != null)
            {
                this.parent = parent;
            }

        }

    }
}
