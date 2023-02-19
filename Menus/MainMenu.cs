using System;
using System.IO;
using System.Collections.Generic;

//Main menu 
class MainMenu
{
  public static string TitleMenu()
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

    //Receive the decesion input for the player 
    Console.Write("Choose: ");
    string Decision = Console.ReadLine();
    string DecisionUpper = Decision.ToUpper();

    //Exit the application 
    if(DecisionUpper == "E")
    {
      Console.Write("Exiting Program.");
      return DecisionUpper;
    }

    //Enter on the title decision method to process the input 
    TitleDecision(DecisionUpper); 
    return null;
  }

  //Title decision is where the player input on main menu is process
  public static void TitleDecision(string decision)
  {
    //Initiate a new game, only if there is a character 
    if(decision == "N")
    {
      if(Lists.CountListPlayer() == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No Characters avaliable, please create one first.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        }
      else
      {
        GameScreen.CharacterSelection();
        Character chosen = CharacterSelection.Select();
        if(chosen == null)
        {
          Console.ReadKey();
          Console.Clear();
        }
        else
        {
          Console.Clear();
          MainClass.GameStart(chosen);
        }        
      }
    }
    else if(decision == "C")
    {
      //Initate the creation process 
      MainClass.CreationProcess();
    }
    else if(decision == "V")
    {
      if(Lists.CountListPlayer() == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No Characters avaliable, please create one first.");
        Console.ResetColor();
      }
      else
      {
        Lists.PlayerShowList();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
      }
    }
    else
    {
      Console.WriteLine("Invalid");
      Console.ReadKey();
      Console.Clear();
    }
  }
}