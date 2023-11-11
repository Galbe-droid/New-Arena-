using System;

class BuffSkill : PerTurnSkill{
  public BuffSkill(int id, string name, string desc, int minLevel, int turnsMax, int qty, int xpCost, int mpCost, bool isActivedOnce, string whereToApplyString)
  {
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
    Cooldown = false;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApplyString = "";
    WhereToApply = ApplyingType(WhereToApplyString);
  }

  public BuffSkill(BuffSkill buff){
    Id = buff.Id;
    Name = buff.Name;
    Desc = buff.Desc;
    MinLevel = buff.MinLevel;
    TurnMax = buff.TurnMax;
    Turns = 0;
    Qty = buff.Qty;
    IsActivedOnce = buff.IsActivedOnce;
    XpCost = buff.XpCost;
    MpCost = buff.MpCost;
    Cooldown = false;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = buff.WhereToApply;
  }

  public BuffSkill()
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
           "Increases: " + whereToAct + " | " + 
           "Qty: " + this.Qty + " | " +
           "Mp: " + this.MpCost + " Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Buff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply} \\ Mp: {this.MpCost}";
  }
}

