///ETML
///Auteur : Kaeno Eyer
///Date : 25.01.2024
///Description : Classe contenant les propriétés du missile
///
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Projet_SpicyInvaderTests")]

namespace Projet_SpicyInvader
{
    internal class Missile
    {
        internal int _x;
        internal int _y;
        private bool _missileLaunched = false;
        private bool _missileEnd = false;
        private bool _isLaunchedByPlayerShip = true;

        public bool missileLaunched { get { return _missileLaunched; } set { _missileLaunched = value; } }
        public bool missileEnd { get { return _missileEnd; } set { _missileEnd = value; } }
        public bool isLaunchedByPlayerShip { get { return _isLaunchedByPlayerShip; } set { _isLaunchedByPlayerShip = value; } }

        public Missile(int XBeginning, int YBeginning)
        {
            _x = XBeginning;
            _y = YBeginning;
        }
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Lancement du missile du joueur lors de l'appelle de cette méthode
        /// </summary>
        /// <param name="playerShip"></param>
        public void LaunchMissile(PlayerShip playerShip)
        {
            //S'il n'y a pas de missile lancé en cours, déclenche le lancement
            if (_missileLaunched is false)
            {
                _x = playerShip.PositionX;
                _y = 33;
                _missileLaunched = true;
            }
        }

        /// <summary>
        /// Fait avancer le missile du joueur et de l'ennemi
        /// </summary>
        public void Progress()
        {
            if (_isLaunchedByPlayerShip is true)
            {
                _y--;
            }
            else if (isLaunchedByPlayerShip is false)
            {
                _y++;
            }
        }

        /// <summary>
        /// Met à jour les données du missile de l'user
        /// </summary>
        public void Update()
        {
            if (_y == 0)
            {
                _missileLaunched = false;
            }
            else if (missileLaunched is true)
            {
                Progress();
            }
        }

        /// <summary>
        /// Met à jour les données du missile ennemies et gère le niveau de difficulté
        /// </summary>
        /// <param name="Enemies"></param>
        public void UpdateEnemies(Invaders Enemies, bool difficulty)
        {
            Random r = new Random();
            int random = 0;
            _isLaunchedByPlayerShip = false;

            //Gère le niveau de difficulté
            if (difficulty is false)
            {
                random = r.Next(6);

            }
            else if (difficulty is true)
            {
                random = r.Next(2);
                Progress();
                DrawMissile();
            }

            //Gère l'envoie des missiles ennemies
            if (_missileEnd is true)
            {
                _missileLaunched = false;
            }
            if (random == 1 && _missileLaunched is false)
            {
                _x = Enemies.invaders[Enemies.NUMBERINVADERS - 1].X;
                _y = Enemies.invaders[Enemies.NUMBERINVADERS - 1].Y;
                _missileLaunched = true;
            }
        }

        /// <summary>
        /// Gère la collision des missiles ennemies avec le vaisseau ou les missiles de celui-ci
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public void CollisionEnemies(PlayerShip playerShip, Missile m)
        {
            //si un missile ennemi touche le vaisseau
            if (hitbox().IntersectsWith(playerShip.hitbox()))
            {
                playerShip.nbLife--;
                playerShip.ShowLife();

                //Si l'user n'a plus de vie -> PERDU
                if (playerShip.nbLife == 0)
                {
                    Game.GameOver(playerShip);
                }
                playerShip.ClearSpaceShipActualPosition();
                playerShip.PositionX = 60;
                UnDrawMissileActualPosition();
            }

            //Supprime le missile du Spaceship et celui de l'ennemi si les 2 se touchent
            if (hitbox().IntersectsWith(m.hitbox()))
            {
                m.UnDrawMissileActualPosition();
                UnDrawMissileActualPosition();
            }
        }

        /// <summary>
        /// Affiche le missile
        /// </summary>
        public void DrawMissile()
        {
            //Si un missile a été lancé, alors ça le dessine
            if (_missileLaunched == true)
            {
                Console.SetCursorPosition(_x + 2, _y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("¦");
                Console.ResetColor();
                UnDrawMissile();//Supprime l'ancienne position

                //Supprime la position actuelle si le missile atteint sa limite
                if (_y == 2 || _y >= 38 || _missileEnd is true)
                {
                    UnDrawMissileActualPosition();
                }
            }
        }

        /// <summary>
        /// Efface le missile dans sa position précédente
        /// </summary>
        public void UnDrawMissile()
        {
            if (_isLaunchedByPlayerShip is true)
            {
                Console.SetCursorPosition(_x + 2, _y + 2);
            }
            else if (_isLaunchedByPlayerShip is false)
            {
                Console.SetCursorPosition(_x + 2, _y - 2);
            }
            Console.Write(" ");
        }

        /// <summary>
        /// Efface le missile dans sa position actuelle
        /// </summary>
        public void UnDrawMissileActualPosition()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(_x + 2, _y + 1 - i);
                Console.Write(" ");
            }
            _x = 1;
            _y = 2;
            missileLaunched = false;
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