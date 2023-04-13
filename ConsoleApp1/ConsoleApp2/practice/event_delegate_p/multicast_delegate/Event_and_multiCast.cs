using System;

namespace ConsoleApp2.practice.event_delegate_p.multicast_delegate
{
    public class event_and_multicast_delegate
    {
        public static void Start()
        {

            Audio_system audio = new Audio_system();

            RenderEngine renderEngine = new RenderEngine();

            Player player1 = new Player("SteelCow");
            Player player2 = new Player("DoggoSilva");

            GameEventManager.TiggerGameStart();
           
            Console.WriteLine("Game is Running... Press any key to stop.");
            Console.Read();

            GameEventManager.TiggerGameEnd();

                   }
    }
}