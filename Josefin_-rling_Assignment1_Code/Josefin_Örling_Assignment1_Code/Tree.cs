using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    class Tree
    {
        public List<Item> allItems;
        public int maxWeight = 420;

        public Tree(List<Item> items)
        {
            allItems = items;
        }
        // Breadth-first
        public Node BFS()
        {
            // Two nodes - one for keeping track of the best solution, one for enqueueing an empty root
            Node best = new Node();
            Node root = new Node();
            // Queue, since BFS uses FIFO
            Queue<Node> tree = new Queue<Node>();
            tree.Enqueue(root);
            while(tree.Any())
            {
                Node n = tree.Dequeue();
                // Goal check
                if(best.totalValue < n.totalValue && n.totalWeight < maxWeight)
                {
                    // Copy all values of current node to the best one to save it in memory
                    best.totalValue = n.totalValue;
                    best.totalWeight = n.totalWeight;
                    best.isIncluded = n.isIncluded;
                    best.viewedItem = n.viewedItem;
                    best.parent = n.parent;
                }
                
                // No need to add more nodes to a branch that already exceeded the weight limit
                // No new items to add after item 11
                if(n.totalWeight < maxWeight && n.viewedItem.id != 11)
                {
                    // Two new nodes to enqueue, one with the item and one without
                    Node newNodeItemInc = new Node(allItems[n.viewedItem.id], n, true);
                    // Item id helps keep track of which layer we're operating at
                    Node newNodeItemNotInc = new Node(allItems[n.viewedItem.id], n, false);
                    tree.Enqueue(newNodeItemInc);
                    tree.Enqueue(newNodeItemNotInc);
                }

            }
            // Display all the packed items
            DisplayItems(best);
            return best;
        }

        // Depth-first
        public Node DFS()
        {
            // Two empty nodes - one for saving the best solution, and one to have as an empty root
            Node best = new Node();
            Node root = new Node();
            // Stack, since DFS uses LIFO
            Stack<Node> tree = new Stack<Node>();
            tree.Push(root);
            while (tree.Any())
            {
                Node n = tree.Pop();
                // Goal check
                if (best.totalValue < n.totalValue && n.totalWeight < maxWeight)
                {
                    // Copy over all the values of the current node to the best to save it in memory
                    best.totalValue = n.totalValue;
                    best.totalWeight = n.totalWeight;
                    best.isIncluded = n.isIncluded;
                    best.viewedItem = n.viewedItem;
                    best.parent = n.parent;
                }

                // If the max weight is reached, there's no need to keep looking
                // The last layer doesn't need any children - there's nothing left to push
                if (n.totalWeight < maxWeight && n.viewedItem.id != 11)
                {
                    // Node where the checked item is included and should be added to the weight and value calculations
                    Node newNodeItemInc = new Node(allItems[n.viewedItem.id], n, true);
                    // Node where the checked item isn't included, but kept as a way to know which layer we're working on
                    Node newNodeItemNotInc = new Node(allItems[n.viewedItem.id], n, false);
                    tree.Push(newNodeItemInc);
                    tree.Push(newNodeItemNotInc);
                }

            }
            // Iterate through all added items and display them
            DisplayItems(best);
            return best;
        }

        // Help function to display the optimal solution
        public void DisplayItems(Node node)
        {
            if(node.parent != null)
            {
                DisplayItems(node.parent);
            }
            if(node.isIncluded)
            {
                Console.WriteLine("Item " + node.viewedItem.id + " with weight " + node.viewedItem.weight + " and value " + node.viewedItem.value + " was included.");
            }
        }

    }
}
