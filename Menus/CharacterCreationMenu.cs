using System;

//This are the menus for the caracter creation, one access the name the other one access the stats of the player 
class CharacterCreationMenu
{
  public static string NameInput(string name)
  {
    Console.WriteLine("So you are not " + name + "...");
    Console.WriteLine("Well whats is your name then.");
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Clear();
    return name;
  }

  public static int StatsInput(int stats)
  {    
    do{
      Console.WriteLine("Actual value: " + stats);
      stats = InputCheck.IntCheck("New value(Don't insert 0 or less than that):", "Only Numbers:");
    }while(stats <= 0);
    Console.Clear();
    return stats;
  }
}