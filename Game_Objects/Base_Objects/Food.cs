//Food abstract classes, since is a abstraction all foods types uses this base
abstract class Food
{
  public int Id {get; set;}
  public string Name {get; set;}

  public int Cost {get; set;}
  
  public int Rarity {get; set;}

  public int RecoveryHp {get; set;}
  public int RecoveryMp {get; set;}
}