using System;
using System.Collections.Generic;
using New_Arena_.Game_Objects.Base_Objects.Interface;

//List of Fuits on the Inn
class InnScreen
{
  
  public static void FoodDisplay(List<Food> FruitsOfTheDay)
  {
    int count = 0;
    Console.WriteLine("============Fruits==============");

    foreach(Food f in FruitsOfTheDay)
    {
      if(f.Quantity != 0)
      {
        Console.WriteLine((count + 1) + " - Name:" + f.Name + " Hp:" + f.HpModifier + " Mp:" + f.MpModifier + " Condition:" + f.Quality + " Quantity: x" + f.Quantity);
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine((count + 1) + " - Name:" + f.Name + " Hp:" + f.HpModifier + " Mp:" + f.MpModifier + " Condition:" + f.Quality + " Quantity: x" + f.Quantity);
        Console.ResetColor();
      }      
      count ++ ;
    }

    Console.WriteLine("================================");
  }
}