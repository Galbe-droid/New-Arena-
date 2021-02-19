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

  public class Character(int PlayerId, string PlayerName, int Str, int Int, int Agi, int Vig)
  {
    public int PlayerId = PlayerId;
    public string PlayerName = PlayerName;

    public int XP = 0;
    public int Level = 1;

    public int Str = Str;
    public int Int = Int;
    public int Agi = Agi;
    public int Vig = Vig; 

    public int Health = 5 + (Vig * 5);
    public int Mana = 3 + (Int * 3);

  }
}