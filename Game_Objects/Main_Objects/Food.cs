//Fruit class it generate a fruit, It easy to find in the inn but wont recovery a lot 
using System;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class Food : ItemBase, IHpAndMpManipulation, IQuality, IQuantity
{
  public int HpModifier { get; set; }
  public int MpModifier { get; set; }
  public int Quantity { get; set; }

  public Food(int id, string name, int cost, int rarity, int hp, int mp)
  {
    Id = id;
    Name = name; 
    Cost = cost;
    Rarity = rarity;
    HpModifier = hp; 
    MpModifier = mp;
    Quality = FruitQuality.Prefab;
    Quantity = 1;
  }

  public Food(Food f)
  {
    Id = f.Id;
    Name = f.Name; 
    Cost = f.Cost;
    Rarity = f.Rarity;
    HpModifier = f.HpModifier; 
    MpModifier = f.MpModifier;
    Quality = f.Quality;
    Quantity = 1;
  }

  public Food()
  {
    Id = 9999;
    Name = ""; 
    Cost = 0;
    Rarity = 0;
    HpModifier = 0; 
    MpModifier = 0;
    Quality = Quality;
    Quantity = 1;
  }

  public void Action<T>(ref T character)where T : Creature
  {
    character.Damage -= character.Damage <= this.HpModifier ? character.Damage : this.HpModifier;
    character.ManaSpend -= character.ManaSpend <= this.MpModifier ? character.ManaSpend : this.MpModifier;
  }

  public override string ToString()
  {
      return @$"Name: {this.Name} Quality: {this.Quality} x{this.Quantity}";
  }
}