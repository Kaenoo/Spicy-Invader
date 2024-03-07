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
        internal bool leftOrRight = false;

        public int Y { get { return _Y; } set { _Y = value; } }
        public int X { get { return _X; } set { _X = value; } }
        public bool Invadersdie { get { return _invadersdie; } set { _invadersdie = value; } }
        
        /// <summary>
        /// Déplacement de l'ennemi
        /// </summary>
        public void Update()
        {
            if (leftOrRight is false)
            {
                _X++;
            }
            else if (leftOrRight is true)
            {
                _X--;
            }

            if (_X == 110)
            {
                Console.SetCursorPosition(109,_Y);
                Console.Write("     ");
                _Y++;
                leftOrRight = true;
            }
            else if (_X == 5)
            {
                Console.SetCursorPosition(6, _Y);
                Console.Write("     ");
                _Y++;
                leftOrRight = false;
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
        /// Supprime l'ennemi dans son ancienne position
        /// </summary>
        public void Undraw()
        {
            if (leftOrRight is false)
            {
                Console.SetCursorPosition(_X - 4, _Y);
                Console.Write("    ");
            }
            else if (leftOrRight is true)
            {
                Console.SetCursorPosition(_X + 5, _Y);
                Console.Write("    ");
            }           
        }

        public void UndrawActualPosition()
        {
            if (leftOrRight is false)
            {
                Console.SetCursorPosition(_X, _Y);
                Console.Write("     ");
            }
            else if (leftOrRight is true)
            {
                Console.SetCursorPosition(_X , _Y);
                Console.Write("     ");
            }
        }

        public Rectangle hitbox()
        {
            return new Rectangle(_X, _Y, 4, 2);
        }
    }
}