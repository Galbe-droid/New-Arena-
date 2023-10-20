using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Loading;

class FoodGeneration
{
    //Prefabs
    public static List<Food> FruitsPrefab = ItemsLoading.ConsumablesList;
    //Enum
    private static Array typeListFruit = Enum.GetValues(typeof(FruitQuality));

    private static List<Food> FruitOfTheDay = new List<Food>();

    //Creates the fruits and place then on the list
    private static Food FruitCreator()
    {
      int randId = ManagerRandom.GetThreadRandom().Next(FruitsPrefab.Count);

      Food food = new Food(FruitsPrefab.Find(f => f.Id == randId))
      {
          Quality = (FruitQuality)typeListFruit.GetValue(ManagerRandom.GetThreadRandom().Next(1, typeListFruit.Length))
      };

      if ((FruitQuality)food.Quality == FruitQuality.New)
      {
        food.HpModifier += (int)Math.Truncate(food.HpModifier * 0.2f);
        return food;
      }
      else
      {
        food.HpModifier -= (int)Math.Truncate(food.HpModifier * 0.2f);
        return food;
      }    
    }

  //Place the fruit on the list 
  public static List<Food> ListOfFruitOfTheDay()
  {
    for(int i = 0; i < ProgressBehaviour.InnFoodQuantity; i++)
    {
      Food food = FruitCreator();    
      
      Food foodInList = FruitOfTheDay.FirstOrDefault(X => X.Id == food.Id && X.Quality.ToString() == food.Quality.ToString());

      if(foodInList != null)
        foodInList.Quantity++;      
      else
        FruitOfTheDay.Add(food);
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