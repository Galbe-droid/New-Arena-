//Under Construction
class BuffSkill : SkillBase
{
  public int Mod {get; set;}
  public int Qty {get; set;}

  public BuffSkill(int id, string name, int turnsMax, int mod, int qty, bool activate)
  {
    Id = id;
    Name = name;
    TurnMax = turnsMax;
    Turns = 0;
    Qty = qty;
    Mod = mod + Qty;
    Activate = activate;
  }
}

