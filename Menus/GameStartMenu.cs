using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;
using New_Arena_.Menus;

class GameStartMenu
{
  public static void ArenaMenu(string decision,ref Character chosen, ref bool DayOrNight, List<Monster> Cages, List<Food>FoodTable, List<SkillBase> skillOfTheDay, ref bool timePass, List<Potion> potionList, List<Weapon> weaponList, List<Armor> armorList)
  {       
    switch(decision)
    {
      //Goes to the cages 
      //Infoms the monsters for the player 
      case "N":
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
          MainClass.Combat(chosen, monster);
          Console.Clear();
        }
        break;       

      //Market 
      //Under Development
      case "M":
        MarketMenu.MarketDecision(ref chosen, potionList, weaponList, armorList);
        break;

      //Inn
      case "I":
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
          InnBehaviour.InnFunction(ref chosen, FoodTable);         
          timePass = true;
          //Change to night 
          DayOrNight = !DayOrNight;
        }
        break;        

      //Training Hall
      case "T":
        Console.Clear();
        TrainingHallMenu.TrainingDecision(ref chosen, skillOfTheDay);
        break;    

      case "C":
        Console.Clear();
        String character = chosen.ToString();
        Console.WriteLine(character);
        Console.WriteLine("=============Skill============");
        Console.WriteLine(chosen.ShowSkills());
        Console.WriteLine("=============Bag============");
        Console.WriteLine(chosen.ShowBag());
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