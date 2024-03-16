///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Contient les mécanismes fondamentaux du jeu.
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Timers;
using System.Drawing;


namespace Projet_SpicyInvader
{
    internal class Game
    {        
        public Game()
        {

        }
        /// <summary>
        /// Lancement du programme
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {     
            //initialisation des dimensions de la fenêtre de la console
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;
            //Lancement du menu du jeu
            Menu();           
        }
        
        /// <summary>
        /// Menu de démarrage
        /// </summary>
        public static void Menu()
        {
            string choiceOfMenu;
            do
            {
                Console.WriteLine("                 **********************************************************************************" );
                Console.WriteLine("                                            Bienvenue sur Space Invaders");
                Console.WriteLine("                 **********************************************************************************\n\n");
                Console.WriteLine("1. Jouer\n2. Options\n3. A propos\n4. Quitter\n\n");
                Console.Write("Mettez le chiffre de l'action que vous souhaitez réaliser : ");
                choiceOfMenu = Console.ReadLine();

                Console.Clear();
                switch (choiceOfMenu)
                {
                    case "1":
                          GameSP();
                        break;

                    case "2":
                        Options();
                        break ;

                    case "3":
                        Console.WriteLine("");
                        break;

                    case "4":
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
        /// Lance le jeu
        /// </summary>
        public static void GameSP()
        {       
           
            PlayerShip playerShip = new PlayerShip();
            Invaders badInvaders = new Invaders();
            Missile missile = new Missile(playerShip.PositionX, 33);
            Wall wall = new Wall();
            Score scoreGame = new Score();
            wall.CreateWallOfBrick();

             while (playerShip.Alive() != false)
             {
                scoreGame.AddPoints();
                KeyPressChosen(playerShip, missile);
                Update(playerShip, missile,badInvaders);
                Draw(playerShip, missile, badInvaders, wall);
                Collision(playerShip, missile, badInvaders, wall, scoreGame);
                
                Thread.Sleep(20);
             }
        }

        /// <summary>
        /// Exécute une action en fonction de la touche pressée
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void KeyPressChosen(PlayerShip playerShip, Missile m)
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                playerShip.Move(false);

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    if (m.missileLaunched is false)
                    {
                        m._x = playerShip.PositionX;
                        m._y = 33;
                        m.missileLaunched = true;
                    }
                }
            }
            else if(Keyboard.IsKeyDown(Key.Right))
            {
                playerShip.Move(true);

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    if (m.missileLaunched is false)
                    {
                        m._x = playerShip.PositionX;
                        m._y = 33;
                        m.missileLaunched = true;
                    }
                }
            }
            else if (Keyboard.IsKeyDown(Key.Space))
            {
                if (m.missileLaunched is false)
                {
                    m._x = playerShip.PositionX;
                    m._y = 33;
                    m.missileLaunched = true;
                }
            }                                      
        }

        /// <summary>
        /// Mise à jour de l'emplacement des objets
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void Update(PlayerShip playerShip, Missile m, Invaders enemies)
        {
            if (m._y == 0)
            {
                m.missileLaunched = false;   
            }
            else if (m.missileLaunched is true)
            {
                m.Shoot();
            }
            if (enemies.Invadersdie is false)
            {
                enemies.Update();
            }
            else if(enemies.Invadersdie == true)
            {
                enemies.X = 5;
                enemies.Y = 3;
                enemies.Invadersdie = false;
                enemies.goLeftElseRight = false;
            }                    
        }

        /// <summary>
        /// Dessine les objets à leur position actuelle
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void Draw(PlayerShip playerShip, Missile m, Invaders enemies, Wall walls)
        {
            playerShip.Draw();
            walls.Draw();
            //Si un missile a été lancé, alors ça le dessine
            if (m.missileLaunched == true)
            {
                m.DrawMissile();
            }
            enemies.Draw();


            //Si l'ennemi est sur la même hauteur que le vaisseau -> PERDU
            if (enemies.Y == 35)
            {
                Console.SetCursorPosition(15, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"                  _____          __  __ ______    ______      ________ _____  
                                / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
                               | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
                               | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
                               | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
                                \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("Appuyer sur une Enter pour revenir au menu");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
        }


        public static void Collision(PlayerShip playerShip, Missile m, Invaders enemies, Wall walls, Score score)
        {
            //Supprime l'ennemi et le missile si les 2 se touchent
            if (m.hitbox().IntersectsWith(enemies.hitbox()))
            {
                m.UnDrawMissileActualPosition();
                m.missileLaunched = false;
                enemies.UndrawActualPosition();
                enemies.Invadersdie = true;
                score.AddPoints();
            }

            //Abime une brique du mur si touchée 1 fois, la détruit si touchée 2 fois
            foreach (Wall w in walls.walls)
            {
                for (int j = 0; j < walls.HEIGHTWALL; j++)
                {
                    for (int i = 0; i < walls.WIDTHWALL; i++)
                    {
                        walls.
                    }
                }
            }
            
        }
        /// <summary>
        /// Options du jeu (Son et difficultés)
        /// </summary>
        public static void Options()
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
                choiceOfOptions= Console.ReadLine();

                if (choiceOfOptions == "1")
                {
                    Console.Clear();
                    ShowAndErase("Niveau facile activé", TimeSpan.FromSeconds(1));
                    Menu();
                }
                else if (choiceOfOptions == "2")
                {
                    Console.Clear();
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
        /// S'éxécute lorsque l'user ne met pas les entrées attendues du clavier
        /// </summary>
        public static void Error()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'avez pas inséré les chiffres attendus. Veuillez recommencer.\n\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Court temps accordé à l'user pour confirmer le choix d'une option
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