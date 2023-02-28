using System;

//This menu is the options for attacks of the player
//A - Basic Attacks - Working
//D - Basic Defense - under Development
//S - Skill - TBD
class CombatMenu
{
  public static void CombatChoices(ref Character c, ref Monster m, string choice, bool charBigInit)
  {
    choice.ToUpper();

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

      case "s":
        if(charBigInit){
    
          if(m.Dead || c.Dead)
            break;
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
        }
        else{
          c = CombatMonsterBehaviour.MonsterChoice(ref c, ref m);
          if(m.Dead || c.Dead)
            break;
          
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