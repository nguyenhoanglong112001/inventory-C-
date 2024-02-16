using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT27012024
{
    internal class Program
    {
        public static Item[] items = null;
        public static Player player = new Player("Player");
        public static Enemy enemy = new Enemy("Enemy");
        public static Hero[] heros = new Hero[] { player, enemy};
    public static Dictionary<ItemType, List<Item>> Itemclassify = new Dictionary<ItemType, List<Item>>();
        public static List<Item> itemlist = new List<Item>();
        static void Main(string[] args)
        {
            items = new Item[10];
            while (true)
            {
                int key = MainMenu();
                switch(key)
                {
                    case 1:
                        {
                            HeroGameMenu();
                            break;
                        }
                    case 2:
                        {
                            ItemGameMenu();
                            break;
                        }
                    case 3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        public static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("========Game 1 ============");
            Console.WriteLine("1. Hero manager");
            Console.WriteLine("2. Item manager");
            Console.WriteLine("3. Exit");
            int key = int.Parse(Console.ReadLine());
            return key;
        }
        public static void HeroGameMenu()
        {
            Console.Clear();
            Console.WriteLine("==========Hero Manager=============");
            Console.WriteLine("1. Show Hero information");
            Console.WriteLine("2. Equip item");
            Console.WriteLine("3. Back to main menu");

            int key = int.Parse(Console.ReadLine());
            switch(key)
            {
                case 1:
                    {
                        Showheroinfor();
                        break;
                    }
            }
        }

        public static void Showheroinfor()
        {
            Console.Clear();
            for (int i =0;i<heros.Length;i++)
            {
                if (heros[i] != null)
                    Console.WriteLine($"{i + 1}. {heros[i].heroname}");
            }
            Console.WriteLine("Choice hero to see detail: ");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                heros[0].HeroInfomation();
            }
            else
            {
                heros[1].HeroInfomation();
            }
            Console.ReadKey();
            
        }
        public static void ItemGameMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Inventory Manager=============");
            Console.WriteLine("Your gold: " + CurrencyManager.currentGold);
            Console.WriteLine("1. Create Item");
            Console.WriteLine("2. Show All Item");
            Console.WriteLine("3. Clasify Item");
            Console.WriteLine("4. Back to main menu");
            Console.WriteLine("chose function: ");
            int key = int.Parse(Console.ReadLine());

            switch (key)
            {
                case 1:
                    CreateItem();
                    break;
                case 2:
                    ShowAllItem();
                    break;
                case 3:
                    ClassifyItem();
                    break;
                case 4:
                    MainMenu() ;
                    break;
            }
        }

        public static void CreateItem()
        {
            Console.Clear();
            IITem<Item> inven = new Inventory<Item>();
            for (int i =0;i<items.Length;i++)
            {
                ItemType type = (ItemType)GameHelper.GetRandomValue(0, 4);
                Item newitem = inven.CreateITem($"{type}", type);
                items[i] = newitem;
                itemlist.Add(items[i]);
                if (!Itemclassify.ContainsKey(type))
                {
                    Itemclassify[type] = new List<Item>();
                }
                Itemclassify[type].Add(newitem);
                Console.WriteLine($"{i + 1} . {items[i].itemname}");
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
                ItemGameMenu();
            }
            else
            {
                items[key - 1].ShowItemInformation();
                Console.WriteLine("1. Sell Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Megre Item");
                Console.WriteLine("4. Back to menu");
                int Select = int.Parse (Console.ReadLine());
                if (Select == 4)
                {
                    ItemGameMenu();
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
                else if (Select == 3)
                {
                    items[key-1].ShowSameItem(key-1);
                    ShowAllItem();
                }
            }
        }

        public static void ClassifyItem()
        {
            Console.Clear();
            Dictionary<ItemType,int> itemcount = new Dictionary<ItemType,int>();
            
            foreach(var item in itemlist)
            {
                if(!itemcount.ContainsKey(item.type))
                {
                    itemcount[item.type] = 1;
                }
                else
                {
                    itemcount[item.type]++;
                }
            }

            foreach (var kvp in itemcount.Keys)
            {
                Console.WriteLine(kvp + ":" + itemcount[kvp]);
            }
            Console.WriteLine("Chosse to see list of item: ");
            Console.WriteLine("1: Sowrd  2: Bow  3: Amor   4:Staff");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                ShowItemClassify(ItemType.Sword);
            }
            else if (select == 2)
            {
                ShowItemClassify(ItemType.Bow);
            }
            else if (select == 3)
            {
                ShowItemClassify(ItemType.Amor);
            }
            else if (select == 4)
            {
                ShowItemClassify(ItemType.Staff);
            }
            else
            {
                ItemGameMenu();
            }
            Console.ReadKey();
        }

        public static void ShowItemClassify(ItemType typeclass)
        {
            Console.Clear();
            foreach (var item in Itemclassify[typeclass]) 
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Name: " + item.itemname);
                Console.WriteLine("rarity: " + item.rarity);
            }
        }
    }
}
