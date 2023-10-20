using System;
using New_Arena_.Behaviour;
using New_Arena_.Menus;

class GameStartMenu
{
  public static void ArenaMenu(string decision,ref Character chosen, ref bool DayOrNight, ref bool timePass)
  {       
    switch(decision)
    {
      //Goes to the cages 
      //Infoms the monsters for the player 
      case "N":
        int choice;
        Monster monster = new();
        Console.Clear();
        //Cages Screen and monster info
        GameScreen.CharacterStats(chosen);        
        ArenaEntrance.MonsterOfTheDayDisplay(); 
        //
      
        do{
          choice = InputCheck.IntCheck("Choice(0 to go back):", "Only Numbers.");
        }while(choice < 0 || choice > ArenaBehaviour.cages.Count);     
      
        if(choice == 0)
        {          
          Console.Clear();
        }
        else 
        {
          for(int i = 0; i < ArenaBehaviour.cages.Count; i++)
          {
            if (i == choice - 1)
            {
              monster = new Monster(ArenaBehaviour.cages[i]);
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
        MarketMenu.MarketDecision(ref chosen);
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
          InnBehaviour.InnFunction(ref chosen);         
          timePass = true;
          //Change to night 
          DayOrNight = !DayOrNight;
        }
        break;        

      //Training Hall
      case "T":
        Console.Clear();
        TrainingHallMenu.TrainingDecision(ref chosen);
        break;    

      case "C":
        Console.Clear();
        Console.WriteLine(chosen.ToString());
        Console.WriteLine("=============Skill============");
        Console.WriteLine(chosen.ShowSkills());
        Console.WriteLine("=============Bag============");
        Console.WriteLine(chosen.ShowBag());
        Console.WriteLine("Press anything to go back...");
        Console.ReadKey();
        Console.Clear();
        break;

      case "Q":
        Console.Clear();
        CharacterEquipamentMenu.Decision(ref chosen);
        break;

      default:
        Console.WriteLine("Invalid.");
        break;
    }
  }
}