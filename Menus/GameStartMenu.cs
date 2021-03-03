using System;
using System.Collections.Generic;

class GameStartMenu
{
  public static bool ArenaMenu(string decision, Character chosen, bool exit, bool DayOrNight)
  {
    switch(decision)
    {
      case("N"):
        Console.Clear();
        GameScreen.CharacterStats(chosen);
        
        List<Monster> Cages = new List<Monster>(MonsterGeneration.MonsterOfTheDay());

        ArenaEntrance.MonsterOfTheDayDisplay(Cages);

        Console.Write("Choice(0 to go back):");
        int choice = int.Parse(Console.ReadLine());
        while(choice < 0 || choice > Cages.Count)
        {
          choice = int.Parse(Console.ReadLine());
        }

        Monster monster = new Monster();        

        if(choice == 0)
        {
          Console.Clear();
          return true;
        }
        else 
        {
          for(int i = 0; i < Cages.Count; i++)
          {
            if (i == choice - 1)
            {
              monster = new Monster(Cages[i]);
            }
          }
          MonsterGeneration.CleaningCages();
          MainClass.Combat(chosen, monster);
          Console.Clear();
        }
        break;       

      case("M"):
        Console.WriteLine("Not Ready!");
        break;

      case("I"):
        Console.Clear();
        GameScreen.CharacterStats(chosen);

        if(DayOrNight == true)
        {
          Console.Write("The feast in this inn only start at night");
          Console.ReadLine();
          Console.Clear();
          return true;
        }
        else
        {
          List<Fruit>FruitTable = new List<Fruit>(FoodGeneration.ListOfFruitOfTheDay());

          InnScreen.FoodDisplay(FruitTable);

          Console.Write("Choice(Leave in Blank to go Back):");
          string choiceInn = Console.ReadLine();
          if(choiceInn == "")
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
        }        

      case("T"):
        Console.WriteLine("Not Ready!");
        break;      
    }
    return false;
  }
}