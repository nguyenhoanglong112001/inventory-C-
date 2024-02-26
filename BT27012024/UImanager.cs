using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class UImanager
    {
        public static void Showheroinfor()
        {
            Console.Clear();
            Program.player.HeroInfomation();
            //Doan code duoi su dung khi co nhieu hon 1 player:
            //for (int i = 0; i < Program.heroes.Count; i++)
            //{
            //    if (Program.heroes[i] != null)
            //        Console.WriteLine($"{i + 1}. {Program.heroes[i].Heroname}");
            //}
            //Console.WriteLine("Choice hero to see detail: ");
            //int select = int.Parse(Console.ReadLine());
            //if (select == 1)
            //{
            //    Program.heroes[0].HeroInfomation();
            //}
            //else
            //{
            //    Program.heroes[1].HeroInfomation();
            //}
            Console.ReadKey();
        }
        public static void ShowAllItem()
        {
            Console.Clear();
            Console.WriteLine("=======List items=======");
            for (int i = 0; i < Program.items.Length; i++)
            {
                if (Program.items[i] != null)
                {
                    Console.WriteLine($"{i + 1}.{Program.items[i].itemname}");
                }
            }
            Console.WriteLine("Choose 1 item to see detail: ");
            int key = int.Parse(Console.ReadLine());
            if (key == 0)
            {
                UI.ItemMenu();
            }
            else
            {
                UImanager.ShowItemInformation(Program.items[key-1]);
                int Select = UI.ShowItemdetail();
                if (Select == 5)
                {
                    UI.ItemMenu();
                }
                else if (Select == 1)
                {
                    Program.items[key - 1].SellItem(key - 1);
                    UImanager.ShowAllItem();
                }
                else if (Select == 2)
                {
                    int choice = UI.UpdateItemMenu();
                    switch (choice)
                    {
                        case 1:
                            {
                                OnUpdateITem(Program.items[key -1]);
                                break;
                            }
                        case 2:
                            {
                                Onupdatelv(Program.items[key - 1]);
                                break;
                            }
                    }
                }
                else if (Select == 3)
                {
                    ShowSameItem(key - 1, Program.items[key - 1]);
                    UImanager.ShowAllItem();
                }
                else if (Select == 4)
                {
                    Console.Clear();
                    Program.player.UseItem(Program.items[key - 1]);
                    Console.WriteLine($"Use {Program.items[key - 1].itemname} on {Program.player.Heroname}");
                    //Doan code duoi su dung khi co nhieu hon 1 player:
                    //Console.WriteLine("Choose hero to use item on: ");
                    //int inhero = int.Parse(Console.ReadLine());
                    //Program.heroes[inhero - 1].UseItem(Program.items[key - 1]);
                    //Console.WriteLine($"Use {Program.items[key - 1].itemname} on {Program.heroes[inhero - 1].Heroname}");
                    Console.ReadKey();
                }
            }
        }
        public static void ShowItemClassify(ItemType typeclass)
        {
            Console.Clear();
            foreach (var item in Program.Itemclassify[typeclass])
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Name: " + item.itemname);
                Console.WriteLine("rarity: " + item.rarity);
            }
        }

        public static void ShowItemInformation(Item item)
        {
            Console.Clear();
            Console.WriteLine("========Item infomation ========");
            Console.WriteLine("Item name: " + item.itemname);
            Console.WriteLine("Level: " + item.level);
            Console.WriteLine("Type: " + item.type.ToString());
            Console.WriteLine("Rarity: " + item.rarity.ToString());
            Console.WriteLine("Price: " + GameConstant.itemgold[item.rarity]);
            Console.ReadKey();
        }
        public static void ShowSameItem(int currentindex,Item item)
        {
            Console.Clear();
            Console.WriteLine("======List of same item========");
            for (int i = 0; i < Program.items.Length; i++)
            {
                if (Program.items[i] != null && i != currentindex)
                {
                    if (Program.items[i].type == item.type && Program.items[i].rarity == item.rarity)
                    {
                        Console.WriteLine($"{i + 1}. {Program.items[i].itemname}");
                    }
                }
            }
            Console.WriteLine("Choose item to megre: ");
            int itemindex = int.Parse(Console.ReadLine());
            if (Program.items[currentindex].rarity == Rarity.Mystical)
            {
                Console.WriteLine("Item has highest rarity. Can not merge to update");
                UImanager.ShowAllItem();
            }
            else
            {
                Program.items[currentindex].rarity = (Rarity)(int)item.rarity +1;
                Console.WriteLine($"{Program.items[currentindex].itemname} merge with {Program.items[itemindex - 1].itemname} update to {item.rarity}");
                Program.items[itemindex - 1] = null;
            }
            Console.ReadKey();
        }
        public static bool CanUpdate(Item item)
        {
            if (item.rarity == Rarity.Mystical)
            {
                Console.WriteLine("Item has highest rarity. Can not update");
                Console.ReadKey();
                return false;
            }

            if (CurrencyManager.currentGold < GameConstant.goldupdate[item.rarity + 1])
            {
                Console.WriteLine("Not enough gold");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public static void OnUpdateITem(Item item)
        {
            if (!CanUpdate(item))
            {
                return;
            }
            item.Doupdate();
            CurrencyManager.currentGold -= GameConstant.goldupdate[item.rarity];
            Console.WriteLine($"{item.itemname} update to {item.rarity}");
            Console.ReadKey();
        }
        public static bool CanUpdatelv()
        {
            if (CurrencyManager.currentGold < GameConstant.goldtopuplv)
            {
                Console.WriteLine("Not enough gold");
                Console.ReadKey();
                return false;
            }
            CurrencyManager.currentGold -= GameConstant.goldupdate[item.rarity];
            return true;
        }
        public static void Onupdatelv(Item item)
        {
            if (!CanUpdatelv())
            {
                return;
            }
            item.DoUpdateLv();
            CurrencyManager.currentGold -= GameConstant.goldtopuplv;
            Console.WriteLine($"{item.itemname} update to {item.level}");
            Console.ReadKey();
        }
    }
}
