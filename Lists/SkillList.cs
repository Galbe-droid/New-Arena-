using System;
using System.Collections.Generic;

class SkillList{
  public static List<BuffSkill> BuffSkillList = new List<BuffSkill>();

  //int id, string name, string desc, int turnsMax, int qty, bool isActivedOnce
  public static void AddSkills(){
    BuffSkillList.Add(new BuffSkill(0,"Defensive Position", "Increase Base Defese", 2, 4, true, BuffType.Defense));
  }
}