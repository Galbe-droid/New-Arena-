using System;
using System.Collections.Generic;

class GameStartMenu
{
  public static bool ArenaMenu(string decision, Character chosen, bool exit, ref bool DayOrNight)
  {
    switch(decision)
    {
      case("N"):
        int choice;
        Monster monster = new Monster();
        Console.Clear();
        GameScreen.CharacterStats(chosen);
        
        List<Monster> Cages = new List<Monster>(MonsterGeneration.MonsterOfTheDay());

        ArenaEntrance.MonsterOfTheDayDisplay(Cages);
        
        do{
          choice = InputCheck.IntCheck("Choice(0 to go back):", "Only Numbers.");
        }while(choice < 0 || choice > Cages.Count);     

        if(choice == 0)
        {
          MonsterGeneration.CleaningCages();
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
              DayOrNight = !DayOrNight;
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

          int choiceInn = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");
          if(choiceInn == 0)
          {
            Console.Clear();
            FoodGeneration.ClearFoods();     
            return true;
          }
          else
          {
            choiceInn--;
            Console.WriteLine("Food eaten!");
            Console.ReadKey();
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