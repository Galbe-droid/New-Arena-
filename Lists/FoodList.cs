using System;
using System.Collections.Generic;

//This are the prefab list of food this list is load in the beginning before the game loads, then inside the game this prefab are used  
class FoodList
{
  public static List<Fruit> FruitList = new List<Fruit>();

  public static void AddFruits()
  {
    //public Fruit(int id, string name, int cost, int rarity, int hp, int mp, FruitType type)
    FruitList.Add(new Fruit(0, "Apple", 0, 0, 10, 0,FruitQuality.Prefab));

    FruitList.Add(new Fruit(1, "Pear", 0, 0, 5, 0, FruitQuality.Prefab));

    FruitList.Add(new Fruit(2, "Apricot", 0, 1, 15, 5, FruitQuality.Prefab));

    FruitList.Add(new Fruit(3, "Gooey Blue Fruit", 0, 2, 5, 20, FruitQuality.Prefab));

    FruitList.Add(new Fruit(4, "Gooey Red Fruit", 0, 2, 30, 5, FruitQuality.Prefab));
  } 
}