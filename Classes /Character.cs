class Character
{
  public int Id {get; set;}
  public string Name {get; set;}
  
  public int Xp {get; set;}
  public int Level {get; set;}

  public int Str{get; set;}
  public int Int{get; set;}
  public int Agi{get; set;}
  public int Vig{get; set;}

  public int Defense {get; set;}
  public int Dodge {get; set;}
  public int Attack {get; set;}

  public float Health{get; set;}
  public float Damage{get; set;}
  public float Mana{get; set;}
  public float ManaSpend{get; set;}

  public int Initiative{get; set;}
  public int ModDefense{get; set;}
  public int ModDodge{get; set;}
  public int ModAttack{get; set;}

  public Character(int id, string name, int str, int inte, int agi, int vig)
  {
    Id = id;
    Name = name;

    Xp = 0;
    Level = 1;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str;

    Health = 10 + (vig * 10);
    Mana = 5 + (inte * 5);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;
  }
}