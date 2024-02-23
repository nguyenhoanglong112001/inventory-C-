using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GameConstant
    {
        public static Dictionary<Rarity, int> itemgold = new Dictionary<Rarity, int> { { Rarity.Common, 100 }, { Rarity.Rare, 150 }, { Rarity.Epic, 200 }, { Rarity.Legendary, 250 }, { Rarity.Mystical, 400 } };
        public static Dictionary<Rarity, int> goldupdate = new Dictionary<Rarity, int>
        {
            {Rarity.Common,150 },
            {Rarity.Rare,200 },
            {Rarity.Epic,250 },
            {Rarity.Legendary,300 },
            {Rarity.Mystical,500 }
        };
    }
}
