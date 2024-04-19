///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Contient les objets du jeu
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using System.Drawing;


namespace Projet_SpicyInvader
{
            
    /// <summary>
    /// Classe vaisseau
    /// </summary>
    internal class PlayerShip
    {
        private int _positionSpaceshipX = 120/2;
        private const int _POSITIONSPACESHIPY = 35;
        bool _clearAThing = false;
        private bool _alive = true;
        private int _nbLife = 3;

        public int positionSpaceshipX { get { return _positionSpaceshipX; }}
        public int PositionX { get { return _positionSpaceshipX; } set { _positionSpaceshipX = value; } }
        public bool alive { get { return _alive; } set { _alive = value; } }
        public int nbLife { get { return _nbLife; } set { _nbLife = value; } }

        /// <summary>
        /// Détermine si l'user est en vie
        /// </summary>
        /// <returns></returns>
        public bool Alive()
        {
            return _alive;
        }         

        /// <summary>
        /// Déplacement du vaisseau
        /// </summary>
        public void Move(bool boolchoice)
        {
            //Si c'est faux, il se déplace à gauche, si c'est vrai, à droite.                    
            if (boolchoice == false)
            {
                if (_positionSpaceshipX > 5)
                {
                    _positionSpaceshipX--;
                    _clearAThing = true;
                }
            }
            else if (boolchoice == true)
            {
                if (_positionSpaceshipX < 110)
                {
                    _positionSpaceshipX++;
                    _clearAThing = false;
                }
            }        
        }
            
        /// <summary>
        /// Affiche le vaisseau
        /// </summary>
        public void Draw()
        {
            ClearSpaceship();
            Console.SetCursorPosition(_positionSpaceshipX, _POSITIONSPACESHIPY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("('-')");
            Console.ResetColor();
        }

        /// <summary>
        /// Supprime le vaisseau de sa position pécédente
        /// </summary>
        public void ClearSpaceship()
        {
            for (int i = 0; i < 5; i++)
            {
                if (_clearAThing == true)
                {
                    if (_positionSpaceshipX == 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(_positionSpaceshipX + 5 - i , 35);
                        Console.Write("  ");

                    }
                }
                else
                {
                    if (_positionSpaceshipX == 109)
                    {
                        break;                            
                    }
                    else
                    {
                        Console.SetCursorPosition(_positionSpaceshipX - i , 35);
                        Console.Write(" ");
                    }
                }
            }
        }

        public void ClearSpaceShipActualPosition()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(_positionSpaceshipX + 3 - i, 35);
                Console.Write("  ");
            }
        }

        /// <summary>
        /// hitbox du vaisseau
        /// </summary>
        /// <returns></returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_positionSpaceshipX, _POSITIONSPACESHIPY, 5, 1);
        }

        public void ShowLife()
        {
            Console.SetCursorPosition(110, 38);
            Console.WriteLine($"Life : {nbLife}");
        }

    }    
}