using System;
using System.Collections.Generic;
using System.Linq;

class SkillChoices{  
  //A List of the skill that the player can learn, it hold it values from one day, then it shuffles again 
  public static List<SkillBase> SkillOfTheDay = new List<SkillBase>();

  //Returns the list above to the TrainingHallMenu with the skills to learn
  public static List<SkillBase> LearningSkill(Character c){    
    int CapableOfLearnLength = c.CapableOfLearn.Count;

    //If the player has more then 5 skill to learn he will receive only 5 skill to learn per day, it's random
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

  //Start populating the list with random skills that the Player can learn 
  public static void PopulatingList(int skillQty, Character c){
    Random rand = new Random();

    int count = 0;
    //Pick up the total quantity of skills that are avaliable to learn, minus the Id 0 skill witch is the defense options 
    int capableOfLearnQuantity = (c.CapableOfLearn.Count() - c.SkillTrained.Count()) + 1;
    int[] ids = new int[capableOfLearnQuantity];

    //It checks if the skill is already trained 
    foreach(SkillBase s in c.CapableOfLearn){
      if(!c.SkillTrained.Exists(x => x.Id == s.Id))
      {
        ids[count] = s.Id;
        count++;
      }      
    }
  
    while(SkillOfTheDay.Count < skillQty){
      //Pick up a random Id
      int idChoose = ids[rand.Next(0, ids.Length)];

      //Check if the skill is already on the list 
      bool _alreadyOnList = SkillOfTheDay.Exists(skill => skill.Id == idChoose) ? true : false;

      if(!_alreadyOnList){
        SkillBase _skill = c.CapableOfLearn.Find(skill => skill.Id == idChoose);

        if(_skill.GetType() == typeof(BuffSkill))
          SkillOfTheDay.Add(new BuffSkill((BuffSkill)_skill));

        if(_skill.GetType() == typeof(DebuffSkill))
          SkillOfTheDay.Add(new DebuffSkill((DebuffSkill)_skill));

        if(_skill.GetType() == typeof(AttackSkill))
          SkillOfTheDay.Add(new AttackSkill((AttackSkill)_skill));

        if(_skill.GetType() == typeof(DefenseSkill))
          SkillOfTheDay.Add(new DefenseSkill((DefenseSkill)_skill));
      }
    }
  }

  //Clear the list for the next day 
  public static void ClearSkills()
  {
    if(SkillOfTheDay.Count > 0)
    {
      SkillOfTheDay.Clear();
    }
  }
}