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

        public Item() { }

        public Item(string itemname,ItemType type)
        {
            this.itemname = itemname;
            this.type = type;
            int rt = GameHelper.GetRandomValue(0, 101); 
            if(rt <= 1)
            {
                this.rarity = (Rarity)4;
            }
            if (rt<= 6 && rt>1)
            {
                this.rarity = (Rarity)3;
            }
            if (rt <= 16 && rt > 6)
            {
                this.rarity = (Rarity)2;
            }
            if (rt <= 41 && rt >16)
            {
                this.rarity = (Rarity)1;
            }
            if (rt <= 100 && rt > 41)
            {
                this.rarity = (Rarity)0;
            }
        }

        public void ShowItemInformation()
        {
            Console.Clear();
            Console.WriteLine("========Item infomation ========");
            Console.WriteLine("Item name: " + itemname);
            Console.WriteLine("Type: " + type.ToString());
            Console.WriteLine("Rarity: " + rarity.ToString());
            Console.ReadKey();
        }
    }
}
