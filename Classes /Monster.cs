using System;

class Monster
{
  public int MonsterId{get;set;}
  public string MonsterName {get; set;}
  
  public int XP {get; set;}
  public int Level {get; set;}
  public int Tier {get; set;}

  public int Str{get; set;}
  public int Int{get; set;}
  public int Agi{get; set;}
  public int Vig{get; set;}

  public int Health{get; set;}
  public int Mana{get; set;}

  public Monster(int monsterId, string monsterName, int tier, int str, int inte, int agi, int vig)
  {
    MonsterId = MonsterId;
    MonsterName = MonsterName;

    XP = 0;
    Level = 1;
    Tier = tier;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Health = 5 + (vig * 5);
    Mana = 3 + (inte * 3);
  }
}