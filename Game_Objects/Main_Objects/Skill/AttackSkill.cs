using System;

class AttackSkill : OneShotSkill{
  public AttackSkill(int id, string name, string desc, int minLevel, int turnsMax, int cost, int minDamage, int maxDamage, double modifier, StatsType playerStat){
    Id = id;
    Name = name;
    Desc = desc;
    MinLevel = minLevel;
    TurnMax = turnsMax;
    Turns = 0;
    Cost = cost;
    MinValue = minDamage;
    MaxValue = maxDamage;
    Modifier = modifier;
    PlayerStat = playerStat;
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
    Cost = attack.Cost;
    MinValue = attack.MinValue;
    MaxValue = attack.MaxValue;
    Modifier = attack.Modifier;
    PlayerStat = attack.PlayerStat;
    Cooldown = false;
    CooldownTurns = 0;
  }  

  public override string ToString(){
    string mainStat; 

    if(this.PlayerStat == StatsType.Str){
      mainStat = "Str"; 
    }
    else if(this.PlayerStat == StatsType.Agi){
      mainStat = "Agi"; 
    }
    else if(this.PlayerStat == StatsType.Vig){
      mainStat = "Vit"; 
    }
    else{
      mainStat = "Int"; 
    }
    
    return "Name: " + this.Name + " | " +
           "Cost: " + this.Cost + "xp | " + 
           "Damage: (" + this.MinValue + " ~ " + this.MaxValue + ") + " + String.Format("{0:N1}", this.Modifier) + " * " + mainStat + " | " +
           "Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Attack \\ Description: {this.Desc} \\ Damage: ({this.MinValue} ~ {this.MaxValue}) * {this.Modifier}({this.PlayerStat})"; 
  }
}