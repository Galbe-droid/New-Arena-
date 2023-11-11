using System; 

class DebuffSkill : PerTurnSkill{
  public DebuffSkill(int id, string name, string desc, int minLevel, int turnsMax, int qty, int xpCost, int mpCost, bool isActivedOnce, string whereToApplyString){
    Id = id;
    Name = name;
    Desc = desc;
    MinLevel = minLevel;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    XpCost = xpCost;
    MpCost = mpCost;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApplyString = "";
    WhereToApply = ApplyingType(WhereToApplyString);
  }

  public DebuffSkill(DebuffSkill debuff){
    Id = debuff.Id;
    Name = debuff.Name;
    Desc = debuff.Desc;
    MinLevel = debuff.MinLevel;
    TurnMax = debuff.TurnMax;
    Turns = 0;
    Qty = debuff.Qty;
    IsActivedOnce = debuff.IsActivedOnce;
    XpCost = debuff.XpCost;
    MpCost = debuff.MpCost;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = debuff.WhereToApply;
  }

  public DebuffSkill()
  {
      
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
           "Cost: " + this.XpCost + "xp | " + 
           "Turns Durantion: " + this.TurnMax + " | " +
           "Decreases: " + whereToAct + " | " + 
           "Qty: " + this.Qty + " | " +
           "Mp: " + this.MpCost + " Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Debuff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply} \\ Mp: {this.MpCost}";
  }
}