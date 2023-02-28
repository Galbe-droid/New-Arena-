using System;
using System.Collections.Generic;
using System.Linq;

class SkillChoices{  
  public static List<SkillBase> SkillOfTheDay = new List<SkillBase>();

  public static List<SkillBase> LearningSkill(Character c){    
    int CapableOfLearnLength = c.CapableOfLearn.Count;

    if(CapableOfLearnLength >= 5){
      PopulatingList(5, c);
      return SkillOfTheDay;
    }
    else if(CapableOfLearnLength < 5 && CapableOfLearnLength > 0){
      PopulatingList(CapableOfLearnLength, c);
      return SkillOfTheDay;
    }
    else{
      return SkillOfTheDay;
    }
  }

  public static void PopulatingList(int skillQty, Character c){
    Random rand = new Random();

    int count = 0;

    int[] ids = new int[skillQty];

    foreach(SkillBase s in c.CapableOfLearn){
      if(!c.SkillTrained.Exists(x => x.Id == s.Id)){
        ids[count] = s.Id;
        count++;
      }      
    }
    
    while(SkillOfTheDay.Count < skillQty){
      int idChoose = ids[rand.Next(0, ids.Length)];
      
      foreach(SkillBase s in c.CapableOfLearn){
        if(!SkillOfTheDay.Exists(x => x.Id == idChoose) || !c.SkillTrained.Exists(x => x.Id == idChoose)){
          if(s.GetType() == typeof(BuffSkill)){
            SkillOfTheDay.Add(new BuffSkill((BuffSkill)s));
          }
          else if(s.GetType() == typeof(DebuffSkill)){
            SkillOfTheDay.Add(new DebuffSkill((DebuffSkill)s));
          }
          else{
            SkillOfTheDay.Add(new AttackSkill((AttackSkill)s));
          }
        }
      }
      ids = ids.Where(id => id != idChoose).ToArray();
    }
  }

  public static void ClearSkills()
  {
    if(SkillOfTheDay.Count > 0)
    {
      SkillOfTheDay.Clear();
    }
  }
}