using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class Enemy : Hero
    {
        public Enemy(string heroname,Player player) : base(heroname)
        {
            level = Randomlevel(player.level);
        }
        public int Randomlevel(int playerLevel)
        {
            Random r = new Random();
            return r.Next(1,playerLevel+2);
        }
    }
}
