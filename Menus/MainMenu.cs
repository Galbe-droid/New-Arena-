using System;
using System.IO;
using System.Collections.Generic;
using New_Arena_.Screens;
using New_Arena_.Loading;

//Main menu 
class MainMenu
{
  public static string TitleMenu()
  {
    TitleScreen.Display();
    //Receive the decesion input for the player 
    Console.Write("Choose: ");
    string Decision = Console.ReadLine().ToUpper();

    //Exit the application 
    if(Decision == "E")
    {
      Console.Write("Exiting Program.");
      return Decision;
    }

    //Enter on the title decision method to process the input 
    TitleDecision(Decision); 
    return null;
  }

  //Title decision is where the player input on main menu is process
  public static void TitleDecision(string decision)
  {
    //Initiate a new game, only if there is a character 
    if(decision == "N")
    {
      if(CharactersLoading.GlobalCharacterList.Count == 0)
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
      CharacterCreationMenu.CharacterCreationDecision();
    }
    else if(decision == "V")
    {
      if(CharactersLoading.GlobalCharacterList.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No Characters avaliable, please create one first.");
        Console.ResetColor();
      }
      else
      {
        CharacterListManagement.PlayerShowList();
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