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

namespace Projet_SpicyInvader
{
    internal class Missile
    {
        private int _x;
        private int _y;
        int _livesMissiles = 1;

        public int X { get => _x; }
        public int Y { get => _y; }

        public Missile(int XBeginning, int YBeginning)
        {
            _x = XBeginning;
            _y = YBeginning;
        }
       
        /// <summary>
        /// Tire les missiles
        /// </summary>
        public void Shoot()
        {
                for (int i = 0; i < 32; i++)
                {
                    DrawMissile();
                    _y--;
                }
            /*do
            {

            } while (_livesMissiles != 0);*/
        }

        /// <summary>
        /// Affiche le missile
        /// </summary>
        public void DrawMissile()
        {
           // UnDrawMissile();
            Console.SetCursorPosition(_x, _y);
            Console.Write("¦");
        }

        /// <summary>
        /// Efface le missile
        /// </summary>
        public void UnDrawMissile()
        {
            Console.SetCursorPosition(X, Y + 1);
            Console.Write(" ");
        }
    }
}
