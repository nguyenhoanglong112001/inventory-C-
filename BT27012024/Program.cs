using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT27012024
{
    internal class Program
    {
        public static Item[] items = null;
        public static Player player = new Player("Player");
        //public static Enemy enemy = new Enemy("Enemy", player);
        //public static Hero[] heros = new Hero[] { player};
        public static List<Hero> heroes = new List<Hero>() { player};
        public static Dictionary<ItemType, List<Item>> Itemclassify = new Dictionary<ItemType, List<Item>>();
        public static List<Item> itemlist = new List<Item>();
        static void Main(string[] args)
        {
            items = new Item[10];
            while(true)
            {
                UI.MainMenu();
            }
        }
        public static void Battle(Player player1)
        {
            Enemy enemy = new Enemy("Monster", player1);
            heroes.Add(enemy);
            double startbasehp = player1.BaseHealth;
            double startincreasehp = player1.IncreaseHP;
            Console.Clear();
            Console.WriteLine($"{player1.Heroname} info: ");
            player1.HeroInfomation();
            Console.WriteLine($"{enemy.Heroname} info: ");
            enemy.HeroInfomation();
            Console.WriteLine("Press any key to begin the battle");
            Console.Clear();
            int currentturn = player1.Speed > enemy.Speed ? 0 : 1;
            int turn = 1;
            while (player1.Alive && enemy.Alive)
            {
                Console.WriteLine($"Turn : {turn}");
                int targerindex = currentturn == 0 ? 1 : 0;
                heroes[currentturn].Attack(heroes[targerindex]);
                Hero currentHero = heroes[currentturn];
                Hero targetHero = heroes[targerindex];
                Console.WriteLine($"{currentHero.Heroname} deal {Math.Round(currentHero.Dame*(100/(100+currentHero.Amor)),0)} to {targetHero.Heroname}");
                if (targetHero.HP < 0)
                {
                    Console.WriteLine($"{currentHero.Heroname} : {currentHero.HP}");
                    Console.WriteLine($"{targetHero.Heroname} : 0");
                }
                else
                {
                    Console.WriteLine($"{currentHero.Heroname} : {currentHero.HP}");
                    Console.WriteLine($"{targetHero.Heroname} : {targetHero.HP}");
                }
                currentturn = targerindex;
                turn++;
                Thread.Sleep(100);
            }

            Hero Winner = heroes[0].Alive ? heroes[0] : heroes[1];
            Console.WriteLine($"{Winner.Heroname} victory.......");
            Console.ReadKey();
            if (player1.Alive)
            {
                player1.currentexp += 25;
                CurrencyManager.currentGold += 50;
                player1.SetBaseHP = startbasehp;
                player1.SetIncreaseHP = startincreasehp;
                Console.WriteLine($"{player1.Heroname} get 25 exp and 50 gold");
            }
            else
            {
                player1.SetBaseHP = startbasehp;
                player1.SetIncreaseHP = startincreasehp;
            }

            if (!enemy.Alive)
            {
                enemy = CreateEnemy();
            }
        }

        public static Enemy CreateEnemy()
        {
            Enemy newEnemy = new Enemy("Monster", player);
            heroes[1] = newEnemy;
            return newEnemy;
        }
    }
}
