using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Equipment : Item
    {
        string type = null;
        int ihp = 0;

        public Equipment()
        {
            equipable = true;
        }
        public int IHP
        {
            get { return ihp; }
            set { ihp = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
