using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    bool program = true;
    while(program)
    {
      Console.WriteLine("=================================");
      MainScreen.TitleScreen();
      Console.WriteLine("=================================");
      if(MainMenu.TitleMenu() == "E")
      {
        program = false;
      }
    }
  }

  public static void CreationProcess()
  {
    bool CharacterMaker = true;
    int id = Lists.IdPlayerGeneration();
    string name = "Nameless"; 
    int xp = 0;
    int lvl = 1;
    int str = 0, inte = 0, agi = 0, vig = 0;

    Console.Clear();
    Console.WriteLine("AHHH a new face here");
    while(CharacterMaker)
    {
      Console.WriteLine("=================================");
      CharacterCreation.Creator(name, xp, lvl, str, inte, agi, vig);      
      Console.WriteLine("=================================");
      CharacterCreation.CreatorMainScreen();
      Console.WriteLine("=================================");
      Console.Write("Choice: ");
      string decision = Console.ReadLine().ToUpper();

      switch(decision)
      {
        case "N":
          name = CharacterCreationMenu.NameInput(name);
          break;

        case "S":
          str = CharacterCreationMenu.StatsInput(str);
          break;
        
        case "I":
          inte = CharacterCreationMenu.StatsInput(inte);
          break;

        case "A":
          agi = CharacterCreationMenu.StatsInput(agi);
          break;

        case "V":
          vig = CharacterCreationMenu.StatsInput(vig);
          break;

        case "E":
          Console.Clear();
          CharacterMaker = false;
          break;   

        case "F":
          Console.Clear();
          Character character = new Character(id, name, str, inte, agi, vig);
          Lists.CharacterList.Add(character);
          CharacterMaker = false;
          break;  
      }
    }
  }

  public static void GameStart(Character chosen)
  {
    bool GameOn = true;
    while(GameOn)
    {
      
    }
  }
}