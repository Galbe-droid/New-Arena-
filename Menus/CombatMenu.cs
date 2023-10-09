using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Game_Objects.Base_Objects;

//This menu is the options for attacks of the player
//A - Basic Attacks - Working
//D - Basic Defense - Working
//S - Skill - Working
//I - Item - In Progress
class CombatMenu
{
  public static void PlayerChoice(ref Character c, ref Monster m){
    string choice = "";
    bool actionMade = false;

    do{
      //Loads Combat Choice, currently only attack and defense
      CombatScreen.CombatChoices(c, m);    

      Console.Write("Choose:");
      string[] acceptableChoices = {"a", "d", "s", "i"};

      do{
        choice = Console.ReadLine();
      }while(!acceptableChoices.Contains(choice));  

      PlayerOptions(ref c, ref m, choice, ref actionMade);

      if(actionMade == false)
        UpdateConsole.UpdateCombatStats(c, m);  

    }while(actionMade == false);
  }

  public static void PlayerOptions(ref Character c, ref Monster m, string choice, ref bool actionMade){
    switch(choice){
      case "a":
        m.Damage += BasicCombatBehaviour.AttackOption<Creature>(c, m);
        actionMade = true;
        break;

      case "d":
        BasicCombatBehaviour.DefensiveOption(c);
        actionMade = true;
        break;

      case "s":
        if(c.SkillTrained.Count == 1){
          UpdateConsole.StaticMessage("No Skills.");
        }
        else{
          int skillChoice = PlayerSkillUse.SkillChoice(c, m, out skillChoice);
          actionMade = skillChoice == -1 ? false : true;
        }
        break;

      case "i":
        if(c.ItemBag.Count == 0)
        {
          UpdateConsole.StaticMessage("No itens... ");
          break;
        }
        
        Consumable consume = new(BasicCombatBehaviour.ItemOption(c.ItemBag));
        if(consume.Id == 9999)
          break;

        c = BasicCombatBehaviour.ConsumableUse(c, consume);
        c.ItemBag.Remove(c.ItemBag.First(item => item.Id == consume.Id));
        actionMade = true;
        break;

      default:
        Console.Write("Invalid");
        break;
    }
  }
}