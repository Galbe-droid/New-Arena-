//Fruit class it generate a fruit, It easy to find in the inn but wont recovery a lot 
class Fruit : Food
{
  public FruitQuality Quality {get; set;}
  
  public Fruit(int id, string name, int cost, int rarity, int hp, int mp, FruitQuality quality)
  {
    Id = id;
    Name = name; 
    Cost = cost;
    Rarity = rarity;
    RecoveryHp = hp; 
    RecoveryMp = mp;
    Quality = quality;
  }

  public Fruit(Fruit f)
  {
    Id = f.Id;
    Name = f.Name; 
    Cost = f.Cost;
    Rarity = f.Rarity;
    RecoveryHp = f.RecoveryHp; 
    RecoveryMp = f.RecoveryMp;
    Quality = f.Quality;
  }
}