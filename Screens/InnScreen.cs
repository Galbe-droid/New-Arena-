using System;
using System.Collections.Generic;
using New_Arena_.Game_Objects.Base_Objects.Interface;

//List of Fuits on the Inn
class InnScreen
{
  
  public static void FoodDisplay(List<IFood> FruitsOfTheDay)
  {
    int count = 0;
    Console.WriteLine("============Fruits==============");

    foreach(Fruit f in FruitsOfTheDay)
    {
      if(f.FoodEaten == false)
      {
        Console.WriteLine((count + 1) + " - Name:" + f.Name + " Hp:" + f.RecoveryHp + " Mp:" + f.RecoveryMp + " Condition:" + f.Quality);
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine((count + 1) + " - Name:" + f.Name + " Hp:" + f.RecoveryHp + " Mp:" + f.RecoveryMp + " Condition:" + f.Quality);
        Console.ResetColor();
      }      
      count ++ ;
    }

    Console.WriteLine("================================");
  }


  public static void InnChoices(bool eating, bool taking)
  { 
    if(eating)
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.Write("1 - Eat Food");
      Console.ResetColor();
    }  
    else
    {
      Console.Write("1 - Eat Food");
    } 

    Console.Write(" / ");

    if(eating)
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.Write("2 - Take Some Food");
      Console.ResetColor();
    }
    else
    {
      Console.Write("2 - Take Some Food");
    }

    Console.WriteLine();
  }
}