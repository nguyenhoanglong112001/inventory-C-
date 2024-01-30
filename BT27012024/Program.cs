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

        static void Main(string[] args)
        {
            items = new Item[10];
            while (true)
            {
                int key = GameMenu();
                switch (key)
                {
                    case 1:
                        CreateItem();
                        break;
                    case 2:
                        ShowAllItem();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.ReadKey();
        }
        public static int GameMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Inventory Manager=============");
            Console.WriteLine("Your gold: " + CurrencyManager.currentGold);
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
                        newitem = new Sword("Sword", itemtype);
                        break;
                    case ItemType.Bow:
                        newitem = new Bow("Bow", itemtype);
                        break;
                    case ItemType.Amor:
                        newitem = new Amor("Amor", itemtype);
                        break;
                    case ItemType.Staff:
                        newitem = new Staff("Staff", itemtype);
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
                if (items[i] != null)
                {
                    Console.WriteLine($"{i + 1}.{items[i].itemname}");
                }
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
                Console.WriteLine("1. Sell Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Back to menu");
                int Select = int.Parse (Console.ReadLine());
                if (Select == 3)
                {
                    GameMenu();
                }
                else if (Select == 1)
                {
                    items[key - 1].SellItem(key-1);
                    ShowAllItem();
                }
                else if (Select == 2)
                {
                    items[key - 1].OnUpdateITem();
                    ShowAllItem();
                }
            }
        }
        
    }
}
