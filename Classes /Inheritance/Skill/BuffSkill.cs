//Under Construction
class BuffSkill : SkillBase
{
  //Stat Increase
  public int Qty {get; set;}
  //Stat get Increased by turn
  public bool Repeated {get; set;}
  //Keeps track of the buff so it can be safely removed 
  public int Tracked{get;set;}

  public BuffSkill(int id, string name, string desc, int turnsMax, int qty, bool isActivedOnce)
  {
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Repeated = true;
    Tracked = 0;
  }

  public override int Applying(ref int stat){    
    if(this.IsActivedOnce && this.Repeated){
      this.Repeated = false;      
      this.Tracked += this.Qty;
      return stat += this.Qty;
    }
    else if(!this.IsActivedOnce && this.Repeated){
      this.Tracked += this.Qty;
      return stat += this.Qty;
    }
    else{
      return stat;
    }
  }

  public int Removal(ref int stat){
    return stat -= this.Tracked;
  }
}

