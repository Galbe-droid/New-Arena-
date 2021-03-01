using System;
using System.Collections.Generic;

class FoodList
{
  public static List<Fruit> FruitList = new List<Fruit>();

  public static void AddFruits()
  {
    //public Fruit(int id, string name, int cost, int rarity, int hp, int mp, FruitType type)
    FruitList.Add(new Fruit(0, "Apple", 0, 0, 10, 0,FruitType.Prefab));

    FruitList.Add(new Fruit(1, "Pear", 0, 0, 5, 0, FruitType.Prefab));

    FruitList.Add(new Fruit(2, "Apricot", 0, 1, 15, 5, FruitType.Prefab));

    FruitList.Add(new Fruit(3, "Goo Blue Fruit", 0, 2, 5, 20, FruitType.Prefab));

    FruitList.Add(new Fruit(4, "Goo Red Fruit", 0, 2, 30, 5, FruitType.Prefab));
  } 
}