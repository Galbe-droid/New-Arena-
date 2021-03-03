using System;
using System.IO;

class MainMenu
{
  public static string TitleMenu()
  {
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

    Console.Write("Choose: ");
    string Decision = Console.ReadLine();
    string DecisionUpper = Decision.ToUpper();

    if(DecisionUpper == "E")
    {
      Console.Write("Exiting Program.");
      return DecisionUpper;
    }

    TitleDecision(DecisionUpper); 
    return null;
  }

  public static void TitleDecision(string decision)
  {
    if(decision == "N")
    {
      if(Lists.CountListPlayer() == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No Characters avaliable, please create one first.");
        Console.ResetColor();
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