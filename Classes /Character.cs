class Character
{
  public int PlayerId{get;set;}
  public string PlayerName {get; set;}
  
  public int XP {get; set;}
  public int Level {get; set;}

  public int Str{get; set;}
  public int Int{get; set;}
  public int Agi{get; set;}
  public int Vig{get; set;}

  public int Health{get; set;}
  public int Mana{get; set;}

  public Character(int playerId, string playerName, int str, int inte, int agi, int vig)
  {
    PlayerId = playerId;
    PlayerName = playerName;

    XP = 0;
    Level = 1;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Health = 5 + (vig * 5);
    Mana = 3 + (inte * 3);
  }
}