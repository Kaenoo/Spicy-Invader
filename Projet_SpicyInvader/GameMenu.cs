///ETML
///Auteur : Kaeno Eyer
///Date : 19.04.2024
///Description : Contient les méthodes du menu du jeu
///
using System;
using System.Collections.Generic;
using System.Threading;

namespace Projet_SpicyInvader
{
    internal class GameMenu
    {
        bool _difficultyHard = false;
        List<string> dataScore = new List<string>();
        public bool difficultyHard { get { return _difficultyHard; } }

        /// <summary>
        /// Menu de démarrage
        /// </summary>
        public void Menu()
        {
            bool gamePlayed = false;
            string choiceOfMenu;
            string namePlayer;
            int finalScore = 0;

            do
            {
                //Pour obtenir le score à la fin d'une partie
                if (gamePlayed is true)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Entrez votre nom : ");
                    namePlayer = Console.ReadLine();
                    dataScore.Add($"{namePlayer} : {finalScore}\n");
                    gamePlayed = false;
                    Console.Clear();
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(@"
              _________                           .___                         .___                   
             /   _____/__________    ____  ____   |   | _______  _______     __| _/___________  ______
             \_____  \\____ \__  \ _/ ___\/ __ \  |   |/    \  \/ /\__  \   / __ |/ __ \_  __ \/  ___/
             /        \  |_> > __ \\  \__\  ___/  |   |   |  \   /  / __ \_/ /_/ \  ___/|  | \/\___ \ 
            /_______  /   __(____  /\___  >___  > |___|___|  /\_/  (____  /\____ |\___  >__|  /____  >
                    \/|__|       \/     \/    \/           \/           \/      \/    \/           \/ 
                                                                                                    ");
                Console.ResetColor();
                Console.WriteLine("\n\n                 1. Jouer\n                 2. Options\n                 3. A propos\n                 4. Score\n                 5. Quitter\n\n");
                Console.Write("                 Mettez le chiffre de l'action que vous souhaitez réaliser : ");

                choiceOfMenu = Console.ReadLine();

                Console.Clear();
                switch (choiceOfMenu)
                {
                    case "1":
                        finalScore = Game.GameSP(_difficultyHard);
                        gamePlayed = true;
                        break;

                    case "2":
                        Options();
                        break;

                    case "3":
                        Console.WriteLine("Bienvenue dans Space Invaders !!\n\nLe but du jeu est d'éliminer les ennemis et survivre le plus longtemps sans se faire toucher par le missile\nAttention, si l'ennemi te touche tu as également perdu !\nTu ne possèdes que 3 vies, alors à toi d'assurer pour faire le meilleur score !!\n\nCommandes : flèche de gauche et droite pour se déplacer, ESPACE pour tirer des missiles\n\nAppuyez sur la touche Enter pour revenir au menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                        Score(dataScore);
                        break;
                    case "5":
                        ShowAndErase("Fermeture du jeu...", TimeSpan.FromSeconds(1));
                        Environment.Exit(0);
                        break;

                    default:
                        Error();
                        Menu();
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Options du jeu (Son et difficultés)
        /// </summary>
        public void Options()
        {
            string choiceOfOptions;
            Console.WriteLine("1. Activer / Désactiver le son\n2. Niveau de difficulté\n3. Revenir au menu\n");
            Console.Write("Mettez le chiffre de l'action que vous souhaitez réaliser : ");
            choiceOfOptions = Console.ReadLine();

            if (choiceOfOptions == "1")
            {
                Console.Clear();
                Console.WriteLine("1. Activer le son\n2. Désactiver le son\n");
                Console.Write("Mettez le chiffre de l'action que vous souhaitez réaliser : ");
                choiceOfOptions = Console.ReadLine();

                if (choiceOfOptions == "1")
                {
                    Console.Clear();
                    ShowAndErase("Son activé", TimeSpan.FromSeconds(1));
                    Menu();
                }
                else if (choiceOfOptions == "2")
                {
                    Console.Clear();
                    ShowAndErase("Son désactivé", TimeSpan.FromSeconds(1));
                    Menu();
                }
                else
                {
                    Error();
                    Options();
                }
            }
            else if (choiceOfOptions == "2")
            {
                Console.Clear();
                Console.WriteLine("1. Niveau facile\n2. Niveau difficile\n");
                Console.Write("Mettez le chiffre de l'action que vous souhaitez réaliser : ");
                choiceOfOptions = Console.ReadLine();

                if (choiceOfOptions == "1")
                {
                    Console.Clear();
                    _difficultyHard = false;
                    ShowAndErase("Niveau facile activé", TimeSpan.FromSeconds(1));
                    Menu();
                }
                else if (choiceOfOptions == "2")
                {
                    Console.Clear();
                    _difficultyHard = true;
                    ShowAndErase("Niveau difficile activé", TimeSpan.FromSeconds(1));
                    Menu();
                }
                else
                {
                    Error();
                    Options();
                }
            }
            else if (choiceOfOptions == "3")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Error();
                Options();
            }
        }

        /// <summary>
        /// Affiche un tableau des score avec le nom des joueurs
        /// </summary>
        /// <param name="scoreData"></param>
        public void Score(List<string> scoreData)
        {
            Console.WriteLine("Tableau des Scores\n**************************************\n");

            foreach (string score in scoreData)
            {
                Console.WriteLine(score);
            }
            Console.Write("Appuyez sur la touche Enter pour revenir au menu.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// S'éxécute lorsque l'user ne met pas les entrées attendues du clavier
        /// </summary>
        public static void Error()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'avez pas inséré les chiffres attendus, veuillez recommencer.\n\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Court temps accordé à l'user pour confirmer son choix d'une option
        /// </summary>
        /// <param name="text"></param>
        /// <param name="TimeToShow"></param>
        public static void ShowAndErase(string text, TimeSpan TimeToShow)
        {
            Console.WriteLine(text);
            Thread.Sleep(TimeToShow);
            Console.Clear();
        }
    }
}