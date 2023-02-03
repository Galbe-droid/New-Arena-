using System;

//This menu is the options for attacks of the player
//A - Basic Attacks - Working
//D - Basic Defense - under Development
//S - Skill - TBD
class CombatMenu
{
  public static void CombatChoices(ref Character c, ref Monster m, string choice, bool charBigInit)
  {
    int cTrueAttack = c.Attack + c.ModAttack;
    int cTrueDefense = c.Defense + c.ModDefense;
    int cTrueDodge = c.Dodge + c.ModDodge;

    int mTrueAttack = m.Attack + m.ModAttack;
    int mTrueDefense = m.Defense + m.ModDefense;
    int mTrueDodge = m.Dodge + m.ModDodge;

    choice.ToUpper();

    Console.WriteLine("Turn Start !!");
    
    switch(choice)
    {
    case "a":
        if (charBigInit){
          m.Damage += CombatBehaviour.AttackOption(cTrueAttack, mTrueDefense, mTrueDodge);

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
          
          m.Damage += CombatBehaviour.AttackOption(cTrueAttack, mTrueDefense, mTrueDodge);
        }      
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
        break;

      default:
        Console.Write("Invalid.");
        break;
    }
    Console.WriteLine("End of Turn !");
    Console.ReadLine();
  }
}