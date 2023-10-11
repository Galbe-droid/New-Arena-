using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Loading;
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
  public List<SkillBase> BuffActive = new List<SkillBase>();
  public List<SkillBase> DebuffActive = new List<SkillBase>();

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
     return (this.Attack + this.ModAttack) <= 0 ? 0 : this.Attack + this.ModAttack;
  }

  public int TotalDefense(){
    return (this.Defense + this.ModDefense) <= 0 ? 0 : this.Defense + this.ModDefense;
  }

  public int TotalDodge(){
    int returnDodge = (this.Dodge + this.ModDodge) <= 0 ? 0 : this.Dodge + this.ModDodge;
    return returnDodge >= 90000 ? 90000 : returnDodge;
  }

  //It checks and apply/Removes the buffs and also where to apply and reduce 
  public void CheckForBuffsDebuffs(){
    _BuffCheck();
    _DebuffCheck();
  }

  private void _BuffCheck(){
    if(this.BuffActive.Count != 0){
      foreach(BuffSkill b in this.BuffActive.ToList()){    
        if(b.Turns <= b.TurnMax){
          if(b.WhereToApply == BuffType.Defense){
            this.ModDefense += b.Applying();
            b.Turns++;
          }
          else if(b.WhereToApply == BuffType.Dodge){ 
            this.ModDodge += b.Applying();
            b.Turns++;
          }
          else if(b.WhereToApply == BuffType.Attack){
            this.ModAttack += b.Applying();
            b.Turns++;
          }
          else if(b.WhereToApply == BuffType.Hp){
            if(this.Damage > 0){
              this.Damage = this.Damage - b.Qty <= 0 ? 0 : this.Damage - b.Applying();
              b.Turns = b.TurnMax + 1;
            }
            b.Turns = b.TurnMax + 1;
          }
          else if(b.WhereToApply == BuffType.Mp){
            if(this.ManaSpend > 0){
              this.ManaSpend = this.ManaSpend - b.Qty <= 0 ? 0 : this.ManaSpend - b.Applying();
              b.Turns = b.TurnMax + 1;
            }
            b.Turns = b.TurnMax + 1;
          }
        }
        else{
          if(b.WhereToApply == BuffType.Defense){
            this.ModDefense -= b.Removal();  
          }
          else if(b.WhereToApply == BuffType.Dodge){
            this.ModDodge -= b.Removal();
          }
          else if(b.WhereToApply == BuffType.Attack){
            this.ModAttack -=b.Removal();
          }
          BuffActive.Remove(b);   
        }
      }
    }
  }

  private void _DebuffCheck(){
    if(this.DebuffActive.Count != 0){
      foreach(DebuffSkill d in this.DebuffActive.ToList()){
        if(d.Turns <= d.TurnMax){
          if(d.WhereToApply == BuffType.Defense){            
            this.ModDefense += d.Applying();
            d.Turns++;
          }
          else if(d.WhereToApply == BuffType.Dodge){ 
            this.ModDodge += d.Applying();
            d.Turns++;
          }
          else if(d.WhereToApply == BuffType.Attack){
            this.ModAttack += d.Applying();
            d.Turns++;
          }
          else if(d.WhereToApply == BuffType.Hp){
            if(this.Damage < this.Health){
              this.Damage = this.Damage + d.Qty <= this.Health ? this.Health : this.Damage + d.Applying();
              d.Turns = d.TurnMax + 1;
            }
            d.Turns = d.TurnMax + 1;
          }
          else if(d.WhereToApply == BuffType.Mp){
            if(this.ManaSpend < this.Mana){
              this.ManaSpend = this.ManaSpend + d.Qty <= this.Mana ? this.Mana : this.ManaSpend + d.Applying();
              d.Turns = d.TurnMax + 1;
            }
            d.Turns = d.TurnMax + 1;
          }
        }
        else{
          if(d.WhereToApply == BuffType.Defense){
            this.ModDefense -= d.Removal();
          }
          else if(d.WhereToApply == BuffType.Dodge){
            this.ModDodge -= d.Removal();
          }
          else if(d.WhereToApply == BuffType.Attack){
            this.ModAttack -= d.Removal();
          }
          DebuffActive.Remove(d);   
        }
      }
    }
  }
    
  //Use on the beggining of combat for monsters, it loads a pre base skill 
  //For players this loads after character creation 
  public void Initialization(){
    foreach(SkillBase b in SkillsLoading.AllSkills){
      if(b.Id == 0){
        SkillTrained.Add(b);
      }
    }
  }  
}