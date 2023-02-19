using System;
using System.Collections.Generic;
using System.Linq;

namespace Josefin_Örling_Assignment1_Code
{
    public class Tree
    {
        #region Fields
        /// <summary>
        /// list of all items
        /// </summary>
        List<Item> allItems;
        /// <summary>
        /// Max weight
        /// </summary>
        int maxWeight;
        /// <summary>
        /// Max items
        /// </summary>
        int maxItems;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="items"></param>
        /// <param name="maxWeight"></param>
        /// <param name="maxItems"></param>
        public Tree(List<Item> items, int maxWeight, int maxItems)
        {
            allItems = items;
            this.maxWeight = maxWeight;
            this.maxItems = maxItems;
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Breadth-first search of the tree.
        /// Queue (FIFO : First In First Out)
        /// </summary>
        /// <returns> A node contains the best solution</returns>
        public Node BFS()
        {
            Node best = new Node();
            Queue<Node> tree = new Queue<Node>();
            tree.Enqueue(new Node());
            while(tree.Any())
            {
                Node node = tree.Dequeue();
                // Goal check
                if(best.TotalValue < node.TotalValue && node.TotalWeight < maxWeight)
                {
                    best = node;
                }
                // If the max weight is reached, there's no need to keep looking
                if (node.TotalWeight < maxWeight && node.ViewedItem.Id != maxItems)
                {
                    // Node where the checked item is included and should be added to the weight and value calculations
                    Node newNodeItemInc = new Node(allItems[node.ViewedItem.Id], node, true);
                    // Node where the checked item isn't included, but kept as a way to know which layer we're working on
                    Node newNodeItemNotInc = new Node(allItems[node.ViewedItem.Id], node, false);
                    tree.Enqueue(newNodeItemInc);
                    tree.Enqueue(newNodeItemNotInc);
                }

            }
            return best;
        }

        /// <summary>
        /// Depth-first search of the tree.
        /// Stack (LIFO: Last In First Out)
        /// </summary>
        /// <returns> A node contains the best solution</returns>
        public Node DFS()
        {
            Node best = new Node();
            Stack<Node> tree = new Stack<Node>();
            tree.Push(new Node());
            while (tree.Any())
            {
                Node node = tree.Pop();
                // Goal check
                if (best.TotalValue < node.TotalValue && node.TotalWeight < maxWeight)
                {
                    best = node;
                }

                // If the max weight is reached, there's no need to keep looking
                if (node.TotalWeight < maxWeight && node.ViewedItem.Id != maxItems)
                {
                    // Node where the checked item is included and should be added to the weight and value calculations
                    Node newNodeItemInc = new Node(allItems[node.ViewedItem.Id], node, true);
                    // Node where the checked item isn't included, but kept as a way to know which layer we're working on
                    Node newNodeItemNotInc = new Node(allItems[node.ViewedItem.Id], node, false);
                    tree.Push(newNodeItemInc);
                    tree.Push(newNodeItemNotInc);
                }

            }
            return best;
        }

        /// <summary>
        /// Help function to display the BFS solution
        /// </summary>
        /// <param name="node"></param>
        public void DisplayBFSItems(Node node)
        {
            if (node.Parent != null)
                DisplayBFSItems(node.Parent);
            if (node.IsIncluded)
                Console.WriteLine($"Item:\t{node.ViewedItem.Id}\t {node.ViewedItem.Weight}\t {node.ViewedItem.Value}\twas included.");
        }

        /// <summary>
        /// Help function to display the DFS solution
        /// </summary>
        /// <param name="node"></param>
        public void DisplayDFSItems(Node node)
        {
            if (node.IsIncluded)
                Console.WriteLine($"Item:\t{node.ViewedItem.Id}\t {node.ViewedItem.Weight}\t {node.ViewedItem.Value}\twas included.");
            if (node.Parent != null)
                DisplayDFSItems(node.Parent);
        }

        #endregion Methods


    }
}
