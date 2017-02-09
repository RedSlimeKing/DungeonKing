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
            currHp = 30;
            Potion = 3;
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
            if (n1 <= 10) // probability of 10%
                choice = 4;
            else if (n1 >= 60) // probability of 40%
                choice = 1;
            def = 0;
            switch (choice)
            {
                case 1:
                    Attack(p1);                     //tries to attack
                    break;
                case 2:
                    Defend();                       //Monster defends
                    break;
                case 4:
                    UsePotion();                    //trys to use potion
                    break;
                case 3:
                    Console.WriteLine("        The monster went idle");
                    break;
            }
        }

        public void Attack(Player p1) {   
            Random rand = new Random();
            int chance = rand.Next(1, 101);
            Console.WriteLine("        Monster attacks");
            if (chance <= 30) {                                                     // probability of 30%
                Console.WriteLine("        The monster's attack missed!");          //attack miss
            }
            else {
                if (p1.def == 1) {                                                  //Player Blocks
                    Console.WriteLine("        The monster's attack was blocked");
                }
                else {
                    Console.WriteLine("        The monster landed it's attack");
                    p1.ReceiveDamage(MDamage);
                }
            }
        }
        public void Defend() {
            Console.WriteLine("        The monster prepares to defend");
            def++;
        }

        public static void ReceiveDamage(int amount) {
            Mob.currHp -= amount;
        }

        public void UsePotion() {
            if (Potion > 0) {
                Console.WriteLine("        Monster uses potion [+ 20]");
                currHp += 20;
                Potion--;
            }
            else {
                Console.WriteLine("        Monster tried to use a potion but the it didn't have one");
                Potion = 0;
            }
        }
    }
}