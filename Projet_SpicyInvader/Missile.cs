///ETML
///Auteur : Kaeno Eyer
///Date : 25.01.2024
///Description : Classe qui permet à l'user de tirer
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Projet_SpicyInvader
{
    internal class Missile
    {
        internal int _x;
        internal int _y;
        private bool _isMissile = false;

        public bool IsMissile
        {
            get { return _isMissile; }
            set { _isMissile = value; }
        }

        public Missile(int XBeginning, int YBeginning)
        {
            _x = XBeginning;
            _y = YBeginning;
        }
        public int X { get => _x; }
        public int Y { get => _y; }

        /// <summary>
        /// Tire les missiles
        /// </summary>
        public void Shoot()
        {
            _y--;
        }

        /// <summary>
        /// Affiche le missile
        /// </summary>
        public void DrawMissile()
        {
            Console.SetCursorPosition(_x + 2, _y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("¦");
            Console.ResetColor();
            UnDrawMissile();
            if (_y == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(_x + 2, _y + 2 -i);
                    Console.Write(" ");
                }                
            }
        }

        /// <summary>
        /// Efface le missile
        /// </summary>
        public void UnDrawMissile()
        {                       
            Console.SetCursorPosition(_x + 2, _y +2);
            Console.Write(" ");                                               
        }

        public void UnDrawMissileActualPosition()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(_x + 2, _y + 2 - i);
                Console.Write(" ");
            }
        }

        public Rectangle hitbox()
        {
            return new Rectangle(_x, _y, 1, 2);
        }
    }
}
