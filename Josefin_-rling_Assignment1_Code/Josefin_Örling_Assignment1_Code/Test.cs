using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Josefin_Örling_Assignment1_Code
{
    public class Test
    {
        /// <summary>
        /// the capacity of the bag
        /// </summary>
        private readonly static int maxWeight = 20;

        /// <summary>
        /// the number of items to be included in the bag 
        /// </summary>
        private readonly static int maxItems = 11;

        #region Methods
        /// <summary>
        /// Method that initializes the items.
        /// </summary>
        /// <returns></returns>
        private static List<Item> InitializeItems()
        {
            List<Item> items = new List<Item>();
            Random rnd = new Random();
            for (int i = 1; i <= maxItems; i++)
            {
                items.Add(new Item(i, rnd.Next(1, 100), rnd.Next(1, 100)));
            }
            return items;
        }

        /// <summary>
        /// Method to test the breadth-first search and depth-first search 
        /// and measure the time it takes to run them.
        /// </summary>
        public static void Run()
        {
            //List<Item> items = GetItems();
            List<Item> items = InitializeItems();
            Console.WriteLine(String.Join("\n", items.Select(x => $"{x.Id}\t{x.Weight}\t{x.Value}")));
            Tree tree = new Tree(items, maxWeight, maxItems);

            // Measure the time it takes to run the BFS algorithm
            Stopwatch StopWatchBFS = new Stopwatch();
            StopWatchBFS.Start();
            Node bestBFS = tree.BFS();
            StopWatchBFS.Stop();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine($"The best combination for BFS starting...");
            tree.DisplayItems(bestBFS);
            TimeSpan ElapsedSpanBFS = StopWatchBFS.Elapsed;
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"Total:\t\t({bestBFS.TotalWeight})\t({bestBFS.TotalValue})");
            Console.WriteLine($"---------------------------------------------");
            // Console.WriteLine($"BFS: Total weight: {bestBFS.TotalWeight} Total value: {bestBFS.TotalValue} ");
            Console.WriteLine($"minutes:({ElapsedSpanBFS.Minutes}), seconds:({ElapsedSpanBFS.Seconds}), milliseconds:({ElapsedSpanBFS.Milliseconds}), Microsecond:({ElapsedSpanBFS.Microseconds}), Nanosecond: ({ElapsedSpanBFS.Nanoseconds}).");
            Console.WriteLine($"BFS finished in: {(ElapsedSpanBFS.Minutes * 6000) + (ElapsedSpanBFS.Seconds * 1000) + ElapsedSpanBFS.Milliseconds} ms.");

            // Measure the time it takes to run the DFS algorithm
            Stopwatch StopWatchDFS = new Stopwatch();
            StopWatchDFS.Start();
            Node bestDFS = tree.DFS();
            StopWatchDFS.Stop();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine($"The best combination for DFS starting...");
            tree.DisplayItems(bestDFS);
            TimeSpan ElapsedSpanDFS = StopWatchDFS.Elapsed;
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"Total:\t\t({bestDFS.TotalWeight})\t({bestDFS.TotalValue})");
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"minutes:({ElapsedSpanDFS.Minutes}), seconds:({ElapsedSpanDFS.Seconds}), milliseconds:({ElapsedSpanDFS.Milliseconds}), Microsecond:({ElapsedSpanDFS.Microseconds}), Nanosecond: ({ElapsedSpanDFS.Nanoseconds}).");
            Console.WriteLine($"DFS finished in: {(ElapsedSpanDFS.Minutes * 6000) + (ElapsedSpanDFS.Seconds * 1000) + ElapsedSpanDFS.Milliseconds} ms.");
        }

        /// <summary>
        /// Get items from file
        /// </summary>
        /// <returns></returns>
        public static List<Item> GetItems()
        {
            int i = 1;
            List<Item> items = new List<Item>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            StreamReader readFrom = new StreamReader($"{path.Substring(0, path.LastIndexOf("\\bin"))}\\Assignment 1 knapsack.txt");
            while (i < 8)
            {
                readFrom.ReadLine();
                i++;
            }
            while (i < 19)
            {
                string[] split = readFrom.ReadLine().Split();
                Item newItem = new Item(int.Parse(split[0]), int.Parse(split[2]), int.Parse(split[1]));
                items.Add(newItem);
                i++;
            }
            return items;
        }
        #endregion Methods
    }
}
