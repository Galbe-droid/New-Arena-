using System;
using System.Collections.Generic;
using System.Linq;

class SkillChoices{
  static List<SkillBase> SkillOfTheDay = new List<SkillBase>();

  public static List<SkillBase> LearningSkill(Character c){
    Random rand = new Random();
    int[] ids = new int[c.CapableOfLearn.Count]; 
    int count = 0;
    
    foreach(SkillBase s in c.CapableOfLearn){
      ids[count] = s.Id;
      Console.WriteLine(ids[count]);
    }

    if(ids.Length >= 5){
      while(SkillOfTheDay.Count != 5){
        int idSelected = rand.Next(0, ids.Length);

        SkillOfTheDay.Add(c.CapableOfLearn.Find(x => x.Id == ids[idSelected]));

        SkillOfTheDay.Distinct().ToList();
      }
    }
    else if(ids.Length < 5 && ids.Length > 0){
      while(SkillOfTheDay.Count != ids.Length){
        int idSelected = rand.Next(0, ids.Length);

        SkillOfTheDay.Add(c.CapableOfLearn.Find(x => x.Id == ids[idSelected]));

        SkillOfTheDay.Distinct().ToList();
      }
    }

    return SkillOfTheDay;
  }

  public static void ClearSkills()
  {
    if(SkillOfTheDay.Count > 0)
    {
      SkillOfTheDay.Clear();
    }
  }
}