using System;
using System.Collections.Generic;

class GameStartMenu
{
  public static bool ArenaMenu(string decision, Character chosen, bool exit, ref bool DayOrNight, List<Monster> Cages, List<Food>FoodTable, ref bool timePass)
  {    
    switch(decision)
    {
      case("N"):
        int choice;
        Monster monster = new Monster();
        Console.Clear();
        GameScreen.CharacterStats(chosen);
        
        ArenaEntrance.MonsterOfTheDayDisplay(Cages);        
        do{
          choice = InputCheck.IntCheck("Choice(0 to go back):", "Only Numbers.");
        }while(choice < 0 || choice > Cages.Count);     

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
          timePass = true;
          DayOrNight = !DayOrNight;
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
          InnScreen.FoodDisplay(FoodTable);

          int choiceInn = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");
          if(choiceInn == 0)
          {
            Console.Clear();  
            return true;
          }
          else
          {
            timePass = true;
            choiceInn--;
            Console.WriteLine("Food eaten!");
            Console.ReadKey();   
            DayOrNight = !DayOrNight;
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