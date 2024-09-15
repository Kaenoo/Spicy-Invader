///ETML
///Auteur : Kaeno Eyer
///Date : 18.01.2024
///Description : Contient les mécanismes fondamentaux du jeu
///
using System;
using System.Threading;
using System.Windows.Input;
using NAudio;

namespace Projet_SpicyInvader
{
    /// <summary>
    /// Jeu 
    /// </summary>
    public class Game
    {

        /// <summary>
        /// Lancement du programme
        /// </summary>
        /// <param name="args"></param>
        [STAThread] //Permet de gérer plusieurs objets exécutés simultanément.
                    //Si le Thread doit attendre la fin d'une opération fastidieuse, cela permet à un autre thread d'être exécuté.
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
        /// <param name="difficulty">Définit le niveau de difficulté</param>
        /// <returns></returns>
        public static int GameSP(bool difficulty)
        {
            //Instanciation des classes
            PlayerShip playerShip = new PlayerShip();
            Invaders badInvaders = new Invaders();
            Missile missile = new Missile(playerShip.PositionX, 33);
            Missile missileEnemies = new Missile(5, 5);
            Wall wall = new Wall();
            SpaceshipInvader bigEnemy = new SpaceshipInvader();
            Score scoreGame = new Score();
            //scoreGame.HighScore = scoreGame.RecupHighscore();
            int speedGame = 0;
            if (difficulty is false)
            {
                speedGame = 10;
            }
            else if (difficulty is true)
            {
                speedGame = 3;
            }

            badInvaders.CreateInvaders();
            wall.CreateWallOfBrick();

            //boucle du jeu continue tant que le joueur est en vie
            while (playerShip.Alive is true)
            {
                scoreGame.AddPoints();
                playerShip.ShowLife();
                KeyPressChosen(playerShip, missile);
                Update(playerShip, missile, badInvaders, missileEnemies, difficulty, bigEnemy);
                Draw(playerShip, missile, badInvaders, wall, missileEnemies, bigEnemy);
                Collision(playerShip, missile, badInvaders, wall, missileEnemies, bigEnemy,scoreGame);
                Thread.Sleep(speedGame);
            }
            return scoreGame.Scoree;
        }

        /// <summary>
        /// Exécute une action en fonction de la touche pressée
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
        /// <param name="m">Missile du vaisseau</param>
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
            else if (Keyboard.IsKeyDown(Key.Right)) //Si l'user appuie sur la fleche de droite, vaisseau va à droite
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
        /// <param name="playerShip">Vaisseau de l'user</param>
        /// <param name="m">Missile de l'user</param>
        /// <param name="enemies">Ennemis</param>
        /// <param name="ME">Missile de l'ennemi</param>
        /// <param name="difficulty">Niveau de difficulté</param>
        /// <param name="bigEnemy">Vaisseau de l'ennemi rouge</param>
        public static void Update(PlayerShip playerShip, Missile m, Invaders enemies, Missile ME, bool difficulty, SpaceshipInvader bigEnemy)
        {
            enemies.Update();
            m.Update();
            ME.UpdateEnemies(enemies, difficulty);
            bigEnemy.Update();
        }

        /// <summary>
        /// Dessine les objets à leur position actuelle
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
        /// <param name="m">Missile de l'user</param>
        /// <param name="enemies">Ennemis</param>
        /// <param name="walls">Mur</param>
        /// <param name="ME">Missile de l'ennemi</param>
        /// <param name="bigEnemy">Vaisseau de l'ennemi rouge</param>
        public static void Draw(PlayerShip playerShip, Missile m, Invaders enemies, Wall walls, Missile ME, SpaceshipInvader bigEnemy)
        {
            playerShip.Draw();
            walls.Draw();
            m.DrawMissile();
            enemies.Draw();
            bigEnemy.Draw();

            if (ME.MissileLaunched is true)
            {
                ME.Progress();
                ME.DrawMissile();
            }
        }

        /// <summary>
        /// Gère les collisions de toutes les classes
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
        /// <param name="m">Missile de l'user</param>
        /// <param name="enemies">Ennemis</param>
        /// <param name="wall">Mur</param>
        /// <param name="ME">Missile de l'ennemi</param>
        /// <param name="BigEnemy">Vaisseau de l'ennemi rouge</param>
        /// <param name="score">Score</param>
        public static void Collision(PlayerShip playerShip, Missile m, Invaders enemies, Wall wall, Missile ME, SpaceshipInvader BigEnemy, Score score)
        {
            enemies.Collision(m, score, playerShip);
            ME.CollisionEnemies(playerShip, m);
            wall.Collision(m, ME);
            BigEnemy.Collision(m, score);
        }

        /// <summary>
        /// Si l'user perd
        /// </summary>
        /// <param name="playerShip">Vaisseau de l'user</param>
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
            playerShip.Alive = false;
        }
    }
}