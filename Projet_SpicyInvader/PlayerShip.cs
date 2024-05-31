///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Contient les propriétés du vaisseau
///
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Projet_SpicyInvaderTests")]

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Vaisseau de l'user
    /// </summary>
    public class PlayerShip
    {
        /// <summary>
        /// Position X du vaisseau, commence au milieu de la console 
        /// </summary>
        private int _positionX = Console.WindowWidth / 2;

        /// <summary>
        /// Position Y du vaisseau se trouvant toujoura sur la même ligne
        /// </summary>
        private const int _POSITIONY = 35;

        /// <summary>
        /// Détermine si l'user a atteint la limite du coté gauche ou non
        /// </summary>
        private bool _isAllLeft = false;

        /// <summary>
        /// Détermine si l'user est en vie
        /// </summary>
        private bool _alive = true;

        /// <summary>
        /// Contient le nombre de vie de l'user
        /// </summary>
        private int _nbLife = 3;

        /// <summary>
        /// Position X du vaisseau {get ; set}
        /// </summary>
        public int PositionX { get { return _positionX; } set { _positionX = value; } }

        /// <summary>
        /// Détermine si l'user est en vie {get ; set}
        /// </summary>
        public bool Alive { get { return _alive; } set { _alive = value; } }

        /// <summary>
        /// Contient le nombre de vie de l'user {get ; set}
        /// </summary>
        public int NbLife { get { return _nbLife; } set { _nbLife = value; } }

        public Game Game
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Déplacement du vaisseau
        /// </summary>
        /// <param name="boolchoice">Différencie le déplacement de gauche à droite de l'inverse</param>
        public void Move(bool boolchoice)
        {
            //Si c'est faux, il se déplace à gauche, si c'est vrai, à droite.                    
            if (boolchoice == false)
            {
                if (_positionX > 5)
                {
                    _positionX--;
                    _isAllLeft = true;
                }
            }
            else if (boolchoice == true)
            {
                if (_positionX < 110)
                {
                    _positionX++;
                    _isAllLeft = false;
                }
            }        
        }
            
        /// <summary>
        /// Affiche le vaisseau
        /// </summary>
        public void Draw()
        {
            ClearSpaceship();
            Console.SetCursorPosition(_positionX, _POSITIONY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                if (_isAllLeft == true)
                {
                    if (_positionX == 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(_positionX + 5 - i , 35);
                        Console.Write("  ");

                    }
                }
                else
                {
                    if (_positionX == 109)
                    {
                        break;                            
                    }
                    else
                    {
                        Console.SetCursorPosition(_positionX - i , 35);
                        Console.Write(" ");
                    }
                }
            }
        }

        /// <summary>
        /// Supprime la position actuelle du vaisseau lorsqu'il est touché
        /// </summary>
        public void ClearSpaceShipActualPosition()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(_positionX + 3 - i, 35);
                Console.Write("  ");
            }
        }

        /// <summary>
        /// hitbox du vaisseau
        /// </summary>
        /// <returns>Retourne la hitbox du vaisseau</returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_positionX, _POSITIONY, 5, 1);
        }

        /// <summary>
        /// Affiche la vie du vaisseau
        /// </summary>
        public void ShowLife()
        {
            Console.SetCursorPosition(110, 38);
            Console.WriteLine($"Life : {NbLife}");
        }
    }    
}