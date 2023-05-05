//An abstract skill system all skill type will use this one 
abstract class SkillBase
{
  public int Id{get; set;}
  public string Name {get; set;}
  public string Desc {get; set;}
  public int TurnMax {get; set;}
  public int Turns {get; set;}
  public int Cost {get; set;}
  public bool Cooldown {get; set;}
  public int CooldownTurns {get; set;}

  public abstract int Applying();

  public abstract string SkillDescription();

  public string SkillOnCooldown(){
    if((this.TurnMax - this.CooldownTurns) == 0){
      return $"Name: {this.Name} || Charged on the next turn...";
    }else{
      return $"Name: {this.Name} || On Cooldown for more {(this.TurnMax + 1) - this.CooldownTurns} turns...";
    }    
  }

  public void CooldownControl(){
    this.Cooldown = !this.Cooldown;
    this.CooldownTurns = 0;
  }

  public void CooldownCount(){
    this.CooldownTurns++;
  }
}