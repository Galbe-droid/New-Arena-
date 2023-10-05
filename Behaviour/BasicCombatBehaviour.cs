using System;
using System.Collections.Generic;
using System.Linq;

//Controls player and monster Basic combat options, here is where the commands
class BasicCombatBehaviour
{
  //Basic Attack option, it receives a attacker and a defender
  public static int AttackOption<T>(T attacker, T defender) where T : Creature
  {
    //Basic attacks generate from 0 to +20 for the basic damage and defense
    Random rand = new Random();
    int _totalAttack = rand.Next(0,21) + attacker.TotalAttack();
    int _totalDefense = rand.Next(0,21) + defender.TotalDefense();

    //Dodge uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500
    //Accuracy uses the same mechanic, if accuracy is higher then it hits 
    int _accuracy = rand.Next(0,100001);

    int _monsterDodge = defender.TotalDodge();

    if(_accuracy < _monsterDodge)
    {
      Console.WriteLine($"{defender.Name} Dodged");
    }
    else
    {
      //If Defense is equal of greater then attack then this keep informs the player 
      if(_totalDefense >= _totalAttack)
      {
        Console.WriteLine($"{defender.Name} Defended");
      }
      else
      {
        _totalAttack -= _totalDefense;
        //The method return the damage that the attacker made on the defender 
        Console.WriteLine($"{defender.Name} Damage !!");
        Console.WriteLine($"Damage: -{_totalAttack}");
        return _totalAttack;
      }
    }
    return 0;
  }

  //Executes a basic Defense Movement, it increases the Defense for 2 turns
  public static void DefensiveOption<T>(T creature) where T : Creature{
    Console.WriteLine(creature.Name + " is assuming a Defensive stance");
    //It searches if the skill is already activated, if it is then it time is reset
    if(!creature.BuffActive.Exists(skill => skill.Id == 0)){
      BuffSkill _defense = (BuffSkill)creature.SkillTrained.Find(skill => skill.Id == 0);
      creature.BuffActive.Add(new BuffSkill(_defense));
    }else{
      creature.BuffActive.Find(skill => skill.Id == 0).Turns = 0;
    }  
  }
}