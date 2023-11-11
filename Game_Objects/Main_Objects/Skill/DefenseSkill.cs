using System;

class DefenseSkill : OneShotSkill{
    public DefenseSkill(int id, string name, string desc, int minLevel, int turnsMax, int xpCost, int mpCost, int minValue, int maxValue, double modifier, string playerStat){
    Id = id;
    Name = name;
    Desc = desc;
    MinLevel = minLevel;
    TurnMax = turnsMax;
    Turns = 0;
    XpCost = xpCost;
    MpCost = mpCost;
    MinValue = minValue;
    MaxValue = maxValue;
    Modifier = modifier;
    StatString = playerStat;
    Stat = ApplyingType(StatString);
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
    XpCost = defense.XpCost;
    MpCost = defense.MpCost;
    MinValue = defense.MinValue;
    MaxValue = defense.MaxValue;
    Modifier = defense.Modifier;
    Stat = defense.Stat;
    Cooldown = false;
    CooldownTurns = 0;
  }  

  public DefenseSkill()
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
           "Recovery: (" + this.MinValue + " ~ " + this.MaxValue + ") + " + String.Format("{0:N1}", this.Modifier) + " * " + mainStat + " | " +
           "Mp: " + this.MpCost + " Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Defense \\ Description: {this.Desc} \\ Healing: ({this.MinValue} ~ {this.MaxValue}) * {this.Modifier}({this.Stat}) \\ Mp: {this.MpCost}"; 
  }
}