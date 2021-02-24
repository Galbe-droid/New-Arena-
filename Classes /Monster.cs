using System;

class Monster
{
  public int Id{get;set;}
  public string Name {get; set;}
  
  public int Level {get; set;}
  public Types Type {get; set;}

  public int Str{get; set;}
  public int Int{get; set;}
  public int Agi{get; set;}
  public int Vig{get; set;}

  public float Health{get; set;}
  public float Mana{get; set;}

  public Monster(int id, string name, int level, Types type, int str, int inte, int agi, int vig)
  {
    Id = id;
    Name = name;

    Level = level;
    Type = type;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Health = 5 + (vig * 5);
    Mana = 3 + (inte * 3);
  }
}