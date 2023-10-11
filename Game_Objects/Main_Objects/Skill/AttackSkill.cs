using System;

class AttackSkill : OneShotSkill{
  public AttackSkill(int id, string name, string desc, int minLevel, int turnsMax, int xpCost, int minDamage, int maxDamage, double modifier, string playerStat){
    Id = id;
    Name = name;
    Desc = desc;
    MinLevel = minLevel;
    TurnMax = turnsMax;
    Turns = 0;
    XpCost = xpCost;
    MinValue = minDamage;
    MaxValue = maxDamage;
    Modifier = modifier;
    StatString = playerStat;
    Stat = ApplyingType(StatString);
    Cooldown = false;
    CooldownTurns = 0;
  }

  public AttackSkill(AttackSkill attack){
    Id = attack.Id;
    Name = attack.Name;
    Desc = attack.Desc;
    MinLevel = attack.MinLevel;
    TurnMax = attack.TurnMax;
    Turns = 0; 
    XpCost = attack.XpCost;
    MinValue = attack.MinValue;
    MaxValue = attack.MaxValue;
    Modifier = attack.Modifier;
    Stat = attack.Stat;
    Cooldown = false;
    CooldownTurns = 0;
  }  

  public AttackSkill()
  {
      
  }

  public override string ToString(){
    string mainStat; 

    if(this.Stat == StatsType.Str){
      mainStat = "Str"; 
    }
    else if(this.Stat == StatsType.Agi){
      mainStat = "Agi"; 
    }
    else if(this.Stat == StatsType.Vig){
      mainStat = "Vit"; 
    }
    else{
      mainStat = "Int"; 
    }
    
    return "Name: " + this.Name + " | " +
           "Cost: " + this.XpCost + "xp | " + 
           "Damage: (" + this.MinValue + " ~ " + this.MaxValue + ") + " + String.Format("{0:N1}", this.Modifier) + " * " + mainStat + " | " +
           "Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Attack \\ Description: {this.Desc} \\ Damage: ({this.MinValue} ~ {this.MaxValue}) * {this.Modifier}({this.Stat})"; 
  }
}