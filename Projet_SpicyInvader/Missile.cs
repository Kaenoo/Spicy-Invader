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
    /// <summary>
    /// Missile
    /// </summary>
    public class Missile
    {
        /// <summary>
        /// Position X du missile
        /// </summary>
        internal int _x;

        /// <summary>
        /// Position Y du missile
        /// </summary>
        internal int _y;

        /// <summary>
        /// Détermine si le missile est lancé ou non
        /// </summary>
        private bool _missileLaunched = false;

        /// <summary>
        /// Détermine si le missile a fini sa trajectoire ou non
        /// </summary>
        private bool _missileEnd = false;

        /// <summary>
        /// Détermine si le missile est lancé par l'user ou l'ennemi
        /// </summary>
        private bool _isLaunchedByPlayerShip = true;

        /// <summary>
        /// Détermine si le missile est lancé ou non {get ; set}
        /// </summary>
        public bool MissileLaunched { get { return _missileLaunched; } set { _missileLaunched = value; } }

        /// <summary>
        /// Détermine si le missile a fini sa trajectoire ou non {get ; set}
        /// </summary>
        public bool MissileEnd { get { return _missileEnd; } set { _missileEnd = value; } }

        /// <summary>
        /// Détermine si le missile est lancé par l'user ou l'ennemi {get ; set}
        /// </summary>
        public bool IsLaunchedByPlayerShip { get { return _isLaunchedByPlayerShip; } set { _isLaunchedByPlayerShip = value; } }

        /// <summary>
        /// Classe missile demandant les positions de départ du missile
        /// </summary>
        /// <param name="XBeginning"></param>
        /// <param name="YBeginning"></param>
        public Missile(int XBeginning, int YBeginning)
        {
            _x = XBeginning;
            _y = YBeginning;
        }

        /// <summary>
        /// Position X du missile {get ; set}
        /// </summary>
        public int X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Position X du missile {get ; set}
        /// </summary>
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Lancement du missile du joueur lors de l'appelle de cette méthode
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
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
            else if (IsLaunchedByPlayerShip is false)
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
            else if (MissileLaunched is true)
            {
                Progress();
            }
        }

        /// <summary>
        /// Met à jour les données du missile ennemies et gère le niveau de difficulté
        /// </summary>
        /// <param name="Enemies">Ennemis</param>
        /// <param name="difficulty">Définit la difficulté</param>
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
                random = r.Next(3);
            }

            //Gère l'envoie des missiles ennemies
            if (_missileEnd is true)
            {
                _missileLaunched = false;
            }
            if (random == 1 && _missileLaunched is false)
            {
                _x = Enemies.Invaderss[Enemies.NumberInvaders - 1].X;
                _y = Enemies.Invaderss[Enemies.NumberInvaders - 1].Y;
                _missileLaunched = true;
            }
        }

        /// <summary>
        /// Gère la collision des missiles ennemies avec le vaisseau ou les missiles de celui-ci
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
        /// <param name="m">Missile du vaisseau</param>
        public void CollisionEnemies(PlayerShip playerShip, Missile m)
        {
            //si un missile ennemi touche le vaisseau
            if (hitbox().IntersectsWith(playerShip.hitbox()))
            {
                playerShip.NbLife--;
                playerShip.ShowLife();

                //Si l'user n'a plus de vie -> PERDU
                if (playerShip.NbLife == 0)
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
            _x = 10;
            _y = 1;
            MissileLaunched = false;
        }

        /// <summary>
        /// Hitbox du missile
        /// </summary>
        /// <returns>Retourne la hitbox du missile</returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_x + 2, _y, 1, 2);
        }

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}