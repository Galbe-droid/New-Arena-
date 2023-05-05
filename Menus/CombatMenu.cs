using System;
using System.Collections.Generic;

//This menu is the options for attacks of the player
//A - Basic Attacks - Working
//D - Basic Defense - Working
//S - Skill - on Development
class CombatMenu
{
  public static void CombatChoices(ref Character c, ref Monster m, bool charBigInit)
  {    
    Console.WriteLine("Turn Start !!");    

    if(charBigInit){
      UpdateConsole.UpdateCombatStats(c, m);
      PlayerChoice(ref c, ref m);
      UpdateConsole.StaticMessage("Player turn ended.");
    }
    else{
      UpdateConsole.UpdateCombatStats(c, m);
      PlayerChoice(ref c, ref m);
      UpdateConsole.StaticMessage("Player turn ended.");
    }
    
    Console.WriteLine("End of Turn !");
    Console.ReadLine();
  }

  public static void PlayerChoice(ref Character c, ref Monster m){
    string choice = "";
    bool actionMade = false;

    do{
      //Loads Combat Choice, currently only attack and defense
      CombatScreen.CombatChoices(c, m);    

      Console.Write("Choose:");

      do{
        choice = Console.ReadLine();
      }while(choice != "a" && choice != "d" && choice != "s");  

      PlayerOptions(ref c, ref m, choice, ref actionMade);

      if(actionMade == false)
        UpdateConsole.UpdateCombatStats(c, m);  

    }while(actionMade == false);
  }

  public static void PlayerOptions(ref Character c, ref Monster m, string choice, ref bool actionMade){
    switch(choice){
      case "a":
        m.Damage += CombatBehaviour.AttackOption(c, m);
        actionMade = true;
        break;

      case "d":
        CombatBehaviour.DefensiveChoice(c);
        actionMade = true;
        break;

      case "s":
        if(c.SkillTrained.Count == 1){
          UpdateConsole.StaticMessage("No Skills.");
        }
        else{
          int skillChoice = CombatBehaviour.SkillChoice(c, m, out skillChoice);
          actionMade = skillChoice == -1 ? false : true;
        }
        break;

      default:
        Console.Write("Invalid");
        break;
    }
  }
}