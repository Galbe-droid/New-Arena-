using System;
using System.Collections.Generic;

//Id - Info 
//0 : Defensive Position, despite being a skill this is the base action for Defense in the game 
//10 - 100 : Buffskills
//101 - 200 : DebuffSkills
//201 - 300 : AttackSkills
//301 - 400 : DefenseSkills

//Dodge works by 0.0% = 0 and 100.0% = 100000

class SkillList{
  public static List<SkillBase> AllSkills = new List<SkillBase>();

  public static void AddSkills(){
    //BuffSkills int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new BuffSkill(0,"Defensive Position", "Increase Base Defese", 2, 4, 0, true, BuffType.Defense));
    AllSkills.Add(new BuffSkill(10,"Light Movement", "Increase Dodge Chance", 2, 15000, 0, true, BuffType.Dodge));
    AllSkills.Add(new BuffSkill(11,"Weak Point", "Aims on the enemy weak point", 3, 4, 0, true, BuffType.Attack));
    AllSkills.Add(new BuffSkill(12,"Stone Skin", "Increase Def over 3 turns", 3, 2, 0, false, BuffType.Defense));

    //DebuffSkills int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new DebuffSkill(101, "Nasty Provocation", "Decrease Enemy Dodge", 2, -4000, 0, true, BuffType.Dodge));
    AllSkills.Add(new DebuffSkill(102, "Take Down", "Decrease Enemy Defense", 2, -4, 0, true, BuffType.Defense));

    //AttackSkills int id, string name, string desc, int turnsMax, int cost, int minDamage, int maxDamage, float modifier, StatsType playerStat
    //AllSkills.Add(new AttackSkill(201, "Deep Strike", "A far more powerful strike", 3, 0, 10, 20, 1.3, StatsType.Str));

    //DefenseSkills int id, string name, string desc, int turnsMax, int cost, int minValue, int maxValuew, float modifier, StatsType playerStat
    AllSkills.Add(new DefenseSkill(301, "First-Aid", "Simple regeneration", 1, 0, 5, 15, 1.5, StatsType.Inte));
  }
}