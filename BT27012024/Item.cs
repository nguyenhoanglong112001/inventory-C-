using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
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
            Console.WriteLine("Price: " + GameConstant.ItemGold[(int)rarity]);
            Console.ReadKey();
        }
        
        public void SellItem(int sellIndex)
        {
            for (int i = 0;i<Program.items.Length;i++)
            {
                if (sellIndex == i)
                {
                    CurrencyManager.currentGold += GameConstant.ItemGold[(int)rarity]; 
                    Program.items[i] = null;
                    break;
                }
            }
            Console.WriteLine("Sell item success");
            Console.WriteLine("Your current gold: " + CurrencyManager.currentGold);
            Console.ReadKey();
        }

        public bool CanUpdate()
        {
            if (rarity == Rarity.Mystical)
            {
                Console.WriteLine("Item has highest rarity. Can not update");
                Console.ReadKey();
                return false;
            }

            if (CurrencyManager.currentGold < GameConstant.goldtoUpdate[(int)rarity + 1])
            {
                Console.WriteLine("Not enough gold");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public void OnUpdateITem()
        {
            if (!CanUpdate())
            {
                return;
            }
            Doupdate();
            Console.ReadKey();
        }
        public void Doupdate()
        {
            rarity = (Rarity)(int)rarity + 1;
            CurrencyManager.currentGold -= GameConstant.goldtoUpdate[(int)rarity];
            Console.WriteLine($"{itemname} update to {rarity}");
            Console.ReadKey();
        }

        public void MegreItem()
        {

        }
    }
}
