using System;
using System.Collections.Generic;

class GameScreen
{
  public static List<Character> GameList = Lists.CharacterList;

  public static void CharacterSelection()
  {
    Lists.PlayerShowList();
    Console.Write("Select you caracter by Id:");    
  }

  public static void CharacterStats(Character chosen)
  {
    int hp = chosen.Health;
    int mp = chosen.Mana; 

    int dmg = chosen.Damage;
    int mpSpend = chosen.ManaSpend;
  }

  public static void CharacterBar(int HealthOrMana, int DamageOrSpend)
  {

  }
}