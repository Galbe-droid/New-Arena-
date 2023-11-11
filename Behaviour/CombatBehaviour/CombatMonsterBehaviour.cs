using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;

//Monster Behaviour in combate 
//Still a lot of work
class CombatMonsterBehaviour
{
  //Method receive Player defense, Player Dodge chance, Monster damage and monster type
  public static void MonsterChoice(Character c, Monster m )
  {
    //Depending of the monster type it will be more inclined to use certain actions
    int choice = ManagerRandom.GetThreadRandom().Next(0,101);
    List<int> monsterTypeChance = TypeProbability(m.Type, m.SubType);

    if(choice <= monsterTypeChance[0]){
      int choiceOfAttack = ManagerRandom.GetThreadRandom().Next(0,101);

      if(choiceOfAttack <= monsterTypeChance[1])
      {
        c.Damage += BasicCombatBehaviour.AttackOption<Creature>(m, c);
      }
      else
      {
        List<SkillBase> possibleAttacksSkills = m.SkillTrained.Where(s => s.GetType() == typeof(AttackSkill))
                                                              .Where(s => s.Cooldown == false)
                                                              .Where(s => m.ManaCheck(s) == true).ToList();
        
        if(possibleAttacksSkills.Count != 0)
        {
          int skillDecision = ManagerRandom.GetThreadRandom().Next(possibleAttacksSkills.Count);
          SkillUse.AttackSkillUse<Creature>(m, c, (AttackSkill)possibleAttacksSkills[skillDecision]);
          m.ManaSpending(possibleAttacksSkills[skillDecision]);
        }
        else
        {
          c.Damage += BasicCombatBehaviour.AttackOption<Creature>(m, c);
        }      
      }      
    }
    else
    {
      int choiceOfDefense = ManagerRandom.GetThreadRandom().Next(0,101);
      if(choiceOfDefense <= monsterTypeChance[2])
      {
        ExecuteBasicDefense(c, m);
      }
      else
      {
        int choiceOfSkill = ManagerRandom.GetThreadRandom().Next(0,101);

        List<SkillBase> possibleDefenseSkills = m.SkillTrained.Where(s => s.GetType() == typeof(DefenseSkill))
                                                              .Where(s => s.Cooldown == false)
                                                              .Where(s => m.ManaCheck(s) == true).ToList();

        List<SkillBase> possibleDebuffSkills = m.SkillTrained.Where(s => s.GetType() == typeof(DebuffSkill))
                                                              .Where(s => s.Cooldown == false)
                                                              .Where(s => m.ManaCheck(s) == true).ToList();

        List<SkillBase> possibleBuffSkills = m.SkillTrained.Where(s => s.GetType() == typeof(BuffSkill))
                                                              .Where(s => s.Cooldown == false)
                                                              .Where(s => m.ManaCheck(s) == true).ToList();

        if(possibleDefenseSkills.Count != 0 || possibleDebuffSkills.Count != 0 || possibleBuffSkills.Count != 0)
        {
          if(choiceOfSkill >= 0 && choiceOfSkill >= monsterTypeChance[3])
          {
            if(possibleDefenseSkills.Count == 0){
              choiceOfSkill = monsterTypeChance[4];
            }
            else
            {
              int skillDecision = ManagerRandom.GetThreadRandom().Next(possibleDefenseSkills.Count);
              SkillUse.DefenseSkillUse<Monster>(m, (DefenseSkill)possibleDefenseSkills[skillDecision]);   
              m.ManaSpending(possibleDefenseSkills[skillDecision]);         
            }          
          }
          else if(choiceOfSkill >= monsterTypeChance[4] && choiceOfSkill >= monsterTypeChance[5])
          {
            if(possibleDebuffSkills.Count == 0){
              choiceOfSkill = monsterTypeChance[5] + 1;
            }
            else
            {
              int skillDecision = ManagerRandom.GetThreadRandom().Next(possibleDebuffSkills.Count);
              SkillUse.DebuffSkillUse<Creature>(c, m, (DebuffSkill)possibleDebuffSkills[skillDecision]);     
              m.ManaSpending(possibleDebuffSkills[skillDecision]);          
            }    
          }
          else
          {
            if(possibleBuffSkills.Count == 0){
              ExecuteBasicDefense(c, m);
            }
            else
            {
              int skillDecision = ManagerRandom.GetThreadRandom().Next(possibleBuffSkills.Count);
              SkillUse.BuffSkillUse<Monster>(m, (BuffSkill)possibleBuffSkills[skillDecision]);   
              m.ManaSpending(possibleBuffSkills[skillDecision]);             
            }
          }
        }
        else
        {
          ExecuteBasicDefense(c, m);
        }
      }      
    } 
  }

  public static void ExecuteBasicDefense(Character c, Monster m){
    if(!m.BuffActive.Exists(x => x.Id == 0)){
      BasicCombatBehaviour.DefensiveOption(m);
    }
    //Prevent Monsters from Repeat Defende Every Time 
    else if(m.BuffActive.Exists(x => x.Id == 0) && m.BuffActive.Find(x => x.Id == 0).Turns > 2){
      BasicCombatBehaviour.DefensiveOption(m);
    }
    else{
      c.Damage += BasicCombatBehaviour.AttackOption<Creature>(m, c);
    }
  }

  public static List<int> TypeProbability(Types t, SubTypes[] s){
    //values for the probability of monster each action 
    List<int> values = new();
    //values[0]
    if(t == Types.Offensive){
      values.Add(75);
    }else if(t == Types.Balance){
      values.Add(50);
    }else if(t == Types.Defensive){
      values.Add(40);
    }

    //values[1]
    if(s[0] == SubTypes.Brute){
      values.Add(75);
    }
    else{
      values.Add(25);
    }

    if(s[1] == SubTypes.Support){
      //value[2]
      //If it will use skill
      values.Add(50);
      //If uses skill theses values are for Defese skill (min max) DebuffSkill (min max) and BuffSkill(min max) 
      //value[3 ... 5]
      values.AddRange(new int[3]{40,41,60});
    }
    else{
      //value[2]
      values.Add(25);
      //value[3 ... 5]
      values.AddRange(new int[3]{60,61,80});
    }

    return values;
  }
}