using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class World
    {
        public World()
        {

        }
        public string[,] WorldGeneration(Random gen)
        {
            /* O: Outside the Border
             * I: Inside the Border
             * B: Border
             * R: Room
             * ^: Stairs Up
             * v: Stairs Down
             * N: NPC
             */
            string[,] World = new string[20, 20];
            switch (gen.Next(5))
            {
                case 0:
                    World = new string[20, 20]
                    {
                    { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                    { "O","B","B","B","B","B","B","B","B","B","B","B","B","O","O","O","O","O","O","O" },
                    { "O","B","I","I","I","I","I","I","I","I","I","I","I","B","O","O","O","O","O","O" },
                    { "O","B","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O","O","O","O" },
                    { "O","B","B","B","B","B","B","B","B","B","I","I","I","I","I","B","O","O","O","O" },
                    { "O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O","O" },
                    { "O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O" },
                    { "O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","O","B","I","I","I","I","B","B","B","B","B","B","B","B","B","B","O" },
                    { "O","O","O","O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","O","O","O","B","I","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","O","O","O","O","B","I","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","O","O","O","O","O","B","I","I","I","I","I","I","I","I","I","B","O" },
                    { "O","O","O","O","O","O","O","O","O","B","B","B","B","B","B","B","B","B","B","O" },
                    { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                    { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                    { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                    { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" }
                };
                    break;
                case 1:
                    World = new string[20, 20]
                    {
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","B","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","B","I","B","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","B","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","I","I","B","O","O","O","O","O","O" },
                { "O","O","O","O","B","I","I","I","B","B","B","I","I","I","B","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","I","I","B","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","B","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","B","I","B","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","B","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" }
                    };
                    break;
                case 2:
                    World = new string[20, 20]
                    {
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","B","B","B","B","B","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","B","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","B","B","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","B","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","B","B","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","B","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","B","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","B","B","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","B","I","I","B","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","B","B","B","I","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","B","B","B","B","B","B","B","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" }
                    };
                    break;
                case 3:
                    World = new string[20, 20]
                    {
                        {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
                        {"O", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "O", "O", "B", "B", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "B", "O", "B", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "B", "B", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "B", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O"},
                        {"O", "B", "I", "I", "I", "I", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "B", "O"},
                        {"O", "B", "I", "I", "I", "B", "B", "B", "I", "I", "I", "I", "I", "I", "I", "I", "I", "B", "O", "O"},
                        {"O", "B", "I", "I", "B", "B", "O", "B", "B", "I", "I", "I", "I", "I", "I", "I", "B", "O", "O", "O"},
                        {"O", "B", "B", "B", "B", "O", "O", "O", "B", "B", "B", "B", "B", "B", "B", "B", "B", "O", "O", "O"},
                        {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O"},
                        {"O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O"}
                    };
                    break;
                case 4:
                    World = new string[20, 20]
                    {
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","B","B","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","B","B","I","I","B","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","B","I","I","I","I","I","B","O","O","O","O","O" },
                { "O","O","O","B","O","O","O","B","I","I","I","I","I","I","I","B","O","O","O","O" },
                { "O","O","O","O","B","O","B","I","I","I","I","B","B","I","I","B","O","O","O","O" },
                { "O","O","O","O","B","O","B","I","I","I","B","I","B","I","I","B","O","O","O","O" },
                { "O","O","O","O","B","O","B","I","I","B","I","I","B","I","I","B","O","O","O","O" },
                { "O","O","O","B","I","B","B","I","I","I","I","I","B","I","I","B","O","O","O","O" },
                { "O","O","O","B","I","I","I","B","I","I","I","B","I","I","I","B","O","O","O","O" },
                { "O","O","O","O","B","I","I","I","B","B","B","I","I","I","B","O","O","O","O","O" },
                { "O","O","O","O","O","B","I","I","I","I","I","I","I","B","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","B","B","B","B","B","B","B","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" },
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O" }
                    };
                    break;
            }
            return World;
        }
        public int UpdateWorld(string[,] world, int Py, int Px, string Name, List<string> Mobsxy)
        {
            int NumOfI = 0;
            for (int row = 0; row < world.GetLength(0); row++)
            {
                for (int col = 0; col < world.GetLength(1); col++)
                {
                    string temp2 = "        ";
                    string temp1 = world[row, col];
                    if (temp1 == "I")
                        NumOfI++;
                    if ((temp1 == "I" || temp1 == "B") && (world[row + 1, col] == "R" || world[row - 1, col] == "R" || world[row, col + 1] == "R" || world[row, col - 1] == "R" ||
                                                         world[row + 1, col] == "^" || world[row - 1, col] == "^" || world[row, col + 1] == "^" || world[row, col - 1] == "^" ||
                                                         world[row + 1, col] == "v" || world[row - 1, col] == "v" || world[row, col + 1] == "v" || world[row, col - 1] == "v"))
                    {
                        if (temp1 == "I")
                            temp1 = "+";
                        else
                            temp1 = "X";
                    }
                    else if (temp1 == "O" || temp1 == "R" || temp1 == "I" || temp1 == "B")
                        temp1 = " ";
                    for (int p = 0; p < Mobsxy.Count; p++)
                        if (row == int.Parse(Mobsxy[p].Substring(0, 2)) && col == int.Parse(Mobsxy[p].Substring(2, 2)) && world[row, col] == "R")
                            temp1 = "M";
                    if (row == Py && col == Px)
                        temp1 = Name.Substring(0, 1);
                    if (col == 0)
                        temp2 += temp1;
                    else
                        temp2 = temp1;
                    Console.Write(String.Format("{0} ", temp2));
                }
                Console.WriteLine();
            }
            return NumOfI;
        }
        public string RandomLocation(string[,] world)
        {
            Random thing = new Random();
            string Pxy = "";
            int Px, Py;
            Px = 0; Py = 0;
            while (Pxy.Length < 4)
            {
                int temp = thing.Next(1, 19);
                if (temp < 10)
                    Pxy += "0" + temp;
                else
                    Pxy += temp;
                if (Pxy.Length > 3)
                {
                    Px = int.Parse(Pxy.Substring(0, 2));
                    Py = int.Parse(Pxy.Substring(2, 2));
                }
                bool check = true;
                if ((Pxy.Length == 4 && (world[(Px + 1), Py] == "B" ^ world[(Px - 1), Py] == "B" ^ world[Px, (Py + 1)] == "B" ^ world[Px, (Py - 1)] == "B" == false)) ||
                   ((Pxy.Length == 4 && (world[(Px + 1), Py] == "O" || world[(Px - 1), Py] == "O" || world[Px, (Py + 1)] == "O" || world[Px, (Py - 1)] == "O"))))
                { Pxy = ""; check = false; }
                if (check == true && Pxy.Length == 4)
                {
                    if (world[(Px + 1), Py] == "B")
                        world[(Px + 1), Py] = "N";
                    else if (world[(Px - 1), Py] == "B")
                        world[(Px - 1), Py] = "N";
                    else if (world[Px, (Py + 1)] == "B")
                        world[Px, (Py + 1)] = "N";
                    else if (world[Px, (Py - 1)] == "B")
                        world[Px, (Py - 1)] = "N";
                }
            }
            return Pxy;
        }
    }
}

