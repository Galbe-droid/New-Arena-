using System;
using System.Collections.Generic;

//This menu is the options for attacks of the player
//A - Basic Attacks - Working
//D - Basic Defense - under Development
//S - Skill - TBD
class CombatMenu
{
  public static void CombatChoices(ref Character c, ref Monster m, string choice, bool charBigInit)
  {
    choice.ToUpper();
    bool actionMade = false;
    Console.WriteLine("Turn Start !!");
    
    switch(choice)
    {
      case "a":
        if (charBigInit){
          m.Damage += CombatBehaviour.AttackOption(c.TotalAttack(), m.TotalDefense(), m.TotalDodge());

          //Checks if player or monster are dead 
          if(m.Dead || c.Dead)
            break;
          
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
        }    
        else {
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);

          //Checks if player or monster are dead
          if(m.Dead || c.Dead)
            break;
          
          m.Damage += CombatBehaviour.AttackOption(c.TotalAttack(), m.TotalDefense(), m.TotalDodge());
        }      
        actionMade = true;
        break;
        
      case "d":
        if(charBigInit){
          CombatBehaviour.DefensiveChoice(ref c);

          if(m.Dead || c.Dead)
            break;
          
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
        }else{          
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);

          if(m.Dead || c.Dead)
            break;
          
          CombatBehaviour.DefensiveChoice(ref c);
        }    
        actionMade = true; 
        break;

      case "s":
        if(c.SkillTrained.Count == 1){
          Console.WriteLine("No Skills.");
        }
        else{          
          if(charBigInit){
            CombatBehaviour.SkillChoice(ref c, ref m);
            if(m.Dead || c.Dead)
              break;
            c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
          }
          else{
            c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
            if(m.Dead || c.Dead)
              break;
            CombatBehaviour.SkillChoice(ref c, ref m);          
          }
        }        
        break;

      default:
        Console.Write("Invalid.");
        break;
    }
    Console.WriteLine("End of Turn !");
    Console.ReadLine();
  }
}