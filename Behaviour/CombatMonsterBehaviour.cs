using System;

//Monster Behaviour in combate 
//Still a lot of work
class CombatMonsterBehaviour
{
  //Method receive Player defense, Player Dodge chance, Monster damage and monster type
  public static void MonsterChoice(ref Character c, ref Monster m )
  {
    //Depending of the monster type it will be more inclined to use certain actions 
    Random rand = new Random();
    int choice = rand.Next(0,101);
    int [] monsterType = MonsterProbability(m.Type);

    if((choice >= monsterType[0] && choice <= monsterType[1])){
      c.Damage += CombatBehaviour.AttackOption(m, c);
    }
    else{
      if(!m.BuffActive.Exists(x => x.Id == 0)){
        CombatBehaviour.DefensiveChoice(m);
      }
      //Prevent Monsters from Repeat Defende Every Time 
      else if(m.BuffActive.Exists(x => x.Id == 0) && m.BuffActive.Find(x => x.Id == 0).Turns > 2){
        CombatBehaviour.DefensiveChoice(m);
      }
      else{
        c.Damage += CombatBehaviour.AttackOption(m, c);
      }
    } 
  }

  public static int[] MonsterProbability(Types t){
    //values for the probability of monster each action 
    if(t == Types.Balance){
      int[] values = {0,75};
      return values;
    }else if(t == Types.Balance){
      int[] values = {0,50};
      return values;
    }else if(t == Types.Balance){
      int[] values = {0,25};
      return values;
    }

    return null;
  }
}