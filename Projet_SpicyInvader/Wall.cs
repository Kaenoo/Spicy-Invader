using System;
using System.Drawing;

namespace Projet_SpicyInvader
{
    internal class Wall
    {
        private int _x = 10;
        private int _y = 28;
        private const int _WIDTHWALL = 15;
        private const int _HEIGHTWALL= 3;
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
        /// Crée les murs
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
                        walls[k]._brick[i, j] = new Brick();
                        walls[k]._brick[i, j].x = _x + i;
                        walls[k]._brick[i, j].y = _y + i;
                        Console.SetCursorPosition(_x + i, _y + j);
                        Console.WriteLine(walls[k]._brick[i, j].brick);
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


         /*   if (_brick[a, b].brick == "¬")
            {
                _brick[a, b].brick = "-";
                _isTouched = true;
            }
            else if (_brick[a, b].brick == "-")
            {
                _brick[a, b].brick = " ";
                _isTouched = true;
                
            }
            else
            {
                _isTouched = false;
            }
            
            return _isTouched;*/
        }
    }
}
