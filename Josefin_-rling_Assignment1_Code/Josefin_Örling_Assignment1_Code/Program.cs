using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace Josefin_Örling_Assignment1_Code
{
    class Program
    {
        public static void Main()
        {
            
            List<Item> items = GetItems();

            Tree tree = new Tree(items);
            Console.WriteLine("The best combination for BFS:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Node bestBFS = tree.BFS();
            stopwatch.Stop();
            Console.WriteLine("Total weight: " + bestBFS.totalWeight);
            Console.WriteLine("Total value: " + bestBFS.totalValue);
            Console.WriteLine("BFS finished in " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine();
            Console.WriteLine("The best combination for DFS:");
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Node bestDFS = tree.DFS();
            stopwatch2.Stop();
            Console.WriteLine("Total weight: " + bestDFS.totalWeight);
            Console.WriteLine("Total value: " + bestDFS.totalValue);
            Console.WriteLine("DFS finished in " + stopwatch2.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }

        public static List<Item> GetItems()
        {
            int i = 1;
            List<Item> items = new List<Item>();
            StreamReader readFrom = new StreamReader("C:\\Users\\joxx1\\Source\\Repos\\j-orling\\Josefin_-rling_Assignment1_Code\\Josefin_Örling_Assignment1_Code\\Assignment 1 knapsack.txt");
            while(i < 8)
            {
                readFrom.ReadLine();
                i++;
            }
            while(i < 19)
            {
                string[] split = readFrom.ReadLine().Split();
                Item newItem = new Item(int.Parse(split[0]), int.Parse(split[2]), int.Parse(split[1]));
                items.Add(newItem);
                i++;
            }
            return items;
        }

    }
}
