using System;
using New_Arena_.Loading;

namespace New_Arena_.Screens
{
    public class TitleScreen
    {
        public static void Display()
        {
            //Initiate the game, only if there is a character 
            if(CharactersLoading.GlobalCharacterList.Count == 0)
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
            if(CharactersLoading.GlobalCharacterList.Count == 0)
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