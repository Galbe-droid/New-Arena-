using System;

class BuffSkill : SkillBase
{
  //Stat Increase
  public int Qty {get; set;}
  //Stat get Increased by turn
  public bool Repeated {get; set;}
  //Keeps track of the buff so it can be safely removed and added in case the buff has a multiple stages 
  public int Tracked{get;set;}
  //Where to put the buff 
  public BuffType WhereToApply {get; set;}

  public BuffSkill(){}

  public BuffSkill(int id, string name, string desc, int turnsMax, int qty, int cost, bool isActivedOnce, BuffType whereToApply)
  {
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Initiated = false;
    Cost = cost;
    Cooldown = false;
    CooldownTurns = 0;
    Repeated = true;
    Tracked = 0;
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
    Initiated = false;
    Cost = buff.Cost;
    Cooldown = false;
    CooldownTurns = 0;
    Repeated = true;
    Tracked = 0;
    WhereToApply = buff.WhereToApply;
  }

  public override int Applying(){    
    if(this.IsActivedOnce && this.Repeated){
      this.Repeated = false;      
      this.Tracked += this.Qty;
      return this.Tracked;
    }
    else if(!this.IsActivedOnce && this.Repeated){
      this.Tracked += this.Qty;
      return this.Tracked;
    }
    else{
      return 0;
    }
  }

  public int Removal(){
    return this.Tracked;
  }

  public override void CooldownInitiation(){
    this.Cooldown = true;
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
           "Qty: " + this.Qty;
  }

  public override string SkillDescription(){
    return $"Name: {this.Name} || Type:Buff \\ Description: {this.Desc} \\ Affects: {this.WhereToApply}";
  }

  public override string SkillOnCooldown(){
    return $"Name: {this.Name} || On Cooldown for more {this.TurnMax - this.CooldownTurns} turns...";
  }
}

