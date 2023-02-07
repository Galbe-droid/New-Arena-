using System; 
//Buff and Debuff are similar in composition
//But using a different class I can separate then and place then for the right targets 
class DebuffSkill : BuffSkill{
  public DebuffSkill(int id, string name, string desc, int turnsMax, int qty, bool isActivedOnce, BuffType whereToApply){
    Id = id;
    Name = name;
    Desc = desc;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    IsActivedOnce = isActivedOnce;
    Initiated = false;
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
    Repeated = true;
    Tracked = 0;
    WhereToApply = debuff.WhereToApply;
  }
}