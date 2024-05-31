///ETML
///Auteur : Kaeno Eyer
///Date : 19.04.2024
///Description : Classe contenant les propriétés de l'ennemi
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Projet_SpicyInvaderTests")]

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Ennemis
    /// </summary>
    public class Invaders
    {        
        /// <summary>
        /// Définit la vitesse des ennemis à l'aide d'un modulo
        /// </summary>
        private int _invadersSpeed = 0;

        /// <summary>
        /// Position Y de l'ennemi
        /// </summary>
        private int _y = 3;

        /// <summary>
        /// Position X de l'ennemi
        /// </summary>
        private int _x = 5;

        /// <summary>
        /// Limite de l'écran gauche pour un ennemi
        /// </summary>
        private int _borderLimitLeft = 5;

        /// <summary>
        /// Limite de l'écran droite pour un ennemi
        /// </summary>
        private int _borderLimitRight = 110;

        /// <summary>
        /// Définit si l'ennemi va à droite où à gauche
        /// </summary>
        internal bool goLeftElseRight = false;

        /// <summary>
        /// Contient le nombre d'ennemies encore en vie
        /// </summary>
        private int _numberInvaders = 15;

        /// <summary>
        /// Liste contenant tous les ennemies
        /// </summary>
        List<Invaders> _invaders = new List<Invaders>();

        ///<summary>
        /// Position Y de l'ennemi {get ; set}
        /// </summary>
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        ///  Position X de l'ennemi {get ; set}
        /// </summary>
        public int X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Contient le nombre d'ennemies encore en vie {get ; set}
        /// </summary>
        public int NumberInvaders { get { return _numberInvaders; } set { _numberInvaders = value;} }

        /// <summary>
        /// Liste contenant tous les ennemies {get ; set}
        /// </summary>
        public List<Invaders> Invaderss { get { return _invaders; } set { _invaders = value; } }

        public Game Game
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Déplacement de l'ennemi
        /// </summary>
        public void Update()
        {
            _invadersSpeed += 15;
            if (_invadersSpeed % 10 == 0)
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

                    if (enemies._x == _borderLimitRight)
                    {
                        Console.SetCursorPosition(_borderLimitRight, enemies._y);
                        UndrawActualPosition();
                        foreach (Invaders enemiess in _invaders)
                        {
                            enemiess._y++;
                            Console.SetCursorPosition(enemiess._x -1, enemiess._y - 1);
                            Console.WriteLine("      ");
                        }
                        goLeftElseRight = true;
                    }
                    else if (enemies._x == _borderLimitLeft)
                    {
                        Console.SetCursorPosition(_borderLimitLeft, enemies._y);
                        UndrawActualPosition();
                        foreach (Invaders enemiess in _invaders)
                        {
                            enemiess._y++;
                            Console.SetCursorPosition(enemiess._x + 1, enemiess._y - 1);
                            Console.WriteLine("      ");
                        }
                        goLeftElseRight = false;
                    }
                }
            }
        }

        /// <summary>
        /// Créer un ennemi et ses propriétés, et l'ajoute à la liste d'ennemis 
        /// </summary>
        public void CreateInvaders()
        {
            goLeftElseRight = false;
            _y = 5;
            _x = 5;

            for (int j = 0; j < _numberInvaders; j++)
            {
                if (j == 5 || j == 10)
                {
                    this._x = 5;
                    this._y++;
                }

                _invaders.Add(new Invaders());
                _invaders[j]._x = this._x;
                _invaders[j]._y = this._y;

                this._x += 6;
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
                    Console.SetCursorPosition(enemies._x -1, enemies._y);
                    Console.Write(" ");
                }
                else if (goLeftElseRight is true)
                {
                    Console.SetCursorPosition(enemies._x +5, enemies._y);
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
        /// Gère les collisions de l'ennnemi
        /// </summary>
        /// <param name="m">Missile du vaisseau</param>
        /// <param name="score">Score de la partie</param>
        /// <param name="playerShip">Vaisseau de l'user</param>
        public void Collision(Missile m, Score score, PlayerShip playerShip)
        {
            for (int j = 0; j < _numberInvaders; j++)
            {
                //Supprime l'ennemi et le missile si les 2 se touchent
                if (m.hitbox().IntersectsWith(_invaders[j].hitbox()))
                {
                    m.UnDrawMissileActualPosition();
                    _invaders[j].UndrawActualPosition();
                    _invaders.RemoveAt(j);
                    _numberInvaders--;

                    //Si le groupe d'ennemi est tué, un autre réapparait
                    if (_invaders.Count() == 0)
                    {
                        _numberInvaders = 15;
                        CreateInvaders();
                    }
                    score.Scoree += 20;
                    break;
                }
            }
            //Si l'ennemi est sur la même hauteur que le vaisseau -> PERDU
            if (_invaders[_numberInvaders - 1].Y == 35)
            {
                Game.GameOver(playerShip);
            }
        }

        /// <summary>
        /// Hitbox de l'ennemi
        /// </summary>
        /// <returns>retourne la hitbox</returns>
        public Rectangle hitbox()
        {
            return new Rectangle(_x, _y, 5, 1);
        }
    }
}