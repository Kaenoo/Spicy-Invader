///ETML
///Auteur : Kaeno Eyer
///Date : 19.04.2024
///Description : Classe contenant les propriétés du mur
///
using System;

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Mur
    /// </summary>
    public class Wall
    {
        /// <summary>
        /// Position X du mur
        /// </summary>
        private int _x = 10;

        /// <summary>
        /// Position Y du mur
        /// </summary>
        private int _y = 28;

        /// <summary>
        /// Contient le nombre de briques du mur en largeur
        /// </summary>
        private const int _WIDTHWALL = 15;

        /// <summary>
        /// Contient le nombre de briques du mur en hauteur
        /// </summary>
        private const int _HEIGHTWALL= 2;

        /// <summary>
        /// Contient le nombre de mur
        /// </summary>
        private const int _NBWALL = 4;

        /// <summary>
        /// tableau de murs
        /// </summary>
        private Wall[] _walls = new Wall[_NBWALL];

        /// <summary>
        /// Tableau de briques à 2 dimensions
        /// </summary>
        private Brick[,] _brick = new Brick[_WIDTHWALL, _HEIGHTWALL];

        /// <summary>
        /// Détermine si une brique est touchée ou non
        /// </summary>
        private bool _isTouched = false;

        /// <summary>
        /// Position X du mur {get ; set}
        /// </summary>
        public int X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Position Y du mur {get ; set}
        /// </summary>
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Contient le nombre de briques du mur en largeur {get ; set}
        /// </summary>
        public int WIDTHWALL { get { return _WIDTHWALL; } }

        /// <summary>
        /// Contient le nombre de briques du mur en hauteur {get ; set}
        /// </summary>
        public int HEIGHTWALL { get { return _HEIGHTWALL; } }

        /// <summary>
        /// tableau de murs {get ; set}
        /// </summary>
        public Wall[] Walls { get { return _walls; } set { _walls = value; } }

        /// <summary>
        /// tableau de briques à 2 dimensions {get ; set}
        /// </summary>
        public Brick[,] Brick {  get { return _brick; } }

        /// <summary>
        /// Jeu {get ; set}
        /// </summary>
        public Game Game
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Créé les murs
        /// </summary>
        public void CreateWallOfBrick()
        {
            for (int k = 0; k < _NBWALL ; k++)
            {
                _walls[k] = new Wall();
                for (int j = 0; j < _HEIGHTWALL; j++)
                {
                    for (int i = 0; i < _WIDTHWALL; i++)
                    {
                        _walls[k]._brick[i, j] = new Brick();
                        _walls[k]._brick[i, j].X = _x + i;
                        _walls[k]._brick[i, j].Y = _y + j;
                        Console.SetCursorPosition(_x + i, _y + j);
                        Console.WriteLine(_walls[k]._brick[i, j].Bricks);
                    }
                }
                _x += 25;                
            }   
            _x = 10;
            _y = 28;
        }

        /// <summary>
        /// Dessine les murs
        /// </summary>
        public void Draw()
        {
            foreach (Wall w in _walls)
            {
                for (int j = 0; j < _HEIGHTWALL; j++)
                {
                    for (int i = 0; i < _WIDTHWALL; i++)
                    {
                        Console.SetCursorPosition(_x + i, _y + j);
                        Console.WriteLine(w._brick[i, j].Bricks);
                    }
                }
                _x += 25;
            }
            _x = 10;
            _y = 28;
        }

        /// <summary>
        /// Si le mur est touché par un missile
        /// </summary>
        /// <param name="a">Premier index du tableau</param>
        /// <param name="b">Deuxième index du tableau</param>
        /// <returns>Retourne si le mur a été touché ou non</returns>
        public bool Touch(int a, int b) 
        {
            switch (_brick[a, b].Bricks)
            {
                case "█":
                    _brick[a, b].Bricks = "▒";
                    _isTouched = true;
                    return _isTouched;
                case "▒":
                    _brick[a, b].Bricks = " ";
                    _isTouched = true;
                    return _isTouched;
                default: 
                    _isTouched = false;
                    return _isTouched;
            }
        }

        /// <summary>
        /// Gère la collision entre les murs et les missiles
        /// </summary>
        /// <param name="m">Missile du vaisseau</param>
        /// <param name="ME">Missile de l'ennemi</param>
        public void Collision(Missile m, Missile ME)
        {
            //Abime une brique du mur si touchée 1 fois, la détruit si touchée 2 fois + supprime le missile lorsqu'il touche une brique
            foreach (Wall w in _walls)
            {
                for (int j = _HEIGHTWALL - 1; j >= 0; j--)
                {
                    for (int i = 0; i < _WIDTHWALL; i++)
                    {
                        //Si un missile de l'user touche une brique
                        if (w.Brick[i, j].X == m.X + 2 && w.Brick[i, j].Y == m.Y)
                        {
                            bool collision = false;
                            collision = w.Touch(i, j);

                            if (collision is true)
                            {
                                m.UnDrawMissileActualPosition();
                            }
                            break;
                        }

                        //Si un missile de l'ennemi touche une brique
                        if (w.Brick[i, j].X == ME.X + 2 && w.Brick[i, j].Y == ME.Y)
                        {
                            bool collision = false;
                            collision = w.Touch(i, j);

                            if (collision is true)
                            {
                                ME.UnDrawMissileActualPosition();
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}