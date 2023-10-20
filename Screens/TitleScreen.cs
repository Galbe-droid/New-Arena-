using System;

namespace New_Arena_.Screens
{
    public class TitleScreen
    {
        public static void Display()
        {
            //Initiate the game, only if there is a character 
            if(Lists.CountListPlayer() == 0)
            {
              Console.ForegroundColor = ConsoleColor.DarkGray;
              Console.WriteLine("N - New Game");
              Console.ResetColor();
            }
            else
            {
              Console.WriteLine("N - New Game");
            }
        
            Console.WriteLine("C - New Charater");
        
            //See what characters are created, their level their stats, etc. 
            if(Lists.CountListPlayer() == 0)
            {
              Console.ForegroundColor = ConsoleColor.DarkGray;
              Console.WriteLine("V - View Characters");
              Console.ResetColor();
            }
            else
            {
              Console.WriteLine("V - View Characters");
            }
        
            Console.WriteLine("E - EXIT");
        }
    }
}