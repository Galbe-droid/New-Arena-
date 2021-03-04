using System;

class CombatMonsterBehaviour
{
  public static bool MonsterChoice(Character c, Monster m, bool DefenseBoost)
  {
    if(m.Type == Types.Offensive)
    {
      return false;
    }
    else if(m.Type == Types.Defensive)
    {
      return false;
    }
    else if(m.Type == Types.Balance)
    {
      return false;
    }
  }
}