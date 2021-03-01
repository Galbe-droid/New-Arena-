class Fruit : Food
{
  public FruitType Type {get; set;}

  public Fruit(int id, string name, int cost, int rarity, int hp, int mp, FruitType type)
  {
    Id = id;
    Name = name; 
    Cost = cost;
    Rarity = rarity;
    RecoveryHp = hp; 
    RecoveryHp = mp;
    Type = type;
  }

  public Fruit(Fruit f)
  {
    Id = f.Id;
    Name = f.Name; 
    Cost = f.Cost;
    Rarity = f.Rarity;
    RecoveryHp = f.RecoveryHp; 
    RecoveryHp = f.RecoveryMp;
    Type = f.Type;
  }
}