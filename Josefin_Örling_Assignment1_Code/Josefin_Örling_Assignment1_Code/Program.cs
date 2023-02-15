using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    class Program
    {
        public static void Main()
        {
            
            List<Item> items = GetItems();

            Tree tree = new Tree(items);
            Node best = tree.BFS();

            Console.WriteLine("The resulting weight was " + best.totalWeight + " and the total value was " + best.totalValue);
            Console.ReadLine();
        }

        public static List<Item> GetItems()
        {
            int i = 1;
            List<Item> items = new List<Item>();
            StreamReader readFrom = new StreamReader("C:\\Users\\joxx1\\source\\repos\\ai\\Josefin_Örling_Assignment1_Code\\Josefin_Örling_Assignment1_Code\\Assignment 1 knapsack.txt");
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
