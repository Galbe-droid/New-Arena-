using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;

class SkillChoices{  
  //A List of the skill that the player can learn, it hold it values from one day, then it shuffles again 
  public static List<SkillBase> SkillOfTheDay = new List<SkillBase>();

  //Returns the list above to the TrainingHallMenu with the skills to learn
  public static List<SkillBase> LearningSkill(Character c, ref List<SkillBase> todaySkill){    
    //If the player has more then 5 skill to learn he will receive only 5 skill to learn per day, it's random
    if(c.CapableOfLearn.Count >= 5){
      PopulatingList(5, c, todaySkill);
      return todaySkill;
    }
    else if(c.CapableOfLearn.Count < 5 && c.CapableOfLearn.Count > 0){
      PopulatingList(c.CapableOfLearn.Count, c, todaySkill);
      return todaySkill;
    }
    else{
      return todaySkill;
    }
  }

  //Start populating the list with random skills that the Player can learn 
  public static void PopulatingList(int skillQty, Character c, List<SkillBase> todayList){
    List<int> skillIds = new();
    int count = 0;

    //It checks if the skill is already trained 
    foreach(SkillBase s in c.CapableOfLearn){
      if(!c.SkillTrained.Exists(x => x.Id == s.Id) && s.MinLevel <= ProgressBehaviour.CharacterLevel && count != skillQty)
      {
        skillIds.Add(s.Id);
        count++;
      }      
    }
  
    while(todayList.Count < skillQty){
      //Pick up a random Id
      int idChoose = skillIds[ManagerRandom.GetThreadRandom().Next(skillIds.Count)];

      //Check if the skill is already on the list 
      bool _alreadyOnList = todayList.Exists(skill => skill.Id == idChoose);

      if(!_alreadyOnList){
        SkillBase _skill = c.CapableOfLearn.Find(skill => skill.Id == idChoose);

        if(_skill.GetType() == typeof(BuffSkill))
          todayList.Add(new BuffSkill((BuffSkill)_skill));

        if(_skill.GetType() == typeof(DebuffSkill))
          todayList.Add(new DebuffSkill((DebuffSkill)_skill));

        if(_skill.GetType() == typeof(AttackSkill))
          todayList.Add(new AttackSkill((AttackSkill)_skill));

        if(_skill.GetType() == typeof(DefenseSkill))
          todayList.Add(new DefenseSkill((DefenseSkill)_skill));
      }
    }
  }

  //Clear the list for the next day 
  public static void ClearSkills(List<SkillBase> todayList)
  {
    if(todayList.Count > 0)
    {
      todayList.Clear();
    }
  }
}