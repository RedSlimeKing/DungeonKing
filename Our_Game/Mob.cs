using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Mob
    {
        static int dmg;
        string name;
        static int currhp;
        int Potion;
        
        public static int def;

        public Mob()
        {
            
            dmg = 5;
            currHp = 50;
            Potion = 5;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static int currHp
        {
            get { return currhp; }
            set { currhp = value; }
        }

        public static int MDamage
        {
            get { return dmg; }
            set { dmg = value; }
        }


        public void Combat(Player p1)
        {
            Random gen = new Random();
            int n1 = gen.Next(1, 101);
            int choice = gen.Next(1, 4);
            if (n1 <= 15) // probability of 15%
                choice = 4;
            else if (n1 >= 60) // probability of 40%
                choice = 1;
            def = 0;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monster attacks");
                    Attack(MDamage, p1);
                    break;
                case 2:
                    Console.WriteLine("Monster Defend");
                    Defend();
                    break;
                case 4:
                    Console.WriteLine("Monster uses potion");
                    UsePotion();
                    break;
                case 3:
                    Console.WriteLine("Monster farted");
                    break;
            }
        }

        public void Attack(int damage, Player p1)
        {   
            Random rand = new Random();
            int chance = rand.Next(1, 101);

            Console.Clear();
            if (chance <= 30) // probability of 30%
            {
                //attack miss
                Console.WriteLine("Monster's attack missed!");
            }
            else
            {
                if (p1.def == 1)
                {
                    //Player Blocks
                    Console.WriteLine("Blocked monster attack");
                }
                else
                {
                    Console.WriteLine("Monster's attack hit!");
                    p1.ReceiveDamage(damage);
                }
            }
        }

        public void Defend()
        {
            def++;
        }

        public static void ReceiveDamage(int amount)
        {
            Mob.currHp -= amount;
        }

        public void UsePotion()
        {
            if (Potion > 0)
            {
                currHp += 20;
                Potion--;
            }
            else
            {
                Potion = 0;
            }
        }
    }
}
