﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Inventory
    {
        public Inventory()
        {
        }
        public string[,] Gridsetup()
        {
            string[,] grid = new string[10, 10]
            {
                {" ","1","2","3","4","5","6","7","8","9"},
                {"1","0","0","0","0","0","0","0","0","0"},
                {"2","0","0","0","0","0","0","0","0","0"},
                {"3","0","0","0","0","0","0","0","0","0"},
                {"4","0","0","0","0","0","0","0","0","0"},
                {"5","0","0","0","0","0","0","0","0","0"},
                {"6","0","0","0","0","0","0","0","0","0"},
                {"7","0","0","0","0","0","0","0","0","0"},
                {"8","0","0","0","0","0","0","0","0","0"},
                {"9","0","0","0","0","0","0","0","0","0"}
            };
            return grid;
        }
        public string[,] InvDisplay(string[,] grid, int page)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    string temp1 = "        ";
                    string temp = grid[row, col];
                    if (temp == "0")
                        temp = " ";
                    if (col == 0)
                        temp1 += temp;
                    else
                        temp1 = temp;
                    Console.Write(String.Format("{0} | ", temp1));
                }
                Console.WriteLine();
            }
            return grid;
        }
        public List<string[,]> invUI(List<string[,]> invs)
        {
            string tempA = "";
            string tempB = "";
            string tempm = "";
            int tempnum = 0;
            int tempPage = 0;
            int row = -1; int col = -1;
            int page = 0;
            while (page < invs.Count)
            {
                UI(invs, page);
                Console.WriteLine("\n        What would you like to do?");
                if (invs.Count > 1)
                    Console.WriteLine("\r        p: Change page,");
                Console.WriteLine("\r        m: Move items,\n        k: Read item description,\n        l: Leave");
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.KeyChar == 'p')
                {
                    UI(invs, page);
                    Console.WriteLine("\n        What page?");
                    ConsoleKeyInfo temp = Console.ReadKey();
                    if (Utility.IsDigitsOnly(temp.KeyChar.ToString()) == true && int.Parse(temp.KeyChar.ToString()) < invs.Count)
                        page = int.Parse(temp.KeyChar.ToString()) - 1;
                }
                else if (choice.KeyChar == 'm')
                {
                    if (tempnum == 2)
                    {
                        tempnum = 0;
                        tempB = "";
                        tempA = "";
                        tempm = "";
                        row = -1;
                        col = -1;
                    }
                    UI(invs, page);
                    string TempM = "";
                    if (tempA != "")
                        TempM = " of where you would like";
                    tempm = TempM + tempA;
                    if (tempA == "0")
                        tempm = " of what you would like to move here";
                    TempM = tempm;
                    Console.WriteLine("\n        Type the column, followed by the row" + TempM + ".\n        Please seperate them by either a space or a \",\"");
                    string temp = Console.ReadLine().Replace(" ", "").Replace(",", "");
                    if (temp.Length == 2 &&
                       (temp.Substring(0, 1) == "1" || temp.Substring(0, 1) == "2" || temp.Substring(0, 1) == "3" || temp.Substring(0, 1) == "4" || temp.Substring(0, 1) == "5" ||
                        temp.Substring(0, 1) == "6" || temp.Substring(0, 1) == "7" || temp.Substring(0, 1) == "8" || temp.Substring(0, 1) == "9") &&
                       (temp.Substring(1, 1) == "1" || temp.Substring(1, 1) == "2" || temp.Substring(1, 1) == "3" || temp.Substring(1, 1) == "4" || temp.Substring(1, 1) == "5" ||
                        temp.Substring(1, 1) == "6" || temp.Substring(1, 1) == "7" || temp.Substring(1, 1) == "8" || temp.Substring(1, 1) == "9"))
                    {
                        int row2 = int.Parse(temp.Substring(0, 1)); int col2 = int.Parse(temp.Substring(1, 1));
                        if (row == -1 && col == -1)
                        {
                            row = row2; col = col2;
                            tempPage = page;
                        }
                        tempB = tempA;
                        tempA = invs[page][row2, col2];
                        if (tempB == "")
                        { }
                        else
                        {
                            invs[tempPage][row, col] = tempA;
                            invs[page][row2, col2] = tempB;
                        }
                        tempnum++;
                    }
                }
                else if (choice.KeyChar == 'k')
                {
                    UI(invs, page);
                    Console.WriteLine("\n        Type the column, followed by the row of the item.\n        Please seperate them by either a space or a \",\"");
                }
                else if (choice.KeyChar == 'l')
                    page = 4;
            }
            return invs;
        }
        private void UI(List<string[,]> invs, int page)
        {
            Console.Clear();
            Console.WriteLine("        Page " + (page + 1) + " / " + invs.Count() + "\n");
            invs[page] = InvDisplay(invs[page], page);
        }
    }
}