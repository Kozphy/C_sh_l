using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.practice.event_delegate_p.multicast_delegate
{
    internal class GameEventManager
    {
        public delegate void GameEvent();

        public static event GameEvent OnGameStart, OnGameEnd;

        public static void TiggerGameStart()
        {
            // methods already subscribe to it.
            if (OnGameStart != null)
            {
                Console.WriteLine("The game has started");
                OnGameStart();
            }
        }

        public static void TiggerGameEnd()
        {
            if (OnGameEnd != null)
            {
                Console.WriteLine("The game has end");
                OnGameEnd();
            }
        }
    }
}
