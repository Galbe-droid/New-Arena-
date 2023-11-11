using System;
using System.IO;
using New_Arena_.Loading;
using New_Arena_.Save;

class MainClass {  
  public static void Main (string[] args) {
    //Verify if save file exist
    VerifySaveFile.CreateFile();
    //Loading
    MonsterLoading.Loading();
    Console.WriteLine("Loading Monsters...");
    SkillsLoading.Loading();
    Console.WriteLine("Loading Skills...");
    ItemsLoading.Loading();
    Console.WriteLine("Loading Itens...");
    ParametersLoading.Loading();
    Console.WriteLine("Loading Parameters...");
    CharactersLoading.LoadingCharacters();
    Console.WriteLine("Loading Monsters...");
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
}