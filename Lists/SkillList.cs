using System;
using System.Collections.Generic;

//Id - Info 
//0 : Defensive Position, despite being a skill this is the base action for Defense in the game 
//10 - 100 : Buffskills
//101 - 200 : DebuffSkills
//201 - 300 : AttackSkills
//301 - 400 : DefenseSkills

class SkillList{
  public static List<BuffSkill> BuffSkillList = new List<BuffSkill>();
  public static List<DebuffSkill> DebuffSkillList = new List<DebuffSkill>();

  //int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce
  public static void AddSkills(){
    //BuffSkills
    BuffSkillList.Add(new BuffSkill(0,"Defensive Position", "Increase Base Defese", 2, 4, 0, true, BuffType.Defense));

    //DebuffSkills
    DebuffSkillList.Add(new DebuffSkill(101, "Nasty Provocation", "Decrease Enemy Dodge", 2, 2, 0, true, BuffType.Dodge));
  }
}