using System;
using System.Collections.Generic;
//Character uses abstraction Creature 
//Under modifications, passing some stats to an Abstract class
//Base Stats, Death
//Still no: Skills, classes(Maybe)
class Character : Creature
{
  public int Id {get; set;}
  
  public int Xp {get; set;}

  public List<SkillBase> CapableOfLearn = new List<SkillBase>();

  public Character(int id, string name, int str, int inte, int agi, int vig)
  {
    Id = id;
    Name = name;

    Xp = 0;
    Level = 1;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str;

    Health = 10 + (vig * 10);
    Mana = 5 + (inte * 5);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0 * 500;
    ModAttack = 0;

    Dead = false;
  }

  public void FillAvaliableSkill(){
    foreach(BuffSkill s in SkillList.BuffSkillList){
      if(!this.SkillTrained.Exists(x => x.Id == s.Id)){
        this.CapableOfLearn.Add(s);
      }
    }

    foreach(DebuffSkill s in SkillList.DebuffSkillList){
      if(!this.SkillTrained.Exists(x => x.Id == s.Id)){
        this.CapableOfLearn.Add(s);
      }
    }
  }
  
}