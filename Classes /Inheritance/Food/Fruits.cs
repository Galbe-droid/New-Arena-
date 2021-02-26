class Fruit : Food
{
  public int StatIncrement {get; set;}  
  public FruitType Type {get; set;}


  public Fruit(int id, string name, int cost, int rarity, int hp, int mp, int stats, FruitType type)
  {
    Id = id;
    Name = name; 
    Cost = cost;
    Rarity = rarity;
    RecoveryHp = hp; 
    RecoveryHp = mp;
    StatIncrement = stats;
    Type = type;
  }
}