using System;
using System.Collections.Generic;


class GameStartMenu
{
  public static bool ArenaMenu(string decision,ref Character chosen, bool exit, ref bool DayOrNight, List<Monster> Cages, List<Food>FoodTable, List<SkillBase> SkillList, ref bool timePass)
  {    
    switch(decision)
    {
      //Goes to the cages 
      //Infoms the monsters for the player 
      case("N"):
        int choice;
        Monster monster = new Monster();
        Console.Clear();
        //Cages Screen and monster info
        GameScreen.CharacterStats(chosen);        
        ArenaEntrance.MonsterOfTheDayDisplay(Cages); 
        //
      
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
          //Change to night 
          DayOrNight = !DayOrNight;
          //Initiate Combat 
          monster.Initialization();
          MainClass.Combat(chosen, monster);
          Console.Clear();
        }
        break;       

      //Market 
      //Under Development
      case("M"):
        Console.WriteLine("Not Ready!");
        break;

      //Inn
      //Under Development - Can only choose the food, nothing happens 
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
            choiceInn--;
            Food foodChoice = FoodTable[choiceInn];
            timePass = true;
            Console.WriteLine("Food eaten!");
            chosen.Damage -= foodChoice.RecoveryHp;
            chosen.ManaSpend -= foodChoice.RecoveryMp;
            Console.ReadKey();   
            DayOrNight = !DayOrNight;
            Console.Clear();
          }       
          break;
        }        

      //Training Hall
      //Under Development 
      case("T"):
        Console.Clear();
        TrainingHallMenu.TrainingDecision(ref chosen, SkillList);
        break;      

      default:
        Console.WriteLine("Invalid.");
        break;
    }
    return false;
  }
}