///ETML
///Auteur : Kaeno Eyer
///Date : 18.02.2024
///Description : Classe qui gère le score et le high-score des joueurs
///
using System;
using System.Collections.Generic;

namespace Projet_SpicyInvader
{
    internal class Score
    {
        private int _indicator = 0;
        private int _score = 0;
        private int _highScore = 0;
        public int score { get { return _score; } set { _score = value; } }
        public int highScore { get { return _highScore; } }

        /// <summary>
        /// Ajoute des points au score
        /// </summary>
        public void AddPoints()
        {
            _indicator += 10;
            if (_indicator % 200 == 0)
            {
                _score += 10;

                if (_score > _highScore)
                {
                    _highScore = _score;
                }
            }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Score : {_score}    High-Score : {_highScore} ");
        }
    }
}