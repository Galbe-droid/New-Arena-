using System;
using System.Collections.Generic;

class GameStartMenu
{
  public static void ArenaMenu(string decision, Character chosen)
  {
    switch(decision)
    {
      case("N"):
        Console.Clear();
        GameScreen.CharacterStats(chosen);
        
        List<Monster> Cages = new List<Monster>(MonsterGeneration.MonsterOfTheDay());
        ArenaEntrance.MonsterOfTheDayDisplay(Cages);
        Console.ReadKey();
        MonsterGeneration.CleaningCages();
        Console.Clear();
        break;

      case("M"):
        Console.WriteLine("Not Ready!");
        break;

      case("I"):
        Console.WriteLine("Not Ready!");
        break;

      case("T"):
        Console.WriteLine("Not Ready!");
        break;      
    }
  }
}