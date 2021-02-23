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

  public int Health{get; set;}
  public int Damage{get; set;}
  public int Mana{get; set;}
  public int ManaSpend{get; set;}

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

    Health = 5 + (vig * 5);
    Mana = 3 + (inte * 3);

    Damage = 0;
    ManaSpend = 0;
  }
}