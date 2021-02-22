using System;

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
    int id = Lists.IdPlayerGeneration();
    string name = "Nameless"; 
    int xp = 0;
    int lvl = 1;
    int str = 0, inte = 0, agi = 0, vig = 0;

    Console.Clear();
    Console.WriteLine("AHHH a new face here");
    while(true)
    {
      CharacterCreation.Creator(name, xp, lvl, str, inte, agi, vig);
      name = CharacterCreationMenu.NameInput(name);
      str = CharacterCreationMenu.StatsInput(str);
    }
  }
}