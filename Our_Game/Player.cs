using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Player
    {
        static int dmg;
        int maxhp = 10;
        string name;
        public int def;
        public int currhp;
        public int _wallet;

        Weapon Weap = new Weapon();
        Equipment equip1 = new HeadGear(1), equip2 = new UpperBodyGear(1), equip3 = new LowerBodyGear(1), equip4 = new Accessory(1);

        public Player()
        {
            _wallet = 0;
            dmg = 5;
            Weap.Arsenal("C Long Sword");
            maxhp += equip1.IHP + equip2.IHP + equip3.IHP + equip4.IHP;
            currHp = MaxHealth;
            PDamage = dmg + Weap.Damage;
        }
        //get sets
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Wallet
        {
            get { return _wallet; }
            set { _wallet = value; }
        }
        public int MaxHealth
        {
            get { return maxhp; }
            set { maxhp = value; }
        }
        public int currHp
        {
            get { return currhp; }
            set { currhp = value; }
        }
        public static int PDamage
        {
            get { return dmg; }
            set { dmg = value; }
        }
        //combat methods
        public void Combat(List<string[,]> Items)
        {
            bool tryme = false;
            Console.WriteLine("        What move would you like to do?");
            Console.WriteLine("        1.Attack \n        2.Defend \n        3.Use potion");
            while (tryme == false)
            {
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.KeyChar == '1' || choice.KeyChar == '2' || choice.KeyChar == '3')
                {
                    def = 0;
                    switch (choice.KeyChar)
                    {
                        case '1':
                            Attack();
                            break;
                        case '2':
                            Defend();
                            break;
                        case '3':
                            UsePotion(Items);
                            break;
                    }
                    tryme = true;
                }
                else
                {
                    //nothing happens
                    Utility.Pretty();
                    tryme = false;
                }
            }
           
            
        }
        public void Attack()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 101);

            Console.Clear();
            if (chance <= 25) // probability of 25% missing     75% of hitting
            {
                //attack miss
                Console.WriteLine("       You failed to land your attack!");
            }
            else
            {
                if (Mob.def == 1)
                {
                    //attack blocked
                    Console.WriteLine("       You landed your attack however the monster blocked your attack!");
                }
                else
                {
                    //attack hits
                    Console.WriteLine("        You landed your attack. you did {0} damage to the enemy", PDamage);
                    Mob.ReceiveDamage(PDamage);
                }

            }
        }
        public void Defend()
        {
            Console.Clear();
            Console.WriteLine("        You prepare to block!");
            def++;
        }
        public void UsePotion(List<string[,]> Items)
        {
            int tempHp = MaxHealth - currHp;
            for (int page = 0; page != Items.Count; page++)
                for (int row = 1; row < Items[page].GetLength(0); row++)
                    for (int col = 1; col < Items[page].GetLength(1); col++)
                        if (Items[page][row, col].Contains("Potion"))
                        {
                            if (tempHp <= 20)
                                currHp += tempHp;
                            else
                                currHp += 20;
                            Items[page][row, col].Substring(Items[page][row, col].Length - 2, Items[page][row, col].Length - 1);
                            break;
                        }
                        else if (row == Items[page].GetLength(0) - 1 && col == Items[page].GetLength(1) - 1 && page == Items.Count -1)
                        {
                            Console.Clear();
                            Console.WriteLine("        You dont have any potions!");
                        }
            
        }
        public void ReceiveDamage(int amount)
        {
            currHp -= amount;
        }
        public void Status(string name)
        {
            /*
                Player Name:        Kevin
                Health/Max Health:  10/20
                Damage:             20
                Weapon:             Long Sword[+15 dmg]
                Head Gear:          none[+0]
                Body Gear:          Leather coat [+10 hp]
                
                *Magic*
                    Fireball
             */
            Console.Clear();
            Console.WriteLine("        |Name:                    " + name);
            Console.WriteLine("        |Health/Max Health:       " + currHp + "/" + MaxHealth);
            Console.WriteLine("        |Damage:                  " + PDamage);
            Console.WriteLine("        |Weapon:                  " + Weap.Name + " [ + " + Weap.Damage + " dmg]");
            Console.WriteLine("        |Head Gear:               " + equip1.Name + " [ + " + equip1.IHP + " hp]");
            Console.WriteLine("        |Upper Body Gear:         " + equip2.Name + " [ + " + equip2.IHP + " hp]");
            Console.WriteLine("        |Lower Body Gear:         " + equip3.Name + " [ + " + equip3.IHP + " hp]");
            Console.WriteLine("        |Accessory:               " + equip4.Name + " [ + " + equip4.IHP + " hp]");
            Console.WriteLine("        |Wallet:                  " + Wallet + "\n");
            Console.WriteLine("        l: leave status menu");
            bool bob = true;
            while (bob == true)
                if (Console.ReadKey().KeyChar == 'l')
                    bob = false;
                else
                    Utility.Pretty();
        }
    }
}
