using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT27012024
{
    public class Inventory<T> : IITem<T> where T:Item
    {
        public T CreateITem(string itemname, ItemType Type)
        {
            switch(Type)
            {
                case ItemType.Sword:
                {
                    return (T)(object) new Sword(itemname,Type);
                }
                case ItemType.Bow:
                {
                    return (T)(object)new Bow(itemname, Type);
                }
                case ItemType.Amor:
                {
                    return (T)(object)new Amor(itemname, Type);
                }
                case ItemType.Staff:
                {
                    return (T)(object)new Staff(itemname, Type);
                }
                default:
                    throw new NotImplementedException();
            }
        }
        public static void CreateItem()
        {
            Console.Clear();
            IITem<Item> inven = new Inventory<Item>();
            for (int i = 0; i < Program.items.Length; i++)
            {
                ItemType type = (ItemType)GameHelper.GetRandomValue(0, 4);
                Item newitem = inven.CreateITem($"{type}", type);
                Program.items[i] = newitem;
                Program.itemlist.Add(Program.items[i]);
                if (!Program.Itemclassify.ContainsKey(type))
                {
                    Program.Itemclassify[type] = new List<Item>();
                }
                Program.Itemclassify[type].Add(newitem);
                Console.WriteLine($"{i + 1} . {Program.items[i].itemname}");
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }
        public static void ClassifyItem()
        {
            Console.Clear();
            Dictionary<ItemType, int> itemcount = new Dictionary<ItemType, int>();

            foreach (var item in Program.itemlist)
            {
                if (!itemcount.ContainsKey(item.type))
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
                UImanager.ShowItemClassify(ItemType.Sword);
            }
            else if (select == 2)
            {
                UImanager.ShowItemClassify(ItemType.Bow);
            }
            else if (select == 3)
            {
                UImanager.ShowItemClassify(ItemType.Amor);
            }
            else if (select == 4)
            {
                UImanager.ShowItemClassify(ItemType.Staff);
            }
            else
            {
                UI.ItemMenu();
            }
            Console.ReadKey();
        }
    }
}
