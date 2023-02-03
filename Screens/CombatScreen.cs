using System;

//This screen shows the combat stats of player and monster, and players options for the combat 
class CombatScreen
{
  public static void Stats(ref Character c, ref Monster m)
  {
    float CharTrueDodge = (c.TotalDodge() / 100000f) * 100f;

    float MonsterTrueDodge = (m.TotalDodge() / 100000f) * 100f;
    

    Console.WriteLine("Name:" + c.Name + " Lvl:" + c.Level + "  ///  " + "Monster:" + m.Name + " Lvl:" + m.Level);
    
    Console.WriteLine("=================================");

    Console.WriteLine(c.Name + " Vs. " + m.Name);
    Console.Write("HP:");
    Console.Write("(" + c.ActualHp() + "/" + c.Health +  ")");
    Console.Write(" ///// ");
    Console.Write("HP:");
    Console.Write("(" + m.ActualHp() + "/" + m.Health +  ")");

    Console.WriteLine();

    Console.Write("MP:");
    Console.Write("(" + c.ActualMp() + "/" + c.Mana +  ")");
    Console.Write(" ///// ");
    Console.Write("MP:");
    Console.Write("(" + m.ActualMp() + "/" + m.Mana +  ")");

    Console.WriteLine();

    Console.WriteLine("Initiative");
    Console.WriteLine(c.Initiative + " ///// " + m.Initiative);

    Console.WriteLine("Attack");
    Console.WriteLine(c.TotalAttack() + " ///// " + m.TotalAttack());

    Console.WriteLine("Defense");
    Console.WriteLine(c.TotalDefense() + " ///// " + m.TotalDefense());

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
}