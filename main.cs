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
    SkillsLoading.Loading();
    ItemsLoading.Loading();
    ParametersLoading.Loading();
    CharactersLoading.LoadingCharacters();
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