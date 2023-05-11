using System;
using System.Collections.Generic;

//This screen shows the player info on the Arena main menu 
class ArenaEntrance
{
  public static void MonsterOfTheDayDisplay(List<Monster> displayList)
  {
    int cage = 1;

    foreach(Monster m in displayList)
    {
      Console.WriteLine("=====================Cage:" + cage + "========================");
      Console.WriteLine($"Species: {m.Species} Name: {m.Name} Lvl: {m.Level} Behavior: {m.Type}, {m.SubType[0]} and {m.SubType[1]}");
      Console.WriteLine($"Stats: Str: {m.Str} Int: {m.Int} Age: {m.Agi} Vig: {m.Vig}");
      cage ++;
    }
  }
}