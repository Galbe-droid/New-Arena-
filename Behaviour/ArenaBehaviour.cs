using System;

class ArenaBehaviour
{
  //Controls Day and night behaviour, certain activities depend on it 
  public static bool DayToNight(bool dayTime)
  {
    if(dayTime == true)
    {
      dayTime = false;
      return dayTime;
    }
    else
    {
      dayTime = true;
      return dayTime;
    }
  }
  public static void TurnControl(ref Character chosen, ref Monster monster, bool initiative)
  {
    if(initiative)
    {
      Console.WriteLine("Turn Start !!");
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        CombatMenu.CombatChoices(ref chosen, ref monster);
        UpdateConsole.StaticMessage("Player turn ended.");
      }      
      //Monster Turn
      if(!monster.DeathCheck())
      {
        CombatMonsterBehaviour.MonsterChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage($"{monster.Name} turn ended.");
      }
      
    }
    else
    {
      //Monster Turn
      if(!monster.DeathCheck())
      {
        CombatMonsterBehaviour.MonsterChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage($"{monster.Name} turn ended.");
      }
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        CombatMenu.CombatChoices(ref chosen, ref monster);
        UpdateConsole.StaticMessage("Player turn ended.");
      }      
    }    
  }
}