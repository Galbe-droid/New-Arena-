using System.Collections.Generic;
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
  public bool isDefensive{get; set;}

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

  //Use on the beggining of combat for monsters, it loads a pre base skill 
  //For players this loads after character creation 
  public void Initialization(){
    foreach(BuffSkill b in SkillList.BuffSkillList){
      if(b.Id == 0){
        SkillTrained.Add(b);
      }
    }
  }
  
}