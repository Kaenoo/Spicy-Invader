///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Contient les mécanismes fondamentaux du jeu
///
using System;
using System.Threading;
using System.Windows.Input;

namespace Projet_SpicyInvader
{
    internal class Game
    {        
        /// <summary>
        /// Lancement du programme
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main()
        {     
            //initialisation des dimensions de la fenêtre de la console
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;
            Console.CursorVisible = false;
            //Lancement du menu du jeu
            GameMenu gameMenu = new GameMenu();
            gameMenu.Menu();           
        }        
        
        /// <summary>
        /// Lance le jeu
        /// </summary>
        public static int GameSP(bool difficulty)
        {               
            //Instanciation des classes
            PlayerShip playerShip = new PlayerShip();
            Invaders badInvaders = new Invaders();
            Missile missile = new Missile(playerShip.PositionX, 33);
            Missile missileEnemies = new Missile(5, 5);
            Wall wall = new Wall();
            Score scoreGame = new Score();

            badInvaders.CreateInvaders();
            wall.CreateWallOfBrick();

            //boucle du jeu continue tant que le joueur est en vie
             while (playerShip.alive is true)
             {
                scoreGame.AddPoints();
                playerShip.ShowLife();
                KeyPressChosen(playerShip, missile);
                Update(playerShip, missile,badInvaders, missileEnemies, difficulty);
                Draw(playerShip, missile, badInvaders, wall, missileEnemies);
                Collision(playerShip, missile, badInvaders, wall, missileEnemies, scoreGame);                
                Thread.Sleep(10);
             }
             return scoreGame.score;
        }

        /// <summary>
        /// Exécute une action en fonction de la touche pressée
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void KeyPressChosen(PlayerShip playerShip, Missile m)
        {
            if (Keyboard.IsKeyDown(Key.Left)) //Si l'user appuie sur la fleche de gauche, vaisseau va à gauche
            {
                playerShip.Move(false);

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    m.LaunchMissile(playerShip);
                }
            }
            else if(Keyboard.IsKeyDown(Key.Right)) //Si l'user appuie sur la fleche de droite, vaisseau va à droite
            {
                playerShip.Move(true);

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    m.LaunchMissile(playerShip);
                }
            }
            else if (Keyboard.IsKeyDown(Key.Space)) //Si l'user appuie sur Espace, lance un missile
            {
                m.LaunchMissile(playerShip);
            }                                      
        }

        /// <summary>
        /// Mise à jour de l'emplacement des objets
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void Update(PlayerShip playerShip, Missile m, Invaders enemies, Missile ME, bool difficulty)
        {
            enemies.Update();
            m.Update();
            ME.UpdateEnemies(enemies, difficulty);            
        }

        /// <summary>
        /// Dessine les objets à leur position actuelle
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        public static void Draw(PlayerShip playerShip, Missile m, Invaders enemies, Wall walls, Missile ME)
        {
            playerShip.Draw();
            walls.Draw();
            m.DrawMissile();
            enemies.Draw();

            if (ME.missileLaunched is true)
            {
                ME.Progress();
                ME.DrawMissile();
            }
        }

        /// <summary>
        /// Gère les collisions de toutes les classes
        /// </summary>
        /// <param name="playerShip"></param>
        /// <param name="m"></param>
        /// <param name="enemies"></param>
        /// <param name="wall"></param>
        /// <param name="score"></param>
        public static void Collision(PlayerShip playerShip, Missile m, Invaders enemies, Wall wall, Missile ME, Score score)
        {
            enemies.Collision(m, score, playerShip);
            ME.CollisionEnemies(playerShip, m);
            wall.Collision(m, ME);
        }

        /// <summary>
        /// Si l'user perd
        /// </summary>
        public static void GameOver(PlayerShip playerShip)
        {
            Console.SetCursorPosition(10, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                       _____          __  __ ______    ______      ________ _____  
                                / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
                               | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
                               | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
                               | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
                                \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\");
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("Appuyez sur la touche Enter pour revenir au menu");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            playerShip.alive = false;
        }       
    }
}