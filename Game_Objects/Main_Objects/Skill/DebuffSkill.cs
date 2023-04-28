using System; 
//Buff and Debuff are similar in composition
//But using a different class I can separate then and place then for the right targets 
class DebuffSkill : BuffSkill{
  public DebuffSkill(int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce, BuffType whereToApply){
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Initiated = false;
    Cost = cost;
    CooldownTurns = 0;
    Repeated = true;
    Tracked = 0;
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
    Initiated = false;
    Cost = debuff.Cost;
    CooldownTurns = 0;
    Repeated = true;
    Tracked = 0;
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
           "Qty: " + this.Qty;
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Debuff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply}";
  }

   public override string SkillOnCooldown(){
    return $"Name: {this.Name} || On Cooldown for more {this.TurnMax - this.CooldownTurns} turns...";
  }
}