using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class GameStartMenu
{
  public static void ArenaMenu(string decision,ref Character chosen, ref bool DayOrNight, List<Monster> Cages, List<IFood>FoodTable, List<SkillBase> skillOfTheDay, ref bool timePass)
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
          AttributeAlocation.AddSkills(ref monster);
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
        }
        else
        {
          ArenaBehaviour.InnFunction(ref chosen, FoodTable);         
        }
        break;        

      //Training Hall
      //Under Development 
      case("T"):
        Console.Clear();
        TrainingHallMenu.TrainingDecision(ref chosen, skillOfTheDay);
        break;    

      case("C"):
        Console.Clear();
        String character = chosen.ToString();
        Console.WriteLine(character + chosen.ShowSkills());
        Console.WriteLine("Press anything to go back...");
        Console.ReadKey();
        Console.Clear();
        break;

      default:
        Console.WriteLine("Invalid.");
        break;
    }
  }
}