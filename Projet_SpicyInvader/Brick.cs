///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Classe contenant les propriétés d'une brique
///
using System;

namespace Projet_SpicyInvader
{
    public class Brick
    {
        //Position de la brique
        private int _x;
        private int _y;

        //Style de la brique
        private string _brick = "█";
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public string Bricks { get { return _brick; } set { _brick = value; } }
    }
}