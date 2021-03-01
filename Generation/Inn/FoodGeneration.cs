using System;
using System.Collections.Generic;

class FoodGeneration
{
  //ListOfTheDay
  public static List<Fruit> FruitOfTheDay = new List<Fruit>();

  //Prefabs
  public static List<Fruit> FruitsPrefab = FoodList.FruitList;

  //Enum
  public static Array typeListFruit = Enum.GetValues(typeof(FruitType));

  public static Fruit FruitCreator()
  {
    Random random = new Random();
    int randId = random.Next(FruitsPrefab.Count);

    Fruit fruit = new Fruit(FruitsPrefab.Find(f => f.Id == randId));

    while(fruit.Type == FruitType.Prefab)
    {
      fruit.Type = (FruitType)typeListFruit.GetValue(random.Next(typeListFruit.Length));
    }

    if(fruit.Type == FruitType.New)
    {
      fruit.RecoveryHp += Convert.ToInt32(fruit.RecoveryHp * 0.10);
    }
    else
    {
      fruit.RecoveryHp -= Convert.ToInt32(fruit.RecoveryHp * 0.2);
    }

    return fruit;
  }

  public static List<Fruit> ListOfFoodOfTheDay()
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