using System;
using System.Collections.Generic;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class FoodGeneration
{
    //ListOfTheDay
    private static List<IFood> fruitOfTheDay = new List<IFood>();

    //Prefabs
    public static List<Consumable> FruitsPrefab = FoodList.FruitList;

    //Enum
    public static Array typeListFruit = Enum.GetValues(typeof(FruitQuality));

    public static List<IFood> FruitOfTheDay { get => fruitOfTheDay; set => fruitOfTheDay = value; }

    //Creates the fruits and place then on the list
    public static Consumable FruitCreator()
    {
      Random random = new Random();
      int randId = random.Next(FruitsPrefab.Count);
  
      Consumable fruit = new Consumable(FruitsPrefab.Find(f => f.Id == randId));
  
      fruit.Quality = (FruitQuality)typeListFruit.GetValue(random.Next(1, typeListFruit.Length));
  
      if((FruitQuality)fruit.Quality == FruitQuality.New)
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
  public static List<IFood> ListOfFruitOfTheDay()
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