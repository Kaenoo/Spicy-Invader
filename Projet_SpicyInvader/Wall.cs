using System;
using System.Drawing;

namespace Projet_SpicyInvader
{
    internal class Wall
    {
        private int _x = 10;
        private int _y = 28;
        private const int _WIDTHWALL = 15;
        private const int _HEIGHTWALL= 2;
        private const int _NBWALL = 4;
        private Wall[] _walls = new Wall[_NBWALL];
        private Brick[,] _brick = new Brick[_WIDTHWALL, _HEIGHTWALL];
        private bool _isTouched = false;
                
        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
        public int WIDTHWALL { get { return _WIDTHWALL; } }
        public int HEIGHTWALL { get { return _HEIGHTWALL; } }
        public Wall[] walls { get { return _walls; } set { _walls = value; } }
        public Brick[,] brick {  get { return _brick; } }

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
                        _walls[k]._brick[i, j].x = _x + i;
                        _walls[k]._brick[i, j].y = _y + j;
                        Console.SetCursorPosition(_x + i, _y + j);
                        Console.WriteLine(_walls[k]._brick[i, j].brick);
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
                        Console.WriteLine(w._brick[i, j].brick);
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="Wall1"></param>
        public bool Touch(int a, int b) 
        {
            switch (_brick[a, b].brick)
            {
                case "¬":
                    _brick[a, b].brick = "-";
                    _isTouched = true;
                    return _isTouched;
                case "-":
                    _brick[a, b].brick = " ";
                    _isTouched = true;
                    return _isTouched;
                default: 
                    _isTouched = false;
                    return _isTouched;
            }
        }

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
                        if (w.brick[i, j].x == m.X + 2 && w.brick[i, j].y == m.Y)
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
                        if (w.brick[i, j].x == ME.X + 2 && w.brick[i, j].y == ME.Y)
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