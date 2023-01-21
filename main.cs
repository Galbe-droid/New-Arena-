using System;
using System.Collections.Generic;

class MainClass {
  
  public static void Main (string[] args) {
    //Loading
    MonsterList.AddMonsters();
    FoodList.AddFruits();

    //For Debugging proposses only 
    Console.ReadKey();

    //End Loading
    //Main Screen
    Console.Clear();
    bool program = true;
    while(program)
    {
      //Visuals for the Main title Info 
      Console.WriteLine("=================================");
      MainScreen.TitleScreen();
      Console.WriteLine("=================================");
      //MainMenu Controls de Options selection 
      if(MainMenu.TitleMenu() == "E")
      {
        program = false;
      }
    }
  }

  //Character Creation Process 
  public static void CreationProcess()
  {
    bool CharacterMaker = true;
    int id = Lists.IdPlayerGeneration();
    string name = "Nameless"; 
    int xp = 0, lvl = 1, str = 1, inte = 1, agi = 1, vig = 1;

    Console.Clear();
    Console.WriteLine("AHHH a new face here");
    //While loop for Character Creation, changing stats and info 
    //Inside de loop has the menu and info display, switch cases and the inserion of the var to the caracter class 
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
          //Adding the caracter on the caracter list then disable this screen and going back to the main menu 
          Lists.CharacterList.Add(character);
          CharacterMaker = false;
          break;  
      }
    }
  }

  //Game start it must contains a character, contains screen and info about the main game screen   
  public static void GameStart(Character chosen)
  {
    bool GameOn = true;
    int days = 1;
    string dayMoment = "";
    bool daytime = true;    
    bool Exit = false;
    bool timePass = true;
    List<Monster> Cages = new List<Monster>();
    List<Food> innFoodTable = new List<Food>();

    while(GameOn)
    {
      if(daytime == true)
      {
        //Make list persistent
        if(timePass){
          MonsterGeneration.CleaningCages();
          Cages = MonsterGeneration.MonsterOfTheDay();
        }
        dayMoment = " Daytime";
      }
      else
      {
        //Make list persistent
        if(timePass){
          MonsterGeneration.CleaningCages();
          FoodGeneration.ClearFoods();
          Cages = MonsterGeneration.MonsterOfTheDay();
          innFoodTable = FoodGeneration.ListOfFruitOfTheDay();
        }
        dayMoment = " Nightime";        
      }

      //If player dont advance time the list doens't change 
      if(timePass){
        timePass = !timePass;
      }

      //Screen info for caracter stats 
      GameScreen.CharacterStats(chosen);
      //Screen info for Game activities
      GameScreen.ArenaChoices(days, dayMoment);

      Console.Write("Chose:");
      string Decision = Console.ReadLine().ToUpper();

      if(Decision == "E")
      {
        GameOn = false;
      }
      else
      {
        //Exit waits for a boolean value its enter on the other screen and then go back to the main game screen        
        Exit = GameStartMenu.ArenaMenu(Decision, chosen, Exit,ref daytime, Cages, innFoodTable, ref timePass);        
      }      
    }   
  }

  //Combat Screen
  public static void Combat(Character chosen, Monster monster)
  {
    bool CombatOn = true;
    bool charBigInit;

    //If both caracter are alive this boolean is true
    while(CombatOn){

      //Generating initiative
      Random rand = new Random();
      chosen.Initiative = rand.Next(0,20) + chosen.Agi;
      monster.Initiative = rand.Next(0,20) + monster.Agi;

      //Ignore values that are the same 
      while(chosen.Initiative == monster.Initiative);
      {
        chosen.Initiative = rand.Next(0,20) + chosen.Agi;
        monster.Initiative = rand.Next(0,20) + monster.Agi;
      }

      //Send to the game if the character will be the first to act
      if (chosen.Initiative > monster.Initiative){
        charBigInit = true;
      }
      else{
        charBigInit = false;
      }
    
      Console.Clear();

      //Loads Combat Screen
      CombatScreen.Stats(chosen, monster);
      
      Console.WriteLine();   

      //Loads Combat Choice, currently only attack and defense
      CombatScreen.CombatChoices(chosen, monster);    

      //Checks if both caracter and player arent dead
      if(!monster.DeathCheck() && !chosen.DeathCheck()){        
        Console.Write("Choose:");
        string Choice;
      
        do{
          Choice = Console.ReadLine();
          Choice.ToUpper();
        }while(Choice == "A" || Choice == "D");  

        //Send the player choice to the logic so the turns can play out
        CombatMenu.CombatChoices(ref chosen, ref monster, Choice, charBigInit);
      }
      else{
        //Only Vicotry screen for now 
        if(monster.Dead == true){
          Console.WriteLine("Victory!!");
          CombatOn = false;
          Console.ReadLine();
        }
      }
    }
  }
}