using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                    case 1:
                        CreateItem();
                        break;
                    case 2:
                        ShowAllItem();
                        break;
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

        public static void CreateItem()
        {
            Console.Clear();
            for (int i =0;i<items.Length;i++)
            {
                ItemType itemtype = (ItemType)GameHelper.GetRandomValue(0, 4);
                Item newitem = null;
                switch (itemtype)
                {
                    case ItemType.Sword:
                        newitem = new Item("Sword", itemtype);
                        break;
                    case ItemType.Bow:
                        newitem = new Item("Bow", itemtype);
                        break;
                    case ItemType.Amor:
                        newitem = new Item("Amor", itemtype);
                        break;
                    case ItemType.Staff:
                        newitem = new Item("Staff", itemtype);
                        break;
                }
                items[i] = newitem;
                Console.WriteLine($"{i + 1}.{items[i].itemname}");
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }

        public static void ShowAllItem()
        {
            Console.Clear();
            Console.WriteLine("=======List items=======");
            for (int i =0;i<items.Length;i++)
            {
                Console.WriteLine($"{i + 1}.{items[i].itemname}");
            }
            Console.WriteLine("Choose 1 item to see detail: ");
            int key = int.Parse(Console.ReadLine());
            if (key == 0)
            {
                GameMenu();
            }
            else
            {
                items[key - 1].ShowItemInformation();
            }
        }
    }
}
