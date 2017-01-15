using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Game
    {
        //global variables
        List<List<string>> Mxy = new List<List<string>>();                  //Monster Cords
        List<string[,]> invs = new List<string[,]>();                       //Inventories
        List<string[,]> tempname;                                           //The World
        List<int> wallcount = new List<int>();                              //How many blocks mined
        List<int> temp = new List<int>();                                   //blocks left to mine
        List<bool> Stairs = new List<bool>();                               //if you have stairs
        string Pxy, NPCxy;                                                  //Player cords/respawn
        int floori = 0;                                                     //what level the player is on
        //int turn;                                                         //prep for turnbase method
        string Pname;                                                       //Player's name
        Random rand = new Random();                                         //random generator
        //--------------------------------------------------------------------------------------------------------------------------------------
        public Game(string pName)//constructor
        {
            Pname = pName;
            tempname = GameCreation();
        }
        //List Method to init game  //make's    inventory, world 
        private List<string[,]> GameCreation()
        {
            Inventory inv = new Inventory();
            invs.Add(inv.Gridsetup()); invs.Add(inv.Gridsetup()); invs.Add(inv.Gridsetup());//runs 3 times
            List<string[,]> n3w = new List<string[,]>();
            World bob = new World();
            for (int i = 0; i < 20; i++)
                n3w.Add(bob.WorldGeneration());
            Pxy = bob.RandomLocation(n3w[0]);//makes player spawn on random location on floor 1 with npc near it
            NPCxy = Pxy;//Get respawn location
            for (int i = 0; i < n3w.Count; i++)
            { wallcount.Add(0); temp.Add(0); Stairs.Add(true); List<string> tempLst = new List<string>(); Mxy.Add(tempLst); }
            return n3w;
        }
        //Random mob spawning
        private string RandMobSpawn()
        {
            string tempxy = "";
            while (tempxy.Length < 4)
            {
                int tmpNum = rand.Next(1, 19);
                if (tmpNum < 10)
                    tempxy += "0" + tmpNum;
                else
                    tempxy += tmpNum;
                if (tempxy.Length > 3)
                {
                    if (tempname[floori][int.Parse(tempxy.Substring(0, 2)), int.Parse(tempxy.Substring(2, 2))] == "R")
                    {
                        Mxy[floori].Add(tempxy);
                    }
                    else
                    { tempxy = ""; }
                }
            }
            return tempxy;
        }
        public List<string[,]> UI()
        {
            Inventory inv = new Inventory();
            World bob = new World();
            Player p1 = new Player();
            for (int floor = floori; floor < tempname.Count;)
            {
                if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "v" || tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "^")
                {
                    Console.Clear();
                    Console.WriteLine("Floor " + (floor + 1));
                    bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname, Mxy[floor]);
                    string direction = "up";
                    if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "v")
                        direction = "down";
                    Console.WriteLine("Would you like to go " + direction + " the stairs?\n\"y\" or \"n\"");
                    if (Console.ReadKey().KeyChar == 'y')
                        if (direction == "up")
                            floor--;
                        else
                            floor++;
                }
                floori = floor;
                for (int i = 0; i < Mxy[floor].Count; i++)
                {
                    if (Mxy[floor][i] == Pxy)
                        if (Combat(p1) == true)
                            Mxy[floor].Remove(Pxy);
                }
                for (int i = 0; i < Mxy[floor].Count; i++)
                {
                    int chance = rand.Next(1, 101);
                    int eAi = rand.Next(1, 5);

                    if (chance <= 25) // probability of 25%
                    {
                        //mob moves
                        Mxy[floor][i] = movement(eAi, Mxy[floor][i]);
                    }
                    else
                    {/* mob stays */}
                }
                if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "v" && tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "^")
                        tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "R";
                Console.Clear();
                Console.WriteLine("Floor " + (floor + 1));
                temp[floor] = bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname, Mxy[floor]);
                string textA = "\t";
                string textB = "l: Leave Game";
                string TempText = "";
                if (wallcount[floor] >= .6 * (temp[floor] + wallcount[floor]) && Stairs[floor] == true && floor + 1 < tempname.Count)
                { textA = "S: Place Stairs"; TempText = textA; textA = textB; textB = TempText; }
                Console.WriteLine("i: Open Inventory\t\t\t  w\nk: Status Menu\t\t\t\ta   d\n" + textB + "\t\t\t\t  s\n" + textA);
                ConsoleKeyInfo choice = Console.ReadKey();
                if (wallcount[floor] >= .05 * (temp[floor] + wallcount[floor]) && Mxy[floor].Count < 1 && rand.Next(1, 101) <= 30)
                    RandMobSpawn();
                if (wallcount[floor] >= .35 * (temp[floor] + wallcount[floor]) && Mxy[floor].Count < 2 && rand.Next(1, 101) <= 30)
                    RandMobSpawn();
                if (wallcount[floor] >= .8 * (temp[floor] + wallcount[floor]) && Mxy[floor].Count < 3 && rand.Next(1, 101) <= 30)
                    RandMobSpawn();
                switch (choice.KeyChar)
                {
                    case 'w':
                        Pxy = movement(1, Pxy);
                        break;
                    case 'a':
                        Pxy = movement(2, Pxy);
                        break;
                    case 's':
                        Pxy = movement(3, Pxy);
                        break;
                    case 'd':
                        Pxy = movement(4, Pxy);
                        break;
                    case 'S':
                        if (wallcount[floor] >= .6 && floor + 1 < tempname.Count && tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "^")
                        {
                            Console.Clear();
                            Console.WriteLine("Floor " + (floor + 1));
                            bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname, Mxy[floor]);
                            Console.WriteLine("Are you sure you want to place the stairs here?\n\"y\" or \"n\"");
                            if (Console.ReadKey().KeyChar == 'y' && tempname[floor + 1][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "I")
                            {
                                tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "v";
                                tempname[floor + 1][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "^";
                                Stairs[floor] = false;
                            }
                        }
                        break;
                    case 'i':
                        inv.invUI(invs);
                        break;
                    case 'k':
                        p1.Status(Pname);
                        Console.ReadKey();
                        break;
                    case 'l':
                        floor = tempname.Count + 1;
                        break;
                }
            }
            return tempname;
        }
        private string movement(int direction, string Exy)
        {
            int floor = floori;
            bool detect = true;
            switch (direction)
            {
                case 1:
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] == "N")
                    {
                        if (Pxy == Exy)
                        { }
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] == "I")
                        {
                            wallcount[floor]++;
                        }
                        
                        for (int i = 0; i < Mxy[floor].Count; i++)
                            if (Pxy != Exy && (int.Parse(Mxy[floor][i].Substring(0, 2)) == (int.Parse(Exy.Substring(0, 2)) - 1) && int.Parse(Mxy[floor][i].Substring(2, 2)) == int.Parse(Exy.Substring(2, 2))))
                                detect = false;
                        if (detect == false || (int.Parse(Exy.Substring(0, 2)) - 1 == int.Parse(Pxy.Substring(0, 2)) && int.Parse(Exy.Substring(2, 2)) == int.Parse(Pxy.Substring(2, 2))))
                            break;
                        Exy = (int.Parse(Exy.Substring(0, 2)) - 1).ToString() + Exy.Substring(2, 2);
                    }
                    if (Exy.Length == 3)
                        Exy = "0" + Exy.Substring(0, 2) + (Exy.Substring(2, 1));
                    break;
                case 2:
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] == "N")
                    {
                        if (Pxy == Exy)
                        { }
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] == "I")
                        {
                            wallcount[floor]++;
                        }
                        for (int i = 0; i < Mxy[floor].Count; i++)
                            if (Pxy != Exy && (int.Parse(Mxy[floor][i].Substring(0, 2)) == int.Parse(Exy.Substring(0, 2)) && int.Parse(Mxy[floor][i].Substring(2, 2)) == (int.Parse(Exy.Substring(2, 2)) - 1)))
                                detect = false;
                        if (detect == false || (int.Parse(Exy.Substring(0, 2)) == int.Parse(Pxy.Substring(0, 2)) && int.Parse(Exy.Substring(2, 2)) - 1 == int.Parse(Pxy.Substring(2, 2))))
                            break;
                        Exy = Exy.Substring(0, 2) + (int.Parse(Exy.Substring(2, 2)) - 1).ToString();
                    }
                    if (Exy.Length == 3)
                        Exy = Exy.Substring(0, 2) + "0" + (Exy.Substring(2, 1));
                    break;
                case 3:
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] == "N")
                    {
                        if (Pxy == Exy)
                        { }
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] == "I")
                        {
                            wallcount[floor]++;
                        }
                        for (int i = 0; i < Mxy[floor].Count; i++)
                            if (Pxy != Exy && (int.Parse(Mxy[floor][i].Substring(0, 2)) == (int.Parse(Exy.Substring(0, 2)) + 1) && int.Parse(Mxy[floor][i].Substring(2, 2)) == int.Parse(Exy.Substring(2, 2))))
                                detect = false;
                        if (detect == false || (int.Parse(Exy.Substring(0, 2)) + 1 == int.Parse(Pxy.Substring(0, 2)) && int.Parse(Exy.Substring(2, 2)) == int.Parse(Pxy.Substring(2, 2))))
                            break;
                        Exy = (int.Parse(Exy.Substring(0, 2)) + 1).ToString() + Exy.Substring(2, 2);
                    }
                    if (Exy.Length == 3)
                        Exy = "0" + Exy.Substring(0, 2) + (Exy.Substring(2, 1));
                    break;
                case 4:
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] == "N")
                    {
                        if (Pxy == Exy)
                        { }
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] == "I")
                        {
                            wallcount[floor]++;
                        }
                        for (int i = 0; i < Mxy[floor].Count; i++)
                            if (Pxy != Exy && (int.Parse(Mxy[floor][i].Substring(0, 2)) == int.Parse(Exy.Substring(0, 2)) && int.Parse(Mxy[floor][i].Substring(2, 2)) == (int.Parse(Exy.Substring(2, 2)) + 1)))
                                detect = false;
                        if (detect == false || (int.Parse(Exy.Substring(0, 2)) == int.Parse(Pxy.Substring(0, 2)) && int.Parse(Exy.Substring(2, 2)) + 1 == int.Parse(Pxy.Substring(2, 2))))
                            break;
                        Exy = Exy.Substring(0, 2) + (int.Parse(Exy.Substring(2, 2)) + 1).ToString();
                    }
                    if (Exy.Length == 3)
                        Exy = Exy.Substring(0, 2) + "0" + (Exy.Substring(2, 1));
                    break;
            }
            return Exy;
        }
        
        private bool Combat(Player p1)
        {
            Mob m1 = new Mob();
            int t = rand.Next(1, 3);

            Console.Clear();
            while (Mob.currHp >= 1 && p1.currHp >= 1)
            {
                Console.WriteLine("                             A monster has appeared!\n");
                if (t == 1)
                {
                    if (p1.currHp > 0)
                    {
                        //player attacks
                        Console.WriteLine("Player HP:" + p1.currHp);
                        p1.Combat(invs);
                        t++;
                        CombatScreen();
                    }
                }
                if (Mob.currHp <= 0)
                {
                    Console.WriteLine("Monster was Defeated");
                    Console.ReadKey();
                }
                else
                {
                    // mob attack
                    Console.WriteLine("Monster HP:" + Mob.currHp);
                    m1.Combat(p1);
                    t--;
                    CombatScreen();
                    if (p1.currHp <= 0)
                    {
                        Console.WriteLine("Player HP:" + p1.currHp);
                        Console.WriteLine("You Died buddy old pal");
                        Console.ReadKey();
                        return false;
                    }
                }
            }
            return true;
        }
        private void respawn(Player p1,int floorR)
        {
            floorR = 0;
            Pxy = NPCxy;

        } 
        private void CombatScreen()
        {
            Console.ReadKey();
            Console.Clear();
        }
      
    }
}