using System;
using System.Collections.Generic;

//Id - Info 
//0 : Defensive Position, despite being a skill this is the base action for Defense in the game 
//10 - 100 : Buffskills
//101 - 200 : DebuffSkills
//201 - 300 : AttackSkills
//301 - 400 : DefenseSkills
//1001 - 1010 : SlimeSkills
//1101 - 1110 : SpiderSkills
//1201 - 1210 : GolemSkills

//Dodge works by 0.0% = 0 and 100.0% = 100000

class SkillList{
  public static List<SkillBase> AllSkills = new List<SkillBase>();
  public static List<SkillBase> SlimeSkillList = new List<SkillBase>();
  public static List<SkillBase> SpiderSkillList = new List<SkillBase>();
  public static List<SkillBase> GolemSkillList = new List<SkillBase>();
  public static Dictionary<int, List<SkillBase>> ListPerMonster = new Dictionary<int, List<SkillBase>>();


  public static void AddSkills(){
    //BuffSkills int id, string name, string desc, int MinLevel, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new BuffSkill(0,"Defensive Position", "Increase Base Defese", 0, 2, 4, 0, true, BuffType.Defense));
    AllSkills.Add(new BuffSkill(10,"Light Movement", "Increase Dodge Chance", 0, 2, 15000, 0, true, BuffType.Dodge));
    AllSkills.Add(new BuffSkill(11,"Weak Point", "Aims on the enemy weak point", 0, 3, 4, 0, true, BuffType.Attack));
    AllSkills.Add(new BuffSkill(12,"Stone Skin", "Increase Def over 3 turns", 0, 3, 2, 0, false, BuffType.Defense));

    //DebuffSkills int id, string name, string desc, int MinLevel, int turnsMax, int qty, int cost, bool isActivedOnce
    AllSkills.Add(new DebuffSkill(101, "Nasty Provocation", "Decrease Enemy Dodge", 0, 2, -4000, 0, true, BuffType.Dodge));
    AllSkills.Add(new DebuffSkill(102, "Take Down", "Decrease Enemy Defense", 0, 2, -4, 0, true, BuffType.Defense));

    //AttackSkills int id, string name, string desc, int MinLevel, int turnsMax,  int cost, int minDamage, int maxDamage, float modifier, StatsType playerStat
    AllSkills.Add(new AttackSkill(201, "Deep Strike", "A far more powerful strike", 0, 3, 0, 10, 20, 1.3, StatsType.Str));

    //DefenseSkills int id, string name, string desc, int MinLevel, int turnsMax, int cost, int minValue, int maxValuew, float modifier, StatsType playerStat
    AllSkills.Add(new DefenseSkill(301, "First-Aid", "Simple regeneration", 0, 1, 0, 5, 15, 1.5, StatsType.Inte));

    //SlimeSkills 
    SlimeSkillList.Add(new AttackSkill(1001, "Volatility", "Explodes On the enemy", 0, 2, 0, 1, 15, 1.0, StatsType.Vig));
    SlimeSkillList.Add(new DefenseSkill(1002, "Increase Mass", "Generate more of it", 0, 5, 0, 7, 12, 1.0, StatsType.Inte));

    //SpiderSkills
    SpiderSkillList.Add(new DebuffSkill(1101, "Shoot Web", "Shoot a web, debilitating enemy movement by time", 0, 2, -3000, 0, false, BuffType.Dodge));
    SpiderSkillList.Add(new DebuffSkill(1102, "Poison Bite", "Poison the enemy", 0, 3, 3, 0, true, BuffType.Hp));

    //GolemSkills
    GolemSkillList.Add(new BuffSkill(1201, "Ancient Power", "Extracts old power to increase attack", 0, 5, 1, 0, false, BuffType.Attack));
    GolemSkillList.Add(new BuffSkill(1202, "Defensive Grid", "Increase its defense over time", 0, 5, 1, 0, false, BuffType.Defense));
  }

  public static void CreateMonsterSkillList(){
    ListPerMonster.Add(0, SlimeSkillList);
    ListPerMonster.Add(1, SpiderSkillList);
    ListPerMonster.Add(2, GolemSkillList);
  }
}