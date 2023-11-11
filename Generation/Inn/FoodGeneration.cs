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

    //Creates the fruits and place then on the list
    private static Food FruitCreator()
    {
      List<int> foodId = new();

      foreach(Food foodInList in FruitsPrefab)
      {
        if(foodInList.Rarity <= ProgressBehaviour.CharacterLevel)
          foodId.Add(foodInList.Id);
      }

      int randId = foodId[ManagerRandom.GetThreadRandom().Next(foodId.Count)];

      Food food = new Food(FruitsPrefab.Find(f => f.Id == randId))
      {
          Quality = (FruitQuality)typeListFruit.GetValue(ManagerRandom.GetThreadRandom().Next(1, typeListFruit.Length))
      };

      if (food.Quality == FruitQuality.New)
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
  public static List<Food> ListOfFruitOfTheDay(ref List<Food> todayFood)
  {
    for(int i = 0; i < ProgressBehaviour.InnFoodQuantity; i++)
    {
      Food food = FruitCreator();          
      Food foodInList = todayFood.FirstOrDefault(X => X.Id == food.Id && X.Quality.ToString() == food.Quality.ToString());

      if(foodInList != null)
        foodInList.Quantity++;      
      else
        todayFood.Add(food);
    }

    return todayFood;
  }

  //Clear the fruits of the list
  public static void ClearFoods(List<Food> todayFood)
  {
    if(todayFood.Count > 0)
    {
      todayFood.Clear();
    }
  }
}