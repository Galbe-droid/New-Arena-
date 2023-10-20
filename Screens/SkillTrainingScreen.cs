using System;
using System.Collections.Generic;

class SkillTrainingScreen{
  public static void SkillDisplay(){
    
    int count = 0;
    Console.WriteLine("============Skills==============");


    foreach(SkillBase s in ArenaBehaviour.skillOfTheDay)
    {
      Console.WriteLine($"{count + 1} - {s.ToString()}");
      count ++ ;
    }

    Console.WriteLine("================================");    
  }
}