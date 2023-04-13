using System;

namespace  ConsoleApp2.practice.event_delegate_p.multicast_delegate
{
    public class RenderEngine{

        public RenderEngine() 
        {
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameEnd += GameOver;
        }
        private void StartGame()
        {
            System.Console.WriteLine("Render Engine Started");
            System.Console.WriteLine("Drawing Visuals...");
        }

        private void GameOver()
        {
            System.Console.WriteLine("Rendering Engine Stopped");
        }
    }
}