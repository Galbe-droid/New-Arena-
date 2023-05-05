using System;

class BuffSkill : PerTurnSkill{
  public BuffSkill(int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce, BuffType whereToApply)
  {
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Cost = cost;
    Cooldown = false;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = whereToApply;
  }

  public BuffSkill(BuffSkill buff){
    Id = buff.Id;
    Name = buff.Name;
    Desc = buff.Desc;
    TurnMax = buff.TurnMax;
    Turns = 0;
    Qty = buff.Qty;
    IsActivedOnce = buff.IsActivedOnce;
    Cost = buff.Cost;
    Cooldown = false;
    CooldownTurns = 0;
    Tracked = 0;
    IsUsed = false;
    WhereToApply = buff.WhereToApply;
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
           "Increases: " + whereToAct + " | " + 
           "Qty: " + this.Qty + " | " +
           "Cooldown: " + (this.TurnMax + 1);
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Buff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply}";
  }
}

