using System; 

class DebuffSkill : PerTurnSkill{
  public DebuffSkill(int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce, BuffType whereToApply){
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Cost = cost;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = whereToApply;
  }

  public DebuffSkill(DebuffSkill debuff){
    Id = debuff.Id;
    Name = debuff.Name;
    Desc = debuff.Desc;
    TurnMax = debuff.TurnMax;
    Turns = 0;
    Qty = debuff.Qty;
    IsActivedOnce = debuff.IsActivedOnce;
    Cost = debuff.Cost;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = debuff.WhereToApply;
  }

  public override string ToString(){
    string whereToAct; 

    if(this.WhereToApply == BuffType.Defense){
      whereToAct = "Defense"; 
    }
    else if(this.WhereToApply == BuffType.Dodge){
      whereToAct = "Dodge"; 
    }
    else{
      whereToAct = "Attack"; 
    }
    
    return "Name: " + this.Name + " | " +
           "Cost: " + this.Cost + "xp | " + 
           "Turns Durantion: " + this.TurnMax + " | " +
           "Decreases: " + whereToAct + " | " + 
           "Qty: " + this.Qty + " | " +
           "Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Debuff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply}";
  }
}