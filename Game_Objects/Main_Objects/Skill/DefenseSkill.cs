using System;

class DefenseSkill : OneShotSkill{
    public DefenseSkill(int id, string name, string desc, int minLevel, int turnsMax, int cost, int minValue, int maxValue, double modifier, StatsType playerStat){
    Id = id;
    Name = name;
    Desc = desc;
    MinLevel = minLevel;
    TurnMax = turnsMax;
    Turns = 0;
    Cost = cost;
    MinValue = minValue;
    MaxValue = maxValue;
    Modifier = modifier;
    PlayerStat = playerStat;
    Cooldown = false;
    CooldownTurns = 0;
  }

  public DefenseSkill(DefenseSkill defense){
    Id = defense.Id;
    Name = defense.Name;
    Desc = defense.Desc;
    MinLevel = defense.MinLevel;
    TurnMax = defense.TurnMax;
    Turns = 0; 
    Cost = defense.Cost;
    MinValue = defense.MinValue;
    MaxValue = defense.MaxValue;
    Modifier = defense.Modifier;
    PlayerStat = defense.PlayerStat;
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
           "Recovery: (" + this.MinValue + " ~ " + this.MaxValue + ") + " + String.Format("{0:N1}", this.Modifier) + " * " + mainStat + " | " +
           "Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Attack \\ Description: {this.Desc} \\ Healing: ({this.MinValue} ~ {this.MaxValue}) * {this.Modifier}({this.PlayerStat})"; 
  }
}