//Fruit class it generate a fruit, It easy to find in the inn but wont recovery a lot 
using System;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class Fruit : ItemBase, IFood
{
  public FruitQuality Quality {get; set;}
  public int Cost { get; set; }
  public int Rarity { get; set; }
  public int RecoveryHp { get; set; }
  public int RecoveryMp { get; set; }
  Type IFood.Quality { get; set; }
  public bool FoodEaten {get; set;}

    public Fruit(int id, string name, int cost, int rarity, int hp, int mp, FruitQuality quality)
  {
    Id = id;
    Name = name; 
    Cost = cost;
    Rarity = rarity;
    RecoveryHp = hp; 
    RecoveryMp = mp;
    Quality = quality;
    FoodEaten = false;
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
    FoodEaten = false;
  }
}