//An abstract skill system all skill type will use this one 
abstract class SkillBase
{
  public int Id{get; set;}
  public string Name {get; set;}
  public string Desc {get; set;}
  public int TurnMax {get; set;}
  public int Turns {get; set;}
  public bool IsActivedOnce {get; set;}
  public bool Initiated {get; set;}
  public int Cost {get; set;}
  public bool Cooldown {get; set;}
  public int CooldownTurns {get; set;}

  public abstract int Applying();

  public abstract void CooldownInitiation();

  public abstract string SkillDescription();

  public abstract string SkillOnCooldown();
}