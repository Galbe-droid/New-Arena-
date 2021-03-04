using System;

class CombatBehaviour
{
  public static int AttackOption(int Attacker, int Defender, int DefenderDodge)
  {
    Random rand = new Random();
    int TotalAtaque = rand.Next(0,20) + Attacker;
    int TotalDefense = rand.Next(0,20) + Defender;

    int DodgeChance = rand.Next(0,100001);

    if(DodgeChance < DefenderDodge)
    {
      return 0;
    }
    else
    {
      if(TotalDefense >= TotalAtaque)
      {
        return 0;
      }
      else
      {
        return TotalAtaque - TotalDefense;
      }
    }
  }

  public static int DefenseOption(int Defense)
  {
    int BoostedDefense = Defense;
    return BoostedDefense;
  }

  public static bool CheckForDeath(Character c, Monster m, bool death)
  {
    return false;
  }

  public static void PlayerWins(Character c)
  {

  }

  public static void PlayerLoses(Character c)
  {

  }
}