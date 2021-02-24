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

  public float Health{get; set;}
  public float Damage{get; set;}
  public float Mana{get; set;}
  public float ManaSpend{get; set;}

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

    Health = 10 + (vig * 10);
    Mana = 5 + (inte * 5);

    Damage = 0;
    ManaSpend = 0;
  }
}