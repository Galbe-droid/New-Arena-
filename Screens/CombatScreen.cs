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
    

    Console.WriteLine("Name:" + c.Name + " Lvl:" + c.Level + "  ///  " + "Monster:" + m.Name + " Lvl:" + m.Level);
    
    Console.WriteLine("=================================");

    Console.WriteLine(c.Name + " ///// " + m.Name);
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

    Console.WriteLine("=================================");
  }

  private static void _CombatInfo(float HealthOrMana, float DamageOrSpend)
  {
    float maxHealthOrMana = HealthOrMana;
    float actualHealthOrMana = HealthOrMana - DamageOrSpend;

    Console.Write("(" + actualHealthOrMana + "/" + maxHealthOrMana +  ")");
  }
}