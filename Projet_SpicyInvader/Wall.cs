using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Projet_SpicyInvader
{
    internal class Wall
    {
        private int _x = 10;
        private int _y = 28;
        private const int _WIDTHWALL = 15;
        private const int _HEIGHTWALL= 3;
        private Wall[] _walls = new Wall[4];
        private string[,] _wall = new string[_WIDTHWALL, _HEIGHTWALL ];

        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }
        public string[,] wall { get { return _wall; } set { _wall = value; } }
        public int WIDTHWALL { get { return _WIDTHWALL; } }
        public int HEIGHTWALL { get { return _HEIGHTWALL; } }
        public Wall[] walls { get { return _walls; } }

        /// <summary>
        /// Crée les murs
        /// </summary>
        public void CreateWallOfBrick()
        {
            foreach (Wall w in _walls)
            {
                Brick[,] brick = new Brick[_WIDTHWALL, _HEIGHTWALL];
                for (int j = 0; j < _HEIGHTWALL; j++)
                {
                    for (int i = 0; i < _WIDTHWALL; i++)
                    {
                        brick[i, j] = new Brick();
                        brick[i, j].x = _x + i;
                        brick[i, j].y = _y + i;
                        _wall[i, j] = brick[i, j].brick;
                        Console.SetCursorPosition(_x + i, _y + j);
                        Console.WriteLine(_wall[i, j]);
                    }
                }
                _x += 25;
            }    
            _x = 10;
            _y = 28;
        }

        /// <summary>
        /// Dessine les murs PROBALEMENT SUPPRIMABLE
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
                        Console.WriteLine(_wall[i, j]);
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
        public void Touch(int a, int b, Brick bricks) 
        {
            if (bricks.brick == "¬" || bricks.brick == "-")
            {
                for (int j = 0; j < _HEIGHTWALL; j++)
                {
                    for (int i = 0; i < _WIDTHWALL; i++)
                    {
                        bricks.brick = "-";
                    }
                }
            }
        }
    }
}
