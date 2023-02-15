using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    class Tree
    {
        public List<Item> allItems;
        public List<Node> allNodes;
        public int maxWeight = 420;
        public Tree(List<Item> items)
        {
            allItems = items;
            allNodes = new List<Node>();
        }

        public Node BFS()
        {
            List<Item> rootItem = new List<Item>();
            rootItem.Add(allItems[0]);
            Node root = new Node(null, allItems, rootItem);
            Queue<Node> tree = new Queue<Node>();
            tree.Enqueue(root);
            Node bestPath = root;
            while(tree.Any())
            {
                Node n = tree.Dequeue();
                for(int i = 0; i < n.itemsPacked.Count; i++)
                {
                    Console.WriteLine(n.itemsPacked[i].id);
                }
                if(n.totalWeight <= maxWeight && n.totalValue > bestPath.totalValue)
                {
                    bestPath = n;
                    Console.WriteLine("The new best path has weight " + bestPath.totalWeight + " and value " + bestPath.totalValue);
                }

                for (int i = 0; i < allItems.Count; i++)
                {
                    if (!n.itemsPacked.Contains(allItems[i]))
                    {
                        
                    }
                }


                for (int i = 0; i < n.children.Count; i++)
                {
                    tree.Enqueue(n.children[i]);
                }
            }

            return bestPath;
        }
    }
}
