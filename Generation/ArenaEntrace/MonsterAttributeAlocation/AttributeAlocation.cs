using System;
using System.Collections.Generic;

//Creating a monster for the player to choose from 
//This code places the points on the monster
//Depending of the monter type it will focus on some stats 
class AttributeAlocation
{
  //Generate a Balace Type Monster
  public static Monster PlacingAtributes(Monster monster)
  {
    Random random = new Random();
    //Quatity of points to be allocated 
    int atributes = monster.Level * 2;
    int[] atributeChance = MonsterProbability(monster.Type);

    while(atributes > 0)
    {
      int chance = random.Next(0, 100); 

      if(chance >= atributeChance[0] && chance <= atributeChance[1])
      {
        monster.Str++;
        atributes--;
      }

      if(chance >= atributeChance[2] && chance <= atributeChance[3])
      {
        monster.Int++;
        atributes--;
      }

      if(chance >= atributeChance[4] && chance <= atributeChance[5])
      {
        monster.Agi++;
        atributes--;
      }

      if(chance >= atributeChance[6] && chance <= atributeChance[7])
      {
        monster.Vig++;
        atributes--;
      }
    }
    return monster;
  }

  public static int[] MonsterProbability(Types t){
    //values for the probability of monster each action 
    if(t == Types.Balance){
      int[] values = {0,25,26,50,51,75,76,100};
      return values;
    }else if(t == Types.Offensive){
      int[] values = {0,60,61,70,71,85,86,100};
      return values;
    }else if(t == Types.Defensive){
      int[] values = {0,20,21,40,41,60,61,100};
      return values;
    }

    return null;
  }

  //Variation extra atributes 
  public static void AddExtraStats(ref MonsterVariation monster){
    monster.Str += monster.ExtraStr;
    monster.Int += monster.ExtraInt;
    monster.Agi += monster.ExtraAgi;
    monster.Vig += monster.ExtraVig; 
  }

  public static void AddSkills(ref Monster monster)
  {
    List<SkillBase> ListOfMonsterSkill = SkillList.ListPerMonster[monster.Id];

    foreach (SkillBase skill in ListOfMonsterSkill){
      if(monster.Level >= skill.MinLevel){
        monster.SkillTrained.Add(skill);
      }
    }
  }
}