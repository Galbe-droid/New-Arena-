using System;
using System.Collections.Generic;

class InnScreen
{
  
  public static void FoodDisplay(List<Fruit> FruitsOfTheDay)
  {
    int count = 0;
    Console.WriteLine("============Fruits==============");

    foreach(Fruit f in FruitsOfTheDay)
    {
      Console.WriteLine((count + 1) + " - Name:" + f.Name + " Hp:" + f.RecoveryHp + " Mp:" + f.RecoveryMp + " Condition:" + f.Quality);
      count ++ ;
    }

    Console.WriteLine("================================");
  }
}