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
    foreach(SkillBase s in SkillList.AllSkills){
      if(!this.CapableOfLearn.Exists(x => x.Id == s.Id) && !this.SkillTrained.Exists(x => x.Id == s.Id)){
        if(s.GetType() == typeof(BuffSkill)){
          this.CapableOfLearn.Add(new BuffSkill((BuffSkill)s));
        }
        else if(s.GetType() == typeof(DebuffSkill)){
          this.CapableOfLearn.Add(new DebuffSkill((DebuffSkill)s));
        }
        else if(s.GetType() == typeof(AttackSkill)){
          this.CapableOfLearn.Add(new AttackSkill((AttackSkill)s));
        }
        else if(s.GetType() == typeof(DefenseSkill)){
          this.CapableOfLearn.Add(new DefenseSkill((DefenseSkill)s));
        }
      }      
    }
  }

  public void ExcludingSkills(int id){
    this.CapableOfLearn.Remove(this.CapableOfLearn.Find(s => s.Id == id));
  }

  public override string ToString(){
    return $"Name: {this.Name} \n" +
           $"Total Xp: {this.Xp} || Total Gold: 0 \n" +
           $"Str: {this.Str} || Agi: {this.Agi} || Int: {this.Int} || Vit: {this.Vig} \n" +
           "=======================================\n" +
           "Skill Learned: \n";
  }

  public string ShowSkills(){
    string longString = "";
    foreach(SkillBase s in this.SkillTrained){
      if(s.Id != 0){
        longString += $"Name: {s.Name} || Type: {s.GetType()} \n";
        }
    }
    return longString;
  }
}