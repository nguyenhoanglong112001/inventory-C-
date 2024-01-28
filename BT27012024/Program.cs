using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    internal class Program
    {
        public static Item[] items = null;
        public static int[] ConfigItemgold = null;
        public static int[] CofigItemgoldUpgrade = null;
        static void Main(string[] args)
        {
            items = new Item[10];
            ConfigItemgold = new int[] {100,150,200,250,400};
            CofigItemgoldUpgrade = new int[] { 150, 200, 250, 300, 500 };

            while (true)
            {
                int key = GameMenu();
                switch(key)
                {

                }
            }
            Console.ReadKey();
        }
        public static int GameMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Inventory Manager=============");
            Console.WriteLine("1. Create Item");
            Console.WriteLine("2. Show All Item");
            Console.WriteLine("3. Exit");
            Console.WriteLine("chose function: ");
            int key = int.Parse(Console.ReadLine());

            return key;
        }
    }
}
