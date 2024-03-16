using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Projet_SpicyInvader
{
    internal class Invaders
    {        
        private int _Y = 3;
        private int _X = 5;
        private bool _invadersdie = false;
        internal bool goLeftElseRight = false;

        public int Y { get { return _Y; } set { _Y = value; } }
        public int X { get { return _X; } set { _X = value; } }
        public bool Invadersdie { get { return _invadersdie; } set { _invadersdie = value; } }

        /// <summary>
        /// Déplacement de l'ennemi
        /// </summary>
        public void Update()
        {
            if (goLeftElseRight is false)
            {
                _X++;
            }
            else if (goLeftElseRight is true)
            {
                _X--;
            }

            if (_X == 110)
            {
                Console.SetCursorPosition(109, _Y);
                Console.Write("     ");
                _Y++;
                goLeftElseRight = true;
            }
            else if (_X == 5)
            {
                Console.SetCursorPosition(6, _Y);
                Console.Write("     ");
                _Y++;
                goLeftElseRight = false;
            }
        }

        /// <summary>
        /// Dessine l'ennemi dans sa position actuelle
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(_X, _Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("´-_-`");
            Console.ResetColor();
            Undraw();
        }
        /// <summary>
        /// Efface l'ennemi dans son ancienne position
        /// </summary>
        public void Undraw()
        {
            if (goLeftElseRight is false)
            {
                Console.SetCursorPosition(_X - 4, _Y);
                Console.Write("    ");
            }
            else if (goLeftElseRight is true)
            {
                Console.SetCursorPosition(_X + 5, _Y);
                Console.Write("    ");
            }           
        }

        /// <summary>
        /// Efface l'ennemi dans sa position actuelle
        /// </summary>
        public void UndrawActualPosition()
        {
            Console.SetCursorPosition(_X, _Y);
            Console.Write("     ");
        }

        /// <summary>
        /// Hitbox de l'ennemi
        /// </summary>
        /// <returns></returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_X, _Y, 5, 1);
        }
    }
}