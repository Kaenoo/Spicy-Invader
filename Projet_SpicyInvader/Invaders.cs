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
        private int _y = 3;
        private int _x = 5;
        private bool _invadersdie = false;
        internal bool goLeftElseRight = false;
        private int _NUMBERINVADERS = 15;
        List<Invaders> _invaders = new List<Invaders>();

        public int Y { get { return _y; } set { _y = value; } }
        public int X { get { return _x; } set { _x = value; } }
        public int NUMBERINVADERS { get { return _NUMBERINVADERS; } set { _NUMBERINVADERS = value;} }
        public bool Invadersdie { get { return _invadersdie; } set { _invadersdie = value; } }
        public List<Invaders> invaders { get { return _invaders; } set { _invaders = value; } }

        /// <summary>
        /// Déplacement de l'ennemi
        /// </summary>
        public void Update()
        {
            foreach (Invaders enemies in _invaders)
            {
                if (goLeftElseRight is false)
                {
                    enemies._x++;
                }
                else if (goLeftElseRight is true)
                {
                    enemies._x--;
                }

                if (enemies._x == 110)
                {
                    Console.SetCursorPosition(110, _y);
                    UndrawActualPosition();
                    foreach (Invaders enemiess in _invaders){ enemiess._y++;}
                    goLeftElseRight = true;
                }
                else if (enemies._x == 5)
                {
                    Console.SetCursorPosition(5, _y);
                    UndrawActualPosition();
                    foreach (Invaders enemiess in _invaders) { enemiess._y++; }
                    goLeftElseRight = false;
                }
            }            
        }

        /// <summary>
        /// Créer un ennemi et ses propriétés, et l'ajoute à la liste d'ennemis 
        /// </summary>
        public void CreateInvaders()
        {
            for (int j = 0; j < 15; j++)
            {
                if (j == 5 || j == 10)
                {
                    this._x = 5;
                    this._y++;
                }

                invaders.Add(new Invaders());
                invaders[j]._x = this._x;
                invaders[j]._y = this._y;

                this._x += 5;
            }            
        }

        /// <summary>
        /// Dessine l'ennemi dans sa position actuelle
        /// </summary>
        public void Draw()
        {
            foreach (Invaders enemies in _invaders)
            {
                Console.SetCursorPosition(enemies._x, enemies._y);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("´-_-`");
                Console.ResetColor();
                Undraw();

            }
        }
        /// <summary>
        /// Efface l'ennemi dans son ancienne position
        /// </summary>
        public void Undraw()
        {
            foreach (Invaders enemies in _invaders)
            {
                if (goLeftElseRight is false)
                {
                    Console.SetCursorPosition(enemies._x, enemies._y);
                    Console.Write(" ");
                }
                else if (goLeftElseRight is true)
                {
                    Console.SetCursorPosition(enemies._x, enemies._y);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Efface l'ennemi dans sa position actuelle
        /// </summary>
        public void UndrawActualPosition()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write("     ");
        }

        /// <summary>
        /// Si un ennemie est touché, il meurt
        /// </summary>
        public void InvaderDie(List<Invaders> Enemies, int index)
        {
            Enemies.RemoveAt(index);
            invaders[index].UndrawActualPosition();
        }

        /// <summary>
        /// Hitbox de l'ennemi
        /// </summary>
        /// <returns>Rectangle</returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_x, _y, 5, 1);
        }
    }
}