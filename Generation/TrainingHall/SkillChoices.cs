using System;
using System.Collections.Generic;
using System.Linq;

class SkillChoices{  
  public static List<SkillBase> SkillOfTheDay = new List<SkillBase>();

  public static List<SkillBase> LearningSkill(Character c){    
    int CapableOfLearnLength = c.CapableOfLearn.Count;

    if(CapableOfLearnLength >= 5){
      PopulatingList(ref SkillOfTheDay, 5, c);
      return SkillOfTheDay;
    }
    else if(CapableOfLearnLength < 5 && CapableOfLearnLength > 0){
      PopulatingList(ref SkillOfTheDay, CapableOfLearnLength, c);
      return SkillOfTheDay;
    }
    else{
      return SkillOfTheDay;
    }
  }

  public static void PopulatingList(ref List<SkillBase> ListSkill, int skillQty, Character c){
    Random rand = new Random();

    int[] ids = new int[skillQty];

    foreach(SkillBase s in c.CapableOfLearn){
      ids.Append(s.Id);
    }

    while(ListSkill.Count == skillQty){
      int idChoose = ids[rand.Next(0, ids.Length)];
      
      foreach(SkillBase s in c.CapableOfLearn){
        if(!ListSkill.Exists(x => x.Id == idChoose)){
          if(s.GetType() == typeof(BuffSkill)){
            ListSkill.Add(new BuffSkill((BuffSkill)s));
          }
          else if(s.GetType() == typeof(DebuffSkill)){
            ListSkill.Add(new DebuffSkill((DebuffSkill)s));
          }
          else{
            ListSkill.Add(new AttackSkill((AttackSkill)s));
          }
        }
      }
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