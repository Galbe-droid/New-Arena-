using System;

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
          CombatMonsterBehaviour.MonsterChoice(cTrueDefense, cTrueDodge, mTrueAttack, m.Type);
        }    
        else {
          CombatMonsterBehaviour.MonsterChoice(cTrueDefense, cTrueDodge, mTrueAttack, m.Type);
          m.Damage += CombatBehaviour.AttackOption(cTrueAttack, mTrueDefense, mTrueDodge);
        }      
        break;
        
    case "b":
        break;

      default:
        break;
    }
    Console.WriteLine("End of Turn !");
    Console.ReadLine();
  }
}