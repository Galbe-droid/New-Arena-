using System;
using System.Collections.Generic;

class FoodGeneration
{
  //ListOfTheDay
  public static List<Food> FruitOfTheDay = new List<Food>();

  //Prefabs
  public static List<Fruit> FruitsPrefab = FoodList.FruitList;

  //Enum
  public static Array typeListFruit = Enum.GetValues(typeof(FruitQuality));

  //Creates the fruits and place then on the list
  public static Fruit FruitCreator()
  {
    Random random = new Random();
    int randId = random.Next(FruitsPrefab.Count);

    Fruit fruit = new Fruit(FruitsPrefab.Find(f => f.Id == randId));

    fruit.Quality = (FruitQuality)typeListFruit.GetValue(random.Next(1, typeListFruit.Length));

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

  //Place the fruit on the list 
  public static List<Food> ListOfFruitOfTheDay()
  {
    for(int i = 0; i < 5; i++)
    {
      FruitOfTheDay.Add(FruitCreator());
    }

    return FruitOfTheDay;
  }

  //Clear the fruits of the list
  public static void ClearFoods()
  {
    if(FruitOfTheDay.Count > 0)
    {
      FruitOfTheDay.Clear();
    }
  }
}