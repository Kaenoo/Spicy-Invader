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


namespace Projet_SpicyInvader
{
            
    /// <summary>
    /// Classe vaisseau
    /// </summary>
    internal class PlayerShip
    {
        int _positionSpaceshipX = 120/2;
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
        public void Move(bool boolchoice)
        {
            //
                    
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

           /* ConsoleKeyInfo SpaceshipMovement;

              Draw();
                       
                SpaceshipMovement = Console.ReadKey();

                switch (SpaceshipMovement.Key)
                {

                    case ConsoleKey.LeftArrow:
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
                        break;*/
                /*}            
*/        }
            
        /// <summary>
        /// Affiche le vaisseau
        /// </summary>
        public void Draw()
        {
            ClearSpaceship();
            Console.SetCursorPosition(_positionSpaceshipX, 35);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("('-')");
            Console.ResetColor();
            
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
