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
        private bool _missileLaunched = false;
        private bool _missileEnd = false;

        public bool missileLaunched{ get { return _missileLaunched; } set { _missileLaunched = value; }}
        public bool missileEnd{ get { return _missileEnd; } set { _missileEnd = value; }}

        public Missile(int XBeginning, int YBeginning)
        {
            _x = XBeginning;
            _y = YBeginning;
        }
        public int X { get => _x; }
        public int Y { get => _y; }

        /// <summary>
        /// Fait avancer le missile
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
            if (_y == 2 || _missileEnd is true)
            {
                UnDrawMissileActualPosition();          
            }
        }

        /// <summary>
        /// Efface le missile dans sa position précédente
        /// </summary>
        public void UnDrawMissile()
        {                       
            Console.SetCursorPosition(_x + 2, _y +2);
            Console.Write(" ");                                               
        }

        /// <summary>
        /// Efface le missile dans sa position actuelle
        /// </summary>
        public void UnDrawMissileActualPosition()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(_x + 2, _y + 2 - i);
                Console.Write(" ");
            }
            _x = 0;
            _y = 0;
        }

        /// <summary>
        /// Hitbox du missile
        /// </summary>
        /// <returns></returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_x + 2, _y, 1, 2);
        }
    }
}
