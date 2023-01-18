using System;

//Monster Behaviour in combate 
//Still a lot of work
class CombatMonsterBehaviour
{
  //Method receive Player defense, Player Dodge chance, Monster damage and monster type
  public static bool MonsterChoice(int CharDefense, int ChaDodge, int MonsterDamage, Types MonsterType)
  {
    //Depending of the monster type it will be more inclined to use certain actions 
    if(MonsterType == Types.Offensive)
    {
      return false;
    }
    else if(MonsterType == Types.Defensive)
    {
      return false;
    }
    else if(MonsterType == Types.Balance)
    {
      return false;
    }
    //Failsafe
    else
    {
      return false;
    }
  }
}