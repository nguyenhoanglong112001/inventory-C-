using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public class Player : Hero
    {
        public int currentexp = 0;   
        public Player(string heroname) : base(heroname)
        {
        }
        public override void HeroInfomation()
        {
            Checklevel();
            Console.WriteLine($"Exp: {currentexp} / {EXPmanager.exptolevelup}");
            base.HeroInfomation();
        }
        public void Checklevel()
        {
            if (currentexp != EXPmanager.exptolevelup) 
            {
                return;
            }
            Levelup();
        }
        public void Levelup()
        {
            level++;
            IncreaseAgi += 5;
            IncreaseAmor += 0.2;
            IncreaseDame += 3;
            IncreaseHP += 40;
            IncreaseIntel += 2;
            IncreaseMana += 30;
            IncreaseSpeed += 0.5;
            IncreaseStr += 4;
            currentexp = 0;
            LoadheroIncreaseAtribute();
            heroatributebytype();
        }

    }
}
