using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_SpicyInvader
{
    internal class Brick
    {
        private int _x = 10;
        private int _y = 28;

        public int x { get { return _x; } set { _x = value; } }
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        
        public void Draw()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        Console.SetCursorPosition(_x + i, _y +j);
                        Console.WriteLine("¬");
                    }
                }
                _x += 25;
            }


        }
    }
}
