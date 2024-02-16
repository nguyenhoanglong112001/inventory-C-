using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public double Dame => BaseDame + increaseDame;
        public double BaseHealth { get; protected set; } = 300;

        public double Hp => BaseHealth + increaseHP;
        public double BaseMana { get; protected set; } = 200;
        public double MP => BaseMana + increaseMana;
        public double BaseSpeed { get; protected set; } = 10;
        public double speed => BaseSpeed + increaseSpeed;
        public double BaseAmor { get; protected set; } = 3;

        public double Amor => BaseAmor + increaseAmor;
        public int agility { get; protected set; }

        public int agi => agility + increaseagi;
        public int strength { get; protected set; }
        public int str => strength + increasestr;
        public int intelligence { get; protected set; }

        public int intel => intelligence + increaseintel;
        public Item itemuse;
        public bool Alive => BaseHealth > 0;

        public double increaseHP { get; protected set; }
        public double increaseMana { get;protected set; }
        public double increaseSpeed { get;protected set; }
        public double increaseDame { get;protected set; }
        public double increaseAmor { get;protected set; }
        public int increaseagi {  get;protected set; }
        public int increasestr {  get;protected set; }
        public int increaseintel {  get;protected set; }

        public Hero() { }

        public Hero(string heroname)
        {
            this.heroname = heroname;
            herotype = (HeroType)GameHelper.GetRandomValue(0, 4);
            agility = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseSpeed = BaseSpeed + agility * 1;
            BaseAmor = BaseAmor + agility * 0.14;
            strength = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseHealth = BaseHealth + strength * 19;
            intelligence = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseMana = BaseMana + intelligence * 13;
            heroatribute();
        }

        public void TakeDame(Hero target)
        {
            if (!Alive)
            {
                return;
            }
            BaseHealth -= target.BaseDame*(100/(100+BaseAmor));
        }

        public void Attack(Hero target)
        {
            if (!Alive)
            {
                return;
            }
            target.TakeDame(this);
        }
        public void heroatribute()
        {
            if (herotype == HeroType.Agility)
            {
                BaseDame += agility;
            }
            if (herotype == HeroType.Strength)
            {
                BaseDame += strength;
            }
            if (herotype == HeroType.Intelligence)
            {
                BaseDame += intelligence;
            }
            if (herotype == HeroType.Universal)
            {
                BaseDame += 0.4 * (strength + agility + intelligence);
            }
        }

        public void HeroInfomation()
        {
            Console.WriteLine("Name: " + heroname);
            Console.WriteLine("Hero type: " + herotype);
            Console.WriteLine("agility: " + agi);
            Console.WriteLine("strength: " + str);
            Console.WriteLine("intelligence: " + intel);
            Console.WriteLine("Health: " + Hp);
            Console.WriteLine("Mana: " + MP);
            Console.WriteLine("Attack Dame: " + Dame);
            Console.WriteLine("Attack Speed: " + speed);
            Console.WriteLine("Amor: " + Amor);
            Console.ReadKey();
        }

        public void UseItem(Item item)
        {
            if (itemuse == null)
            {
                itemuse = item;
            }
            ReloadAtribute();
            
        }

        public void ReloadAtribute()
        {
            switch(itemuse.type)
            {
                case ItemType.Sword:
                    {
                        increaseDame = BaseDame * (10 / 100f);
                        increaseagi = 30;
                        increasestr = 10;
                        break;
                    }
                case ItemType.Amor:
                    {
                        increaseAmor = BaseAmor * (5 / 100f);
                        increaseHP = BaseHealth * (15 / 100f);
                        increasestr = 25;
                        break;
                    }
                case ItemType.Bow:
                    {
                        increaseSpeed = BaseSpeed * (20 / 100f);
                        increaseagi = 15;
                        break;
                    }
                case ItemType.Staff:
                    {
                        increaseMana = BaseMana * (40 / 100f);
                        increaseintel = 20;
                        break;
                    }
            }
        }

        public void UnuseItem()
        {
            if (itemuse != null)
            {
                itemuse = null;
            }
            ReloadAtribute();
        }
    }
}
