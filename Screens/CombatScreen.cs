using System;

class CombatScreen
{
  public static void Stats(Character c, Monster m)
  {
    float hpCharacter = c.Health;
    float mpCharacter = c.Mana; 
    float hpMonster = m.Health;
    float mpMonster = m.Mana; 

    float dmgCharacter = c.Damage;
    float mpSpendCharacter = c.ManaSpend;
    float dmgMonster = m.Damage;
    float mpSpendMonster = m.ManaSpend;

    int CharTrueDefense = c.Defense + c.ModDefense;
    float CharTrueDodge = ((c.Dodge + c.ModDodge) / 100000f) * 100f;
    int CharTrueAttack = c.Attack + c.ModAttack;

    int MonsterTrueDefense = m.Defense + m.ModDefense;
    float MonsterTrueDodge = ((m.Dodge + m.ModDodge) / 100000f) * 100f;
    int MonsterTrueAttack = m.Attack + m.ModAttack;
    

    Console.WriteLine("Name:" + c.Name + " Lvl:" + c.Level + "  ///  " + "Monster:" + m.Name + " Lvl:" + m.Level);
    
    Console.WriteLine("=================================");

    Console.WriteLine(c.Name + " Vs. " + m.Name);
    Console.Write("HP:");
    _CombatInfo(hpCharacter, dmgCharacter);
    Console.Write(" ///// ");
    Console.Write("HP:");
    _CombatInfo(hpMonster, dmgMonster);

    Console.WriteLine();

    Console.Write("MP:");
    _CombatInfo(mpCharacter, mpSpendCharacter);
    Console.Write(" ///// ");
    Console.Write("MP:");
    _CombatInfo(mpMonster, mpSpendMonster);

    Console.WriteLine();

    Console.WriteLine("Initiative");
    Console.WriteLine(c.Initiative + " ///// " + m.Initiative);

    Console.WriteLine("Attack");
    Console.WriteLine(CharTrueAttack + " ///// " + MonsterTrueAttack);

    Console.WriteLine("Defense");
    Console.WriteLine(CharTrueDefense + " ///// " + MonsterTrueDefense);

    Console.WriteLine("Dodge");
    Console.WriteLine(CharTrueDodge + "%  ///// " + MonsterTrueDodge + "%");


    Console.WriteLine("=================================");    
  }

  public static void CombatChoices(Character c, Monster m)
  {
    Console.Write("First to Attack: ");
    if(c.Initiative > m.Initiative)
    {
      Console.Write(c.Name);
    }
    else
    {
      Console.Write(m.Name);
    }

    Console.WriteLine();

    Console.WriteLine("Options: A - Atack / D - Defend");
  }

  private static void _CombatInfo(float HealthOrMana, float DamageOrSpend)
  {
    float maxHealthOrMana = HealthOrMana;
    float actualHealthOrMana = HealthOrMana - DamageOrSpend;

    Console.Write("(" + actualHealthOrMana + "/" + maxHealthOrMana +  ")");
  }
}