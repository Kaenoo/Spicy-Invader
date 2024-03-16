using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_SpicyInvader
{
    internal class Brick
    {
        private int _x;
        private int _y;
        private string _brick = "¬";
        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
        public string brick { get { return _brick; } set { _brick = value; } }


    }
}
