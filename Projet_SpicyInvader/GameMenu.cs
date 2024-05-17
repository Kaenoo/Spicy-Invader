///ETML
///Auteur : Kaeno Eyer
///Date : 19.04.2024
///Description : Contient les méthodes du menu du jeu
///
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Linq;

namespace Projet_SpicyInvader
{
    public class GameMenu
    {
        bool _difficultyHard = false;
        string _path = @"D:\C#\Module 226\Projet\Projet_SpicyInvader\Projet_SpicyInvader\Score\Score.txt";
        string _regName = @"^\w+$";
        List<string> dataScore = new List<string>();
        int _cursorY = 10;
        string _cursorBeg = "<<";
        string _cursorEnd = ">>";
        string[] _menuChoice = new string[] { "  Jouer", " Options", "A propos", "  Score", " Quitter"};
        int _menuPlacement = 10;
        bool gamePlayed = false;
        int finalScore = 0;
        public bool DifficultyHard { get { return _difficultyHard; } }

        /// <summary>
        /// Menu de démarrage
        /// </summary>
        public void Menu()
        {
            string choiceOfMenu;
            string namePlayer;

            do
            {
                Console.SetCursorPosition(0, 0);
                //Pour obtenir le score à la fin d'une partie
                if (gamePlayed is true)
                {
                    bool validName = false;
                    do
                    {
                        Console.Write("Entrez votre Pseudo : ");
                        namePlayer = Console.ReadLine();
                        if (Regex.IsMatch(namePlayer, _regName))
                        {
                            dataScore.Add($"{namePlayer} : {finalScore}\n");
                            Console.Clear();
                            validName = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nEntrez votre Pseudo, il ne doit pas avoir d'espace !!\n");
                            Console.ResetColor();
                        }
                        gamePlayed = false;
                    } while (validName is false);
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

                for (int i = 0; i < _menuChoice.Length; i++)
                {
                    Console.SetCursorPosition(50, _menuPlacement);
                    Console.Write(_menuChoice[i]);
                    _menuPlacement++;
                }
                _menuPlacement = 10;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(47, _cursorY);
                Console.Write(_cursorBeg);
                Console.SetCursorPosition(60, _cursorY);
                Console.Write(_cursorEnd);
                Console.ResetColor();

                Thread.Sleep(70);
                KeyPressChosen();

            } while (true);
        }


        public void KeyPressChosen()
        {
            if (Keyboard.IsKeyDown(Key.Down)) //Si l'user appuie sur la fleche de bas
            {
                if (_cursorY >= 14)
                {
                    EraseCursor();
                    _cursorY = 10;
                }
                else
                {
                    EraseCursor();
                    _cursorY++;
                }
            }
            else if (Keyboard.IsKeyDown(Key.Up)) //Si l'user appuie sur la fleche du haut
            {
                if (_cursorY <= 10)
                {
                    EraseCursor();
                    _cursorY = 14;
                }
                else
                {
                   EraseCursor();
                    _cursorY--;
                }
            }
            else if (Keyboard.IsKeyDown(Key.Enter)) //Si l'user appuie sur Espace, lance un missile
            {
                bool finish = false;
                switch (_cursorY)
                {
                    case 10:
                        Console.Clear();
                        finalScore = Game.GameSP(_difficultyHard);
                        gamePlayed = true;
                        break;

                    case 11:
                        Console.Clear();
                        Options();
                        break;

                    case 12:
                        Console.Clear();
                        finish = false;
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Bienvenue dans Space Invaders !!\n\nLe but du jeu est d'éliminer les ennemis et survivre le plus longtemps sans se faire toucher par le missile\nAttention, si l'ennemi te touche tu as également perdu !\nTu ne possèdes que 3 vies, alors à toi d'assurer pour faire le meilleur score !!\n\nCommandes : flèche de gauche et droite pour se déplacer, ESPACE pour tirer des missiles\n\nAppuyez sur la touche Enter pour revenir au menu.");
                            Thread.Sleep(50);
                            if (Keyboard.IsKeyDown(Key.Enter))
                            {
                                finish = true;
                            }

                        } while (finish is false);
                        Console.Clear();
                        break;

                    case 13:
                        Console.Clear();
                        finish = false;
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            Score(dataScore);
                            Thread.Sleep(50);
                            if (Keyboard.IsKeyDown(Key.Enter))
                            {
                                finish = true;
                            }

                        } while (finish is false);
                        Console.Clear();
                        break;
                    case 14:
                        Console.Clear();
                        ShowAndErase("Fermeture du jeu...", TimeSpan.FromSeconds(1));
                        SaveScore();
                        Environment.Exit(0);
                        break;
                }
            }
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
        /// <param name="scoreData">Tableau de string contenant les données de score (Nom : score)</param>
        public void Score(List<string> scoreData)
        {
            Console.WriteLine("Tableau des Scores\n**************************************\n");
            if (File.Exists(_path))
            {
                Console.Write(File.ReadAllText(_path));
            }

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
        /// <param name="text">Texte à afficher</param>
        /// <param name="TimeToShow">Temps durant lequel il  faut le montré</param>
        public static void ShowAndErase(string text, TimeSpan TimeToShow)
        {
            Console.WriteLine(text);
            Thread.Sleep(TimeToShow);
            Console.Clear();
        }

        public void EraseCursor()
        {
            Console.SetCursorPosition(47, _cursorY);
            Console.Write("  ");
            Console.SetCursorPosition(60, _cursorY);
            Console.Write("  ");
        }

        /// <summary>
        /// Sauvegarde les scores dans un fichier
        /// </summary>
        public void SaveScore()
        {
            File.AppendAllLines(_path, dataScore);
        }
    }
}