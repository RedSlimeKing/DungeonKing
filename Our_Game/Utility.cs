using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Utility
    {
        public Utility()
        {

        }
        public static void Pretty()
        {
            int currentLineCursor = Console.CursorTop;
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(0, currentLineCursor);
        } 
        public static void Delay()
        {
            //5 second delay
            for (int c = 1; c <= 32767; c++)
                for (int d = 1; d <= 32767; d++)
                { }
        }
        public static bool IsDigitsOnly(string couldit)
        {
            foreach (char c in couldit)
            {
                if (c < '1' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
