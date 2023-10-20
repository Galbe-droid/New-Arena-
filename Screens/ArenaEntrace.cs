using System;
using System.Collections.Generic;

//This screen shows the player info on the Arena main menu 
class ArenaEntrance
{
  public static void MonsterOfTheDayDisplay()
  {
    int cage = 1;

    foreach(Monster m in ArenaBehaviour.cages)
    {
      Console.WriteLine("=====================Cage:" + cage + "========================");
      Console.WriteLine($"Name: {m.Name} Lvl: {m.Level} Behavior: {m.Type} ({m.SubType[0]} and {m.SubType[1]})");
      Console.WriteLine($"Stats: Str: {m.Str} Int: {m.Int} Agi: {m.Agi} Vig: {m.Vig}");
      Console.WriteLine($"Min/Max Damage: {m.MinDamage} - {m.MaxDamage}");
      Console.WriteLine($"Min/Max Defense: {m.MinDefense} - {m.MaxDefense}");
      cage ++;
    }
  }
}