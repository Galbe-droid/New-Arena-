using System;
using System.Collections.Generic;

//This screen shown the HP and MP for the player on the Arena Entrace 
class GameScreen
{
  public static void CharacterSelection()
  {
    CharacterListManagement.PlayerShowList();
  }

  public static void CharacterStats(Character chosen)
  {
    float tick = 0;

    float hp = chosen.Health;
    float mp = chosen.Mana; 

    float dmg = chosen.Damage;
    float mpSpend = chosen.ManaSpend;

    Console.WriteLine($"Name: {chosen.Name} Lvl: {chosen.Level} Xp:{chosen.Xp} Gold:{chosen.Gold}");

    Console.WriteLine("=================================");

    Console.Write("HP:");
    _CharacterBar(tick, hp, dmg);
    Console.Write("}");
    Console.WriteLine();

    Console.Write("MP:");
    _CharacterBar(tick, mp, mpSpend);
    Console.Write("}");
    Console.WriteLine();

    Console.WriteLine("=================================");

    Console.WriteLine("Str:" + chosen.Str + " Int:" + chosen.Int + " Agi:" + chosen.Agi + " Vig:" + chosen.Vig);

    Console.WriteLine("=================================");
  }

  public static void ArenaChoices(int days, string dayMoment)
  {
    int dayCount = days;

    Console.WriteLine("Arena Gates / Day:" + dayCount + " / " + dayMoment);
    

    Console.WriteLine("N - Entrance -" + dayMoment + "\nM - Market / I - Inn  / T - Trainning Hall\nC - See Character / Q - Equipament\nS - Save Game / E - Exit Game");
  }

  private static void _CharacterBar(float tick, float HealthOrMana, float DamageOrSpend)
  {
    float maxHealthOrMana = HealthOrMana;
    float actualHealthOrMana = HealthOrMana - DamageOrSpend;

    float BarTick = maxHealthOrMana / 10; 

    Console.Write("(" + actualHealthOrMana + "/" + maxHealthOrMana +  ")" + " {");
    while(tick <= maxHealthOrMana)
    {
      if(tick <= actualHealthOrMana)
      {
        Console.Write("=");
        tick += BarTick;
      }
      else
      {
        Console.Write("-");
        tick += BarTick;
      }      
    }
  }
}