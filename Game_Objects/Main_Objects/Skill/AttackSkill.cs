using System;

class AttackSkill : SkillBase{

  public int MinDamage {get;set;}

  public int MaxDamage {get;set;}

  public double Modifier {get;set;}

  public StatsType PlayerStat {get;set;}

  public bool Cooldown {get;set;}
  
  public AttackSkill(){}

  public AttackSkill(int id, string name, string desc, int turnsMax, int cost, int minDamage, int maxDamage, double modifier, StatsType playerStat)
  {
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Cost = cost;
    MinDamage = minDamage;
    MaxDamage = maxDamage;
    Modifier = modifier;
    PlayerStat = playerStat;
    Cooldown = false;
  }

  public AttackSkill(AttackSkill attack)
  {
    Id = attack.Id;
    Name = attack.Name;
    Desc = attack.Desc;
    TurnMax = attack.TurnMax;
    Turns = 0; 
    Cost = attack.Cost;
    MinDamage = attack.MinDamage;
    MaxDamage = attack.MaxDamage;
    Modifier = attack.Modifier;
    PlayerStat = attack.PlayerStat;
    Cooldown = false;
  }

  public int ApplyModifier(int stat){
    return (int)Math.Truncate(stat * this.Modifier);
  }

  public override int Applying(){
    if(this.Cooldown && this.Turns == this.TurnMax){
      this.Cooldown = false;
    }
    else{
      this.Turns ++;
    }

    return 0;
  }  

  public override string ToString(){
    string mainStat; 

    if(this.PlayerStat == StatsType.Str){
      mainStat = "Str"; 
    }
    else if(this.PlayerStat == StatsType.Agi){
      mainStat = "Agi"; 
    }
    else if(this.PlayerStat == StatsType.Vit){
      mainStat = "Vit"; 
    }
    else{
      mainStat = "Int"; 
    }
    
    return "Name: " + this.Name + " | " +
           "Cost: " + this.Cost + "xp | " + 
           "Damage: (" + this.MinDamage + " ~ " + this.MaxDamage + ") + " + String.Format("{0:N1}", this.Modifier) + " * " + mainStat + " | " +
           "Cooldown: " + this.TurnMax;
    }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Attack \\ Description: {this.Desc} \\ Damage: ({this.MinDamage} ~ {this.MaxDamage}) * {this.Modifier}({this.PlayerStat})"; 
  }
}