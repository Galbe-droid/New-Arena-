using System;
using System.Collections.Generic;

class SkillTrainingScreen{
  public static void SkillDisplay(List<SkillBase> skills){
    
    int count = 0;
    Console.WriteLine("============Skills==============");


    foreach(SkillBase s in skills)
    {
      Console.WriteLine();
      Console.WriteLine((count + 1) + " - " + s.ToString());
      count ++ ;
      Console.WriteLine();
    }

    Console.WriteLine("================================");    
  }
}