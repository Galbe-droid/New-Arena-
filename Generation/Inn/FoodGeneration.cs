using System;
using System.Collections.Generic;

class FoodGeneration
{
  //ListOfTheDay
  public static List<Fruit> FruitOfTheDay = new List<Fruit>();

  //Prefabs
  public static List<Fruit> FruitsPrefab = FoodList.FruitList;

  //Enum
  public static Array typeListFruit = Enum.GetValues(typeof(FruitQuality));

  public static Fruit FruitCreator()
  {
    Random random = new Random();
    int randId = random.Next(FruitsPrefab.Count);

    Fruit fruit = new Fruit(FruitsPrefab.Find(f => f.Id == randId));

    while(fruit.Quality == FruitQuality.Prefab)
    {
      fruit.Quality = (FruitQuality)typeListFruit.GetValue(random.Next(typeListFruit.Length));
    }

    if(fruit.Quality == FruitQuality.New)
    {
      fruit.RecoveryHp += (int)(fruit.RecoveryHp * 0.2f);
      return fruit;
    }
    else
    {
      fruit.RecoveryHp -= (int)(fruit.RecoveryHp * 0.2f);
      return fruit;
    }    
  }

  public static List<Fruit> ListOfFruitOfTheDay()
  {
    for(int i = 0; i < 5; i++)
    {
      FruitOfTheDay.Add(FruitCreator());
    }

    return FruitOfTheDay;
  }

  public static void ClearFoods()
  {
    if(FruitOfTheDay.Count > 0)
    {
      FruitOfTheDay.Clear();
    }
  }
}