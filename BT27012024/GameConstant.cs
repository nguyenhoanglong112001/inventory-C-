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
        public static int[] ItemGold = new int[] { 100, 150, 200, 250, 400 };
        public static int[] goldtoUpdate = new int[] { 150, 200, 250, 300, 500 };
    }
}
