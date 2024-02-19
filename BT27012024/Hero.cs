﻿using System;
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
        public string Heroname { get; private set; }
        public HeroType Herotype { get; private set; }

        public double BaseDame { get; protected set; } = 50;
        public double Dame => BaseDame + IncreaseDame;

        public double BaseHealth { get; protected set; } = 300;
        public double HP => BaseHealth + IncreaseHP;

        public double BaseMana { get; protected set; } = 200;
        public double MP => BaseMana + IncreaseMana;

        public double BaseSpeed { get; protected set; } = 10;
        public double Speed => BaseSpeed + IncreaseSpeed;

        public double BaseAmor { get; protected set; } = 3;
        public double Amor => BaseAmor + IncreaseAmor;

        public int Agility { get; protected set; }
        public int Agi => Agility + IncreaseAgi;

        public int Strength { get; protected set; }
        public int Str => Strength + IncreaseStr;

        public int Intelligence { get; protected set; }
        public int Intel => Intelligence + IncreaseIntel;

        public Item Itemuse { get; private set; }

        public bool Alive => HP > 0;

        // Thuộc tính tăng thêm
        public double IncreaseHP { get; protected set; }
        public double IncreaseMana { get; protected set; }
        public double IncreaseSpeed { get; protected set; }
        public double IncreaseDame { get; protected set; }
        public double IncreaseAmor { get; protected set; }
        public int IncreaseAgi { get; protected set; }
        public int IncreaseStr { get; protected set; }
        public int IncreaseIntel { get; protected set; }
        public Hero() { }

        public Hero(string heroname)
        {
            this.Heroname = heroname;
            Herotype = (HeroType)GameHelper.GetRandomValue(0, 4);
            Agility = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseSpeed = BaseSpeed + Agility * 1;
            BaseAmor = BaseAmor + Agility * 0.14;
            Strength = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseHealth = BaseHealth + Strength * 19;
            Intelligence = GameHelper.GetRandomValue(0, 81);
            Thread.Sleep(100);
            BaseMana = BaseMana + Intelligence * 13;
            heroatribute();
        }

        public void TakeDame(Hero target)
        {
            if (!Alive)
            {
                return;
            }
            double damage = Dame * (100 / (100 + Amor));
            double remainHP = target.HP - damage;

            target.HP = Math.Max(remainHP, 0);
        }

        public void Attack(Hero target)
        {
            if (!Alive)
            {
                return;
            }
            TakeDame(target);
        }
        public void heroatribute()
        {
            if (Herotype == HeroType.Agility)
            {
                BaseDame += Agility;
            }
            if (Herotype == HeroType.Strength)
            {
                BaseDame += Strength;
            }
            if (Herotype == HeroType.Intelligence)
            {
                BaseDame += Intelligence;
            }
            if (Herotype == HeroType.Universal)
            {
                BaseDame += 0.4 * (Strength + Agility + Intelligence);
            }
        }

        public void HeroInfomation()
        {
            Console.WriteLine("Name: " + Heroname);
            Console.WriteLine("Hero type: " + Herotype);
            Console.WriteLine("agility: " + Agi);
            Console.WriteLine("strength: " + Str);
            Console.WriteLine("intelligence: " + Intel);
            Console.WriteLine("Health: " + HP);
            Console.WriteLine("Mana: " + MP);
            Console.WriteLine("Attack Dame: " + Dame);
            Console.WriteLine("Attack Speed: " + Speed);
            Console.WriteLine("Amor: " + Amor);
            if (Itemuse != null)
            {
                Console.WriteLine("Item use: " + Itemuse.itemname);
            }
            else
            {
                Console.WriteLine("Item use: ");
            }
            Console.ReadKey();
        }

        public void UseItem(Item item)
        {
            if (Itemuse == null)
            {
                Itemuse = item;
            }
            ReloadAtribute();
            
        }

        public void ReloadAtribute()
        {
            switch(Itemuse.type)
            {
                case ItemType.Sword:
                    {
                        IncreaseDame = BaseDame * (10 / 100f);
                        IncreaseAgi = 30;
                        IncreaseStr = 10;
                        break;
                    }
                case ItemType.Amor:
                    {
                        IncreaseAmor = BaseAmor * (5 / 100f);
                        IncreaseHP = BaseHealth * (15 / 100f);
                        IncreaseStr = 25;
                        break;
                    }
                case ItemType.Bow:
                    {
                        IncreaseSpeed = BaseSpeed * (20 / 100f);
                        IncreaseAgi = 15;
                        break;
                    }
                case ItemType.Staff:
                    {
                        IncreaseMana = BaseMana * (40 / 100f);
                        IncreaseIntel = 20;
                        break;
                    }
            }
        }

        public void UnuseItem()
        {
            if (Itemuse != null)
            {
                Itemuse = null;
            }
            ReloadAtribute();
        }
    }
}
