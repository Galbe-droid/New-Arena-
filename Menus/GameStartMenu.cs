using System;
using System.Collections.Generic;

class GameStartMenu
{
  public static bool ArenaMenu(string decision, Character chosen, bool exit)
  {
    switch(decision)
    {
      case("N"):
        Console.Clear();
        GameScreen.CharacterStats(chosen);
        
        List<Monster> Cages = new List<Monster>(MonsterGeneration.MonsterOfTheDay());

        ArenaEntrance.MonsterOfTheDayDisplay(Cages);

        Console.Write("Choice(Leave in Blank to go Back):");
        string choice = Console.ReadLine();
        if(choice == "")
        {
          Console.Clear();
          return true;
        }
        else 
        {
          MonsterGeneration.CleaningCages();
          Console.Clear();
        }
        break;       

      case("M"):
        Console.WriteLine("Not Ready!");
        break;

      case("I"):
        Console.Clear();
        GameScreen.CharacterStats(chosen);

        List<Fruit>FruitTable = new List<Fruit>(FoodGeneration.ListOfFruitOfTheDay());

        InnScreen.FoodDisplay(FruitTable);

        Console.Write("Choice(Leave in Blank to go Back):");
        string choice = Console.ReadLine();
        if(choice == "")
        {
          Console.Clear();
          return true;
        }
        else
        {
          FoodGeneration.ClearFoods();        
          Console.Clear();
        }       
        break;

      case("T"):
        Console.WriteLine("Not Ready!");
        break;      
    }
    return false;
  }
}