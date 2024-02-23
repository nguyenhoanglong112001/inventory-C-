using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class UI
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("========Game 1 ============");
            Console.WriteLine("1. Hero manager");
            Console.WriteLine("2. Item manager");
            Console.WriteLine("3. Start Game");
            Console.WriteLine("4. Exit");
            int key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    {
                        HeroMenu();
                        break;
                    }
                case 2:
                    {
                        ItemMenu();
                        break;
                    }
                case 3:
                    {
                        Program.Battle(Program.player);
                        break;
                    }
                case 4:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        public static void HeroMenu()
        {
            Console.Clear();
            Console.WriteLine("==========Hero Manager=============");
            Console.WriteLine("1. Show Hero information");
            Console.WriteLine("2. Equip item");
            Console.WriteLine("3. Back to main menu");

            int key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    {
                        UImanager.Showheroinfor();
                        break;
                    }
                case 2:
                    {
                        UImanager.ShowAllItem();
                        break;
                    }
            }
        }
        public static void ItemMenu()
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
                    Inventory<Item>.CreateItem();
                    break;
                case 2:
                    UImanager.ShowAllItem();
                    break;
                case 3:
                    Inventory<Item>.ClassifyItem();
                    break;
                case 4:
                    MainMenu();
                    break;
            }
        }
        public static int ShowItemdetail()
        {
            Console.WriteLine("1. Sell Item");
            Console.WriteLine("2. Update Item");
            Console.WriteLine("3. Megre Item");
            Console.WriteLine("4. Use Item");

            Console.WriteLine("5. Back to menu");
            int Select = int.Parse(Console.ReadLine());
            return Select;
        }

        public static int UpdateItemMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Update rarity");
            Console.WriteLine("2. Update level");
            Console.WriteLine("Choose function: ");
            int key = int.Parse(Console.ReadLine());
            return key;
        }
    }
}

