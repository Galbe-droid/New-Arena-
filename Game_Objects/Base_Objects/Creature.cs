using System;
using System.Collections.Generic;
using System.Linq;
//Creature Abstraction to use with player and monster 
//This holds all information that any player or monster share
abstract class Creature{
  
  public string Name {get; set;}

  public int Level {get; set;}

  //Base Stats
  public int Str{get; set;}
  public int Int{get; set;}
  public int Agi{get; set;}
  public int Vig{get; set;}

  //Base Sub Stats
  public int Defense {get; set;}
  public int Dodge {get; set;}
  public int Attack {get; set;}

  public float Health{get; set;}
  public float Damage{get; set;}

  public float Mana{get; set;}
  public float ManaSpend{get; set;}

  //Initiative and modifies
  public int Initiative{get; set;}
  public int ModDefense{get; set;}
  public int ModDodge{get; set;}
  public int ModAttack{get; set;}

  //Checking
  public bool Dead{get; set;}

  //List for Skills
  public List<SkillBase> SkillTrained = new List<SkillBase>();
  public List<SkillBase> BuffAndDebuffActive = new List<SkillBase>();

  //Indicates Actual HP after damage
  public float ActualHp(){
    float maxHealth = this.Health;
    maxHealth -= this.Damage;
    if(maxHealth < 0){
      maxHealth = 0;
    }

    DeathCheck();
    
    return maxHealth;
  }

  //Indicates Actual MP after casting
  public float ActualMp(){
    float maxMana = this.Mana;
    maxMana -= this.ManaSpend;
    if(maxMana < 0){
      maxMana = 0;
    }

    return maxMana;
  }

  //Checks if the creature is dead
  public bool DeathCheck(){
    if(this.Health <= this.Damage){
      this.Dead = true;
     }

    return this.Dead;
  }

  //Informs the total stats (stats + ModStats)
  public int TotalAttack(){
     return this.Attack + this.ModAttack;
  }

  public int TotalDefense(){
    return this.Defense + this.ModDefense;
  }

  public int TotalDodge(){
    return this.Dodge + this.ModDodge;
  }

  //It checks and apply/Removes the buffs and also where to apply and reduce 
  public void CheckForBuffsDebuffs(){
    int stats; 
    if(this.BuffAndDebuffActive.Count != 0){
      foreach(BuffSkill b in this.BuffAndDebuffActive.ToList()){
        if(b.Turns <= b.TurnMax){
          if(b.WhereToApply == BuffType.Defense){
            stats = b.Applying();
            this.ModDefense += stats;
            b.Turns++;
          }
          else if(b.WhereToApply == BuffType.Dodge){
            b.Applying();  
            b.Turns++;
          }
          else if(b.WhereToApply == BuffType.Attack){
            b.Applying();
            b.Turns++;
          }
        }
        else{
          if(b.WhereToApply == BuffType.Defense){
            this.ModDefense -= b.Removal();
            BuffAndDebuffActive.Remove(b);   
          }
          else if(b.WhereToApply == BuffType.Dodge){
            b.Removal();
            BuffAndDebuffActive.Remove(b);   
          }
          else if(b.WhereToApply == BuffType.Attack){
            b.Removal();
            BuffAndDebuffActive.Remove(b);   
          }
        }
      }
    }
  }

  public void CheckForCooldowns(){
    foreach(AttackSkill s in SkillTrained){
      if(s.Cooldown == true){
        s.Applying();
      }
    }
  }
    
  //Use on the beggining of combat for monsters, it loads a pre base skill 
  //For players this loads after character creation 
  public void Initialization(){
    foreach(SkillBase b in SkillList.AllSkills){
      if(b.Id == 0){
        SkillTrained.Add(b);
      }
    }
  }  
}