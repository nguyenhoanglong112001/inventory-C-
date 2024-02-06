using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT27012024
{
    public enum HeroType
    {
        Agility,
        Strength,
        Intelligence,
        Universal
    }
    public class Hero
    {
        public string heroname;
        public HeroType herotype;
        public double BaseDame { get; protected set; } = 50;
        public int BaseHealth { get; protected set; } = 300;
        public int BaseMana { get; protected set; } = 200;
        public double BaseSpeed { get; protected set; } = 10;
        public double BaseAmor { get; protected set; } = 3;
        public int agility { get; protected set; }
        public int strength { get; protected set; }
        public int intelligence { get; protected set; }

        public Hero() { }

        public Hero(string heroname)
        {
            this.heroname = heroname;
            herotype = (HeroType)GameHelper.GetRandomValue(0, 4);
            agility = GameHelper.GetRandomValue(0, 81);
            strength = GameHelper.GetRandomValue(0, 81);
            intelligence = GameHelper.GetRandomValue(0, 81);
        }

        public void heroatribute()
        {
            if (herotype == HeroType.Agility)
            {
                BaseDame += agility;
                BaseAmor += 0.14 * agility;
                BaseSpeed += agility;
            }
            if (herotype == HeroType.Strength)
            {
                BaseHealth += 19 * strength;
                BaseDame += strength;
            }
            if (herotype == HeroType.Intelligence)
            {
                BaseDame += intelligence;
                BaseMana += intelligence;
            }
            if (herotype == HeroType.Universal)
            {
                BaseDame += 0.4 * (strength + agility + intelligence);
            }
        }
    }
}
