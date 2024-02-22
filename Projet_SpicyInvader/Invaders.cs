using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Projet_SpicyInvader
{
    internal class Invaders
    {
        Random randomApparition = new Random();
        
        int _Y = 5;
        int _X = 0;

        public void Update()
        {
            _Y = 5;
            
            _X = randomApparition.Next(108) + 1;
            for (int i = 0; i < 28; i++)
            {
                Draw();
                _Y++;
                Thread.Sleep(500);
            }            
        }

        public void Draw()
        {
            Console.SetCursorPosition(_X, _Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("´-_-`");
            Console.ResetColor();
            Undraw();
        }

        public void Undraw()
        {
            Console.SetCursorPosition(_X, _Y -1);
            Console.Write("     ");
        }
    }
}