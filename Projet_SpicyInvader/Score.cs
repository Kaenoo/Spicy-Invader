///ETML
///Auteur : Kaeno Eyer
///Date : 18.02.2024
///Description : Classe qui gère le score et le high-score des joueurs
///
using System;
using System.IO;

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Score
    /// </summary>
    public class Score
    {
        /// <summary>
        /// Détermine la vitesse d'incrémentation du score
        /// </summary>
        private int _speedScore = 0;

        /// <summary>
        /// Contient le score acutel de l'user en partie
        /// </summary>
        private int _score = 0;

        /// <summary>
        /// Contient le meilleur score tout joueur confondu
        /// </summary>
        private int _highScore = 0;

        /// <summary>
        /// Contient le score acutel de l'user en partie {get ; set}
        /// </summary>
        public int Scoree { get { return _score; } set { _score = value; } }

        /// <summary>
        /// Contient le meilleur score tout joueur confondu {get ; set}
        /// </summary>
        public int HighScore { get { return _highScore; } set { _highScore = value; } }

        /// <summary>
        /// Instanciation de classe GameMenu
        /// </summary>
        GameMenu gameMenu = new GameMenu();

        /// <summary>
        /// Ajoute des points au score
        /// </summary>
        public void AddPoints()
        {
            _speedScore += 10;
            if (_speedScore % 200 == 0)
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

        /// <summary>
        /// Récupère le plus grand highscore stocké dans le fichier
        /// </summary>
        /// <returns>Retourne le highscore</returns>
        public int RecupHighscore()
        {
            string[] findHighscore = File.ReadAllLines(gameMenu.Path);
            int highscore = 0;
            foreach (string score in findHighscore)
            {
                if (score.Contains(":"))
                {
                    string tempscore = score.Split(' ')[2];
                    if (Convert.ToInt16(tempscore) > highscore)
                    {
                        highscore = Convert.ToInt16(tempscore);
                    }
                }
            }
            return highscore;
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