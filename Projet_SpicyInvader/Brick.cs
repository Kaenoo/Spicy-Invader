///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Classe contenant les propriétés d'une brique
///
using System;

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Brique
    /// </summary>
    public class Brick
    {
        /// <summary>
        /// Position X de la brique
        /// </summary>
        private int _x;

        /// <summary>
        /// Position Y de la brique
        /// </summary>
        private int _y;

        /// <summary>
        /// Style de la brique
        /// </summary>
        private string _brick = "█";

        /// <summary>
        /// Position X de la brique {get ; set}
        /// </summary>
        public int X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Position X de la brique {get ; set}
        /// </summary>
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Style de la brique {get ; set}
        /// </summary>
        public string Bricks { get { return _brick; } set { _brick = value; } }

        /// <summary>
        /// Mur {get ; set}
        /// </summary>
        public Wall Wall
        {
            get => default;
            set
            {
            }
        }
    }
}