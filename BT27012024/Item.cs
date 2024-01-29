using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public enum ItemType
    {
        Sword,
        Bow,
        Amor,
        Staff
    }

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Mystical
    }
    public class Item
    {
        public string itemname;
        public Rarity rarity;
        public ItemType type;
        public int price;

        public Item() { }

        public Item(string itemname,ItemType type)
        {
            this.itemname = itemname;
            this.type = type;
            int rt = GameHelper.GetRandomValue(0, 101);
            if(rt <= 1)
            {
                this.rarity = (Rarity)4;
                this.price = 400;
            }
            if (rt<= 6 && rt>1)
            {
                this.rarity = (Rarity)3;
                this.price = 250;
            }
            if (rt <= 16 && rt > 6)
            {
                this.rarity = (Rarity)2;
                this.price = 200;
            }
            if (rt <= 41 && rt >16)
            {
                this.rarity = (Rarity)1;
                this.price = 150;
            }
            if (rt <= 100 && rt > 41)
            {
                this.rarity = (Rarity)0;
                this.price = 100;
            }
        }

        public void ShowItemInformation()
        {
            Console.Clear();
            Console.WriteLine("========Item infomation ========");
            Console.WriteLine("Item name: " + itemname);
            Console.WriteLine("Type: " + type.ToString());
            Console.WriteLine("Rarity: " + rarity.ToString());
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Do you want to sell this item?");
            int key = int.Parse(Console.ReadLine());
            if (key == 0)
            {
                Program.ShowAllItem();
            }
            else
            {
                SellItem();
            }
            Console.ReadKey();
        }
        
        public int SellItem()
        {
            return CurrencyManager.currentGold += price;
        }
    }
}
