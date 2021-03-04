using System;

class CombatMenu
{
  public static bool CombatChoices(Character c, Monster m, string choice, bool DeathCheck, bool DefenseChoice)
  {
    switch(choice)
    {
      case "A":
        int CharTrueAttack = c.Attack + c.ModAttack;

        int MonsterTrueDefense = m.Defense + m.ModDefense;
        int MonsterTrueDodge = m.Dodge + m.ModDodge;
    
        CombatBehaviour.AttackOption(CharTrueAttack, MonsterTrueDefense, MonsterTrueDodge);
        return false;
        
      case "D":
        return true;

      default:
        return false;
    }
  }
}