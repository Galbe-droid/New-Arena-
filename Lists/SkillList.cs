using System;
using System.Collections.Generic;

//Id - Info 
//0 : Defensive Position, despite being a skill this is the base action for Defense in the game 
//10 - 100 : Buffskills
//101 - 200 : DebuffSkills
//201 - 300 : AttackSkills
//301 - 400 : DefenseSkills

class SkillList{
  public static List<SkillBase> AllSkills = new List<SkillBase>();
  /*public static List<BuffSkill> BuffSkillList = new List<BuffSkill>();
  public static List<DebuffSkill> DebuffSkillList = new List<DebuffSkill>();
  public static List<AttackSkill> AttackSkillList = new List<AttackSkill>();*/

  public static void AddSkills(){
    //BuffSkills int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new BuffSkill(0,"Defensive Position", "Increase Base Defese", 2, 4, 0, true, BuffType.Defense));

    //DebuffSkills int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new DebuffSkill(101, "Nasty Provocation", "Decrease Enemy Dodge", 2, 2, 0, true, BuffType.Dodge));

    //AttackSkills int id, string name, string desc, int turnsMax, int cost, int minDamage, int maxDamage, float modifier, StatsType playerStat
    AllSkills.Add(new AttackSkill(201, "Deep Strike", "A far more powerful strike", 3, 0, 10, 20, 1.3, StatsType.Str));
  }
}