using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Josefin_Örling_Assignment1_Code
{
    public class Test
    {
        #region Fields
        /// <summary>
        /// Declare an Insatnce of Tree
        /// </summary>
        Tree tree;
        /// <summary>
        /// Declare an instance of PerformanceCounter 
        /// </summary>
        PerformanceCounter Cpu;
        /// <summary>
        /// Declare an instance of PerformanceCounter 
        /// </summary>
        PerformanceCounter Ram;

        /// <summary>
        /// Declare an instance of StopWatch for BFS
        /// </summary>
        Stopwatch StopWatchBFS;

        /// <summary>
        /// Declare an instance of StopWatch for DFS
        /// </summary>
        Stopwatch StopWatchDFS;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// constructor with one parameters 
        /// </summary>
        /// <param name="size">the size of items in the list</param>
        public Test(int size)
        {
            (List<Item> items, int maxWeight) = InitializeItems(size);
            tree = new Tree(items, maxWeight, size);
            Cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            Ram = new PerformanceCounter("Memory", "Available MBytes");
            StopWatchBFS = new Stopwatch();
            StopWatchDFS = new Stopwatch();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method that initializes the items.
        /// </summary>
        /// <returns></returns>
        private (List<Item>, int) InitializeItems(int size)
        {
            List<Item> items = new List<Item>();
            Random rnd = new Random();
            for (int i = 1; i <= size; i++)
            {
                items.Add(new Item(i, rnd.Next(1, 100), rnd.Next(1, 100)));
            }
      
            double SumWeight = items.Sum(x => x.Weight);
            int maxWeight = (int)(SumWeight * 0.6);
            Console.WriteLine("Id\tWeight\tValue\n");
            Console.WriteLine(String.Join("\n", items.Select(x => $"{x.Id}\t{x.Weight}\t{x.Value}")));
            Console.WriteLine($"Total weight: {SumWeight} Max weight: " + maxWeight);
            return (items, maxWeight);
        }

        /// <summary>
        /// Method to test the breadth-first search and depth-first search 
        /// and measure the time it takes to run them.
        /// Calls the methods MeasureBFS and MeasureDFS.
        /// </summary>
        public void Run()
        {
            MeasureBFS();
            MeasureDFS();
        }

        /// <summary>
        /// Method to measure the time, memory and CPU that it takes to run the BFS algorithm
        /// </summary>
        private void MeasureBFS()
        {
            float cpuBFSStart = Cpu.NextValue();
            long ramBFSStart = Ram.RawValue;
            StopWatchBFS.Start();
            Node bestBFS = tree.BFS();
            StopWatchBFS.Stop();
            float cpuBFSEnd = Cpu.NextValue();
            long ramBFSEnd = Ram.RawValue;
            Print(bestBFS, StopWatchBFS.Elapsed, cpuBFSEnd - cpuBFSStart, ramBFSStart - ramBFSEnd, "BFS");
        }

        /// <summary>
        /// Method to measure the time, memory and CPU that it takes to run the DFS algorithm
        /// </summary>
        private void MeasureDFS()
        {
            float cpuDFSStart = Cpu.NextValue();
            long ramDFSStart = Ram.RawValue;
            StopWatchDFS.Start();
            Node bestDFS = tree.DFS();
            StopWatchDFS.Stop();
            float cpuDFSEnd = Cpu.NextValue();
            long ramDFSEnd = Ram.RawValue;
            Print(bestDFS, StopWatchDFS.Elapsed, cpuDFSEnd - cpuDFSStart, ramDFSStart - ramDFSEnd, "DFS");
        }
        
        /// <summary>
        /// Prints the results
        /// </summary>
        /// <param name="node"></param>
        /// <param name="ts"></param>
        /// <param name="cpu"></param>
        /// <param name="ram"></param>
        /// <param name="alg"></param>
        private void Print(Node node, TimeSpan ts, float cpu, long ram, string alg)
        {
            Console.WriteLine($"\nThe best combination for {alg} starting...");
            Console.WriteLine("*********************************************");
            Console.WriteLine("\tId\tWeight\tValue\t\n");
            if (alg == "DFS")
                tree.DisplayDFSItems(node);
            else
                tree.DisplayBFSItems(node);
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"Total:\t\t({node.TotalWeight})\t({node.TotalValue})");
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"Minutes:({ts.Minutes}), seconds:({ts.Seconds}), milliseconds:({ts.Milliseconds}), " +
            $"microsecond:({ts.Microseconds}), nanosecond: ({ts.Nanoseconds}).");
            Console.WriteLine($"{alg} finished in: {(ts.Minutes * 6000) + (ts.Seconds * 1000) + ts.Milliseconds} ms.");
            Console.WriteLine($"CPU usage: {cpu}%\nRAM usage: {ram} MB");
            Console.WriteLine("*********************************************");
        }

        #endregion Methods
    }
}
