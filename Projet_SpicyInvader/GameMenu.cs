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
using System.Diagnostics;

namespace Projet_SpicyInvader
{
    public class GameMenu
    {
        List<string> dataScore = new List<string>();
        string _path = @"D:\C#\Module 226\Projet\Projet_SpicyInvader\Projet_SpicyInvader\Score\Score.txt";
        string _regName = @"^\w+$";

        int _cursorY = 10;
        string _cursorBeg = "<<";
        string _cursorEnd = ">>";

        string[] _menuChoice = new string[] { "  Jouer", " Options", "A propos", "  Score", " Quitter"};
        string[] _optionChoice = new string[] { " Son Désactivé", "  Mode facile", "Revenir au menu"};
        int _menuPositionY = 10;
        int _menuPositionX = 50;

        bool _difficultyHard = false;
        bool gamePlayed = false;
        string namePlayer;
        int finalScore = 0;
        public bool DifficultyHard { get { return _difficultyHard; } }

        /// <summary>
        /// Menu de démarrage
        /// </summary>
        public void Menu()
        {
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
                            Console.WriteLine("\n\nEntrez un Pseudo, il ne doit pas avoir d'espace !!\n");
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
                    Console.SetCursorPosition(_menuPositionX, _menuPositionY);
                    Console.Write(_menuChoice[i]);
                    _menuPositionY++;
                }
                _menuPositionY = 10;

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

        /// <summary>
        /// Gère le déplacement dans le menu avec les touches pressées
        /// </summary>
        public void KeyPressChosen()
        {
            if (Keyboard.IsKeyDown(Key.Down)) //Si l'user appuie sur la fleche de bas
            {
                if (_cursorY >= 14)
                {
                    EraseCursor(60);
                    _cursorY = 10;
                }
                else
                {
                    EraseCursor(60);
                    _cursorY++;
                }
            }
            else if (Keyboard.IsKeyDown(Key.Up)) //Si l'user appuie sur la fleche du haut
            {
                if (_cursorY <= 10)
                {
                    EraseCursor(60);
                    _cursorY = 14;
                }
                else
                {
                   EraseCursor(60);
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
                        _cursorY = 10;
                        Options();
                        break;

                    case 12:
                        do
                        {
                            Console.Clear();
                            Thread.Sleep(60);
                        } while (false); 
                        finish = false;
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Bienvenue dans Space Invaders !!\n\nLe but du jeu est d'éliminer les ennemis et survivre le plus longtemps sans se faire toucher par le missile\nAttention, si l'ennemi te touche tu as également perdu !\nTu ne possèdes que 3 vies, alors à toi d'assurer pour faire le meilleur score !!\n\nCommandes : flèche de gauche et droite pour se déplacer, ESPACE pour tirer des missiles\n\nAppuyez sur la touche Enter pour revenir au menu.");
                            if (Keyboard.IsKeyDown(Key.Enter))
                            {
                                finish = true;
                            }

                        } while (finish is false);
                        Console.Clear();
                        break;

                    case 13:
                        do
                        {
                            Console.Clear();
                            Thread.Sleep(60);
                        } while (false);
                        finish = false;
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            Score(dataScore);
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
            bool soundActivated = false;
            int endCursorPositionX = 66;
            do
            {
                Console.SetCursorPosition(50, _cursorY);
                for (int i = 0; i < _optionChoice.Length; i++)
                {
                    Console.SetCursorPosition(_menuPositionX, _menuPositionY);
                    Console.Write(_optionChoice[i]);
                    _menuPositionY++;
                }
                _menuPositionY = 10;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(47, _cursorY);
                Console.WriteLine(_cursorBeg);
                Console.SetCursorPosition(endCursorPositionX, _cursorY);
                Console.WriteLine(_cursorEnd);
                Console.ResetColor();

                Thread.Sleep(70);
                if (Keyboard.IsKeyDown(Key.Down)) //Si l'user appuie sur la fleche de bas
                {
                    if (_cursorY >= 12)
                    {
                        EraseCursor(endCursorPositionX);
                        _cursorY = 10;
                    }
                    else
                    {
                        EraseCursor(endCursorPositionX);
                        _cursorY++;
                    }
                }
                else if (Keyboard.IsKeyDown(Key.Up)) //Si l'user appuie sur la fleche du haut
                {
                    if (_cursorY <= 10)
                    {
                        EraseCursor(endCursorPositionX);
                        _cursorY = 12;
                    }
                    else
                    {
                        EraseCursor(endCursorPositionX);
                        _cursorY--;
                    }
                }
                else if (Keyboard.IsKeyDown(Key.Enter))//Si l'user appuie sur Espace, lance un missile
                {
                    switch (_cursorY)
                    {
                        case 10:
                            soundActivated = !soundActivated;
                            if (soundActivated is true)
                            {
                                _optionChoice[0] = "  Son Activé   ";
                            }
                            else
                            {
                                _optionChoice[0] = " Son Désactivé";
                            }
                            break;
                        case 11:
                            _difficultyHard = !_difficultyHard;
                            if (_difficultyHard is true)
                            {
                                _optionChoice[1] = " Mode hardcore";
                            }
                            else
                            {
                                _optionChoice[1] = "  Mode facile  ";
                            }
                            break;
                        case 12:
                            _cursorY = 11;
                            Console.Clear();
                            Menu();
                            break;
                        default:
                            break;
                    }
                }                
            } while (true);
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

        public void EraseCursor(int endCursorPosition)
        {
            Console.SetCursorPosition(47, _cursorY);
            Console.Write("  ");
            Console.SetCursorPosition(endCursorPosition, _cursorY);
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