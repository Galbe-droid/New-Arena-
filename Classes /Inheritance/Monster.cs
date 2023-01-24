using System;
//Monster uses Creature Abstraction 
//Under modifications, passing some stats to an Abstract class
//Base Stats, Death, Monster Type
//Still no: Skills, Boss(Maybe)
class Monster : Creature
{
  public int Id{get;set;}
  public Types Type {get; set;}
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

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str;

    Health = 5 + (vig * 5);
    Mana = 3 + (inte * 3);

    Damage = 0;
    ManaSpend = 0;
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;

    Dead = false;
  }

  public Monster(Monster monster)
  {
    Id = monster.Id;
    Name = monster.Name;

    Level = monster.Level;
    Type = monster.Type;

    Str = monster.Str;
    Int = monster.Int;
    Agi = monster.Agi;
    Vig = monster.Vig; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str;

    Health = 5 + (Vig * 5);
    Mana = 3 + (Int * 3);

    Damage = 0;
    ManaSpend = 0;
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;

    Dead = false;
  }
  
  public Monster()
  {
    Id = 0;
    Name = "Monster";

    Level = 0;
    Type = Types.Prefab;

    Str = 0;
    Int = 0;
    Agi = 0;
    Vig = 0; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str;

    Health = 5 + (Vig * 5);
    Mana = 3 + (Int * 3);
    
    Damage = 0;
    ManaSpend = 0;
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;
  }
}