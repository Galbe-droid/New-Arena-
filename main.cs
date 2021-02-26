using System;
using System.Collections.Generic;

class MainClass {
  
  public static void Main (string[] args) {
    //Loading
    MonsterList.AddMonsters();

    //End Loading
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
    int str = 1, inte = 1, agi = 1, vig = 1;

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
    int days = 1;
    string dayMoment = "";
    bool daytime = true;    

    while(GameOn)
    {
      if(daytime == true)
      {
        dayMoment = " Daytime";
      }
      else
      {
        dayMoment = " Nightime";
      }

      GameScreen.CharacterStats(chosen);
      GameScreen.ArenaChoices(days, dayMoment);

      Console.Write("Chose:");
      string Decision = Console.ReadLine().ToUpper();

      if(Decision == "E")
      {
        GameOn = false;
      }
      else
      {
        GameStartMenu.ArenaMenu(Decision, chosen);
        if(daytime == false)
        {
          days = ArenaBehaviour.DayPassing(days);
        }
        daytime = ArenaBehaviour.DayToNight(daytime);
        
      }      
    }
  }
}