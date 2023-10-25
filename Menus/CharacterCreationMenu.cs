using System;
using New_Arena_.Behaviour;
using New_Arena_.Save;

//This are the menus for the caracter creation, one access the name the other one access the stats of the player 
class CharacterCreationMenu
{
  public static void CharacterCreationDecision()
  {
    bool CharacterMaker = true;
    int id = CharacterListManagement.IdPlayerGeneration();
    string name = "Nameless"; 
    int str = 3, inte = 3, agi = 3, vig = 3;
    int maxAtributes = 15;
    

    Console.Clear();
    Console.WriteLine("AHHH a new face here");
    //While loop for Character Creation, changing stats and info 
    //Inside de loop has the menu and info display, switch cases and the inserion of the var to the caracter class 
    while(CharacterMaker)
    {
      int actualAtributes = str + inte + agi + vig;
      actualAtributes = (actualAtributes - maxAtributes) * -1;
      
      Console.WriteLine("=================================");
      CharacterCreation.Creator(name, str, inte, agi, vig, actualAtributes);      
      Console.WriteLine("=================================");
      CharacterCreation.CreatorMainScreen();
      Console.WriteLine("=================================");
      Console.Write("Choice: ");
      string decision = Console.ReadLine().ToUpper();

      switch(decision)
      {
        case "N":
          name = CharacterCreationBehavior.NameInput(name);
          break;

        case "S":
          str = CharacterCreationBehavior.StatsInput(str, actualAtributes);
          break;
        
        case "I":
          inte = CharacterCreationBehavior.StatsInput(inte, actualAtributes);
          break;

        case "A":
          agi = CharacterCreationBehavior.StatsInput(agi, actualAtributes);
          break;

        case "V":
          vig = CharacterCreationBehavior.StatsInput(vig, actualAtributes);
          break;

        case "E":
          Console.Clear();
          CharacterMaker = false;
          break;   

        case "F":
          if(actualAtributes == 0)
          {
            Console.Clear();
            Character character = new Character(id, name, str, inte, agi, vig);
            //Adding the caracter on the caracter list then disable this screen and going back to the main menu
            //Applies the initial skill on it 
            character.Initalization();
            //Initiate the process of Level and the values of quantity and quality for items on the market and monster cages
            ProgressBehaviour.CheckingValuesInLevel(character);
            //Update the save List and the send it to the json file for update 
            VerifySaveFile.NewCharacterSave(character);
            CharacterMaker = false;
          }
          else
            UpdateConsole.StaticMessage("Still some points left. ");
          
          break;  
      }
    }
  }
}