///ETML
///Auteur : Kaeno Eyer
///Date : 25.01.2024
///Description : Classe qui permet à l'user de tirer
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_SpicyInvader
{
    internal class Missile : GameObject
    {
        int _livesMissiles;
        int _missilePosition;
       
        public void Shoot()
        {
            _missilePosition = 36;
            ConsoleKeyInfo MissileMovement;

            do
            {
                MissileMovement = Console.ReadKey();

                if (MissileMovement.Key == ConsoleKey.Spacebar)
                {
                    for (int i = 0; i < 45; i++)
                    {
                        DrawMissile();

                    }
                }

            } while (_livesMissiles != 0);
        }

        public void DrawMissile()
        {
            UnDrawMissile();
            Console.SetCursorPosition(30, 36);
            Console.Write("¦");
        }

        public void UnDrawMissile()
        {

            Console.Write(" ");
        }
    }
}
