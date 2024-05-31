///ETML
///Auteur : Kaeno Eyer
///Date : 16.05.2024
///Description : Classe du Vaisseau du grand ennemi
///
using System;
using System.Drawing;

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Vaisseau du grand ennemi rouge
    /// </summary>
    public class SpaceshipInvader
    {
        /// <summary>
        /// Détermine si le vaisseau fait sa course
        /// </summary>
        bool _isRunning = false;

        /// <summary>
        /// Position X du vaisseau 
        /// </summary>
        int _positionX = Console.WindowWidth;

        /// <summary>
        /// Position constante Y du vaisseau
        /// </summary>
        const int _POSITIONY = 3;

        /// <summary>
        /// Contient l'affichage du vaisseau
        /// </summary>
        string _spaceShip = @"'-/^\-'";

        /// <summary>
        /// Détermine la vitesse du vaisseau
        /// </summary>
        int _timer = 0;

        /// <summary>
        /// Fait progresser la position du vaisseau
        /// </summary>
        public void Update()
        {
            if (_timer >= 600 && _timer % 1 == 0)
            {
                _isRunning = true;
                _positionX--;
            }
            if(_positionX == 6)
            {
                _timer = 0;
                _isRunning = false;
                UnDrawActualPosition(_positionX - 6);
                _positionX = Console.WindowWidth;
            }
        }

        /// <summary>
        /// Dessine le vaisseau
        /// </summary>
        public void Draw()
        {
            if (_isRunning is true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(_positionX -7, _POSITIONY);
                Console.WriteLine(_spaceShip);
                Console.ResetColor();
                UnDraw();
            }
                _timer++;
        }

        /// <summary>
        /// Supprime l'ancienne position du vaisseau
        /// </summary>
        public void UnDraw()
        {
            if (_positionX < Console.WindowWidth)
            {
                Console.SetCursorPosition( _positionX, _POSITIONY);
                Console.WriteLine(" ");
            }
        }

        /// <summary>
        /// Supprime la position actuelle du vaisseau
        /// </summary>
        /// <param name="positionX"> position x du vaisseau</param>
        public void UnDrawActualPosition(int positionX)
        {
            Console.SetCursorPosition(positionX, _POSITIONY);
            Console.WriteLine("        ");
        }

        /// <summary>
        /// Gère les collisions entre les missiles et le vaisseau et ajoute un score si collision
        /// </summary>
        /// <param name="missile">Objet missile</param>
        /// <param name="score">Classe score</param>
        public void Collision(Missile missile, Score score)
        {
            if (missile.hitbox().IntersectsWith(Hitbox()))
            {
                missile.UnDrawMissileActualPosition();
                score.Scoree += 100;
                _timer = 0;
                UnDrawActualPosition(_positionX - 7);
                _isRunning = false;
                _positionX = Console.WindowWidth;
            }
        }

        /// <summary>
        /// Hitbox du vaiseau
        /// </summary>
        /// <returns>Retourne la hitbox du vaisseau</returns>
        public Rectangle Hitbox()
        {
            return new Rectangle(_positionX - 7, _POSITIONY, 7, 1);
        }
    }
}