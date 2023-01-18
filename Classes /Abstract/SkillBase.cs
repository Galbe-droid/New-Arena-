//An abstract skill system all skill type will use this one 
abstract class SkillBase
{
  public int Id{get; set;}
  public string Name {get; set;}
  public int TurnMax {get; set;}
  public int Turns {get; set;}
  public bool Activate {get; set;}
}