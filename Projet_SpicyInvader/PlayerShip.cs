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


namespace Projet_SpicyInvader
{
            
    /// <summary>
    /// Classe vaisseau
    /// </summary>
    internal class SpaceShip
    {
        int _positionSpaceshipX;
        int _lives = 3;
        bool _clearAThing = false;
        bool _alive = true;

        public bool Alive()
        {
            return _alive;
        }
            

        /// <summary>
        /// Déplacement du vaisseau
        /// </summary>
        public void Update()
        {
            //
            _positionSpaceshipX = 120 / 2;

            ConsoleKeyInfo SpaceshipMovement;

            do
            {
                Draw();
                       
                SpaceshipMovement = Console.ReadKey();

                switch (SpaceshipMovement.Key)
                {

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if (_positionSpaceshipX == 6)
                        {
                            break;
                        }
                        else
                        {
                            _positionSpaceshipX--;
                            _clearAThing = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (_positionSpaceshipX == 110)
                        {
                            break;
                        }
                        else
                        {
                            _positionSpaceshipX++;
                            _clearAThing=false;
                        }
                        break;                       
                    default:
                        break;
                }

            } while (SpaceshipMovement.Key != ConsoleKey.Escape);
        }
            
        /// <summary>
        /// Affiche le vaisseau
        /// </summary>
        public void Draw()
        {
            ClearSpaceship();
            Console.SetCursorPosition(_positionSpaceshipX, 35);
            Console.Write("('-')");
        }

        /// <summary>
        /// Supprime le vaisseau de la position pécédente
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
                        Console.SetCursorPosition(_positionSpaceshipX - i + 5, 35);
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
                        Console.Write("  ");
                    }
                }
            }
        }

        /// <summary>
        /// Vérifie que le vaisseau est en vie
        /// </summary>
        public void IsAlive()
        {
            if (_lives > 0)
            {
                _alive = true;
            }
        }

        public int PositionX
        {
            get { return _positionSpaceshipX; }
            set { _positionSpaceshipX = value; }
        }
    }       
    
}
