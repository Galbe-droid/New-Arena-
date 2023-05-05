using System;
using System.Collections.Generic;
using System.Linq;

//Controls player and monster Attacks options, here is where the commands
class CombatBehaviour
{
  //Basic Attack option, it receives a attacker and a defender
  public static int AttackOption(Creature attacker, Creature defender)
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
  public static void DefensiveChoice(Creature creature){
    Console.WriteLine(creature.Name + " is assuming a Defensive stance");
    //It searches if the skill is already activated, if it is then it time is reset
    if(!creature.BuffActive.Exists(skill => skill.Id == 0)){
      BuffSkill _defense = (BuffSkill)creature.SkillTrained.Find(skill => skill.Id == 0);
      creature.BuffActive.Add(new BuffSkill(_defense));
    }else{
      creature.BuffActive.Find(skill => skill.Id == 0).Turns = 0;
    }  
  }

  public static int SkillChoice(Character c, Monster m, out int skillChoice){
    int choice = 0;
    int page = 1;
    bool _skillInCooldown = false;
    //Receive a copy of the trained skills of the caracter 
    List<SkillBase> skillList = new List<SkillBase>(c.SkillTrained);
    //Remove "Defensive Position" from the list 
    skillList.Remove(skillList.Find(s => s.Id == 0));
    //This int needs to be initiated after everything, it controls the 3 skills per page and need to be initiated after the list but before the pageLimite
    int skillCount = skillList.Count;
    //Create pages in case the skill list has more then 3 skills, excluding "Defensive Position"
    decimal pageLimit = (skillList.Count < 3) ? 1 : Math.Ceiling(Convert.ToDecimal(skillCount)/3);
    
    Console.WriteLine(pageLimit);
    Console.WriteLine((skillCount/3));
    
    do{
      Console.Clear();
      //Reinstante the screen so player can chance pages with flowing the screen 
      CombatScreen.Stats(c, m);
      //Create a page for each 3 skills
      skillCount = (skillList.Count > 3 + ((page - 1) * 3)) ? 3 : skillCount = skillList.Count - (page - 1) * 3;

      //Loop for display the image 
      Console.WriteLine($"=================Page {page}/{pageLimit} ====================");
      for(int i = 0; i < skillCount; i ++){
        int currentPage = (page - 1) * 3;
        currentPage += i;
        if(!skillList.ElementAt(currentPage).Cooldown){
          Console.WriteLine($"{i + 1} - {skillList.ElementAt(currentPage).SkillDescription()}");
          Console.WriteLine("======================================");   
        }
        else{
          Console.ForegroundColor = ConsoleColor.DarkGray;
          if(skillList.ElementAt(currentPage).Cooldown && (c.BuffActive.Exists(s => s.Id == skillList.ElementAt(currentPage).Id) || m.DebuffActive.Exists(s => s.Id == skillList.ElementAt(currentPage).Id))){
            Console.WriteLine($"{i + 1} - {skillList.ElementAt(currentPage).Name} currently activated...");
          }else{
            Console.WriteLine($"{i + 1} - {skillList.ElementAt(currentPage).SkillOnCooldown()}");
          }          
          Console.ResetColor();
          Console.WriteLine("======================================");   
        }
      }           
      Console.WriteLine();  
      //Loop for changing the page in case it has more then 3 skills 
      if(pageLimit > 1){
        choice = InputCheck.LimitCheck("Choose Skill by number (0 to go back) / 4 - last page / 5 - next page", 5);
        if (choice == 4 && page > 1){
          page -= 1;
        }
        else if (choice == 5 && page < pageLimit){
          page += 1; 
        }
        else if(choice == 4 && page == 1){
          page = Convert.ToInt32(pageLimit);
        }
        else if(choice == 5 && page == pageLimit){
          page = 1;
        }
        else{
          //multiplay the choice with the page getting the correct position +1
          choice *= page;
          //Corrects the possition 
          choice -= 1;
          //Check if skill is on cooldown and prevent using it 
          if(skillList.ElementAt(choice).Cooldown){
            _skillInCooldown = true;
          }
          else{
            _skillInCooldown = false;
          }
        }        
      }
      else{

        choice = InputCheck.ListLength("Choose Skill by number: ", skillCount);
        choice -= 1;
        
        if(choice == -1)
          break;

        if(skillList.ElementAt(choice).Cooldown){
          _skillInCooldown = true;
        }
        else{
          _skillInCooldown = false;
        }
      }
    }while((choice == 4 || choice == 5 || _skillInCooldown));   

    skillChoice = choice;
    //if the player selects 0 it will send a -1 indicating to the program that he wants to exit the skill screen
    //if the options are 1 to 3 (0 to 2) it will send to the else part of the code where the skill will be applyed 
    if(skillChoice == -1){
      return skillChoice;
    }
    else{
      UsingSkill(c, m, skillList.ElementAt(skillChoice));
      return skillChoice;
    }
  }

  //This method activate the skills and its effects 
  public static void UsingSkill(Character c, Monster m, SkillBase s){
    if(s.GetType() == typeof(BuffSkill)){
      //Initiate a propelly BuffSkill variable
      BuffSkill _buff = new((BuffSkill)s);

      //Initiate the buff on the player
      c.BuffActive.Add(_buff);
      //Turn on the cooldown on player skill list 
      c.SkillTrained.Find(skill => skill.Id == _buff.Id).CooldownControl();

      string defBuff = $"{c.Name} uses {_buff.Name}, feeling protected !";
      string dodgeBuff = $"{c.Name} uses {_buff.Name}, increasing speed !";
      string atkBuff = $"{c.Name} uses {_buff.Name}, gonna hurt!";
      UpdateConsole.MultipleTexts(defBuff, dodgeBuff, atkBuff, _buff.WhereToApply);  
    }
    else if(s.GetType() == typeof(DebuffSkill)){
      //Initiate a propelly DebuffSkill variable
      DebuffSkill _debuff = new((DebuffSkill)s);

      //Initiate the debuff on the monster
      m.DebuffActive.Add(_debuff);
      //Turn on the cooldown on player skill list 
      c.SkillTrained.Find(skill => skill.Id == _debuff.Id).CooldownControl();  

      string defDebuff = $"{c.Name} uses {_debuff.Name} on {m.Name} its look a little vulnearable now!";
      string dodgeDebuff = $"{c.Name} uses {_debuff.Name} on {m.Name} its look a slower now!";
      string atkDebuff = $"{c.Name} uses {_debuff.Name} on {m.Name} its look less aggressive now!";
      UpdateConsole.MultipleTexts(defDebuff, dodgeDebuff, atkDebuff, _debuff.WhereToApply);    
    }
    else if(s.GetType() == typeof(AttackSkill)){
      //Initiate a random for the min and max Damage
      Random rand = new Random();
      //Initiate a propelly AttackSkill varable
      AttackSkill _attack = new((AttackSkill)s);
      //Turn on the cooldown on player skill list 
      c.SkillTrained.Find(skill => skill.Id == _attack.Id).CooldownControl(); 
      int _damage = 0;
      //Monster Defense 
      int _protection = rand.Next(0,21);
      
      //Apply modifiers on the damage
      _damage += StatCheck(_attack.PlayerStat, _attack, c);

      _damage += _attack.Applying();
      //Monster Defese + Natural Defense 
      _damage -= (m.TotalDefense() + _protection);
      

      if(_damage > 0){
        Console.WriteLine($"{c.Name} uses {_attack.Name} on {m.Name} it causes {_damage} Damage !");
        m.Damage += _damage;

      }else{
        Console.WriteLine($"{c.Name} uses {_attack.Name} on {m.Name} and {m.Name} Blocks the incoming attack !");
      }            
    }
    else if(s.GetType() == typeof(DefenseSkill)){
      //Initiate a propelly Defense varable
      DefenseSkill _defense = new((DefenseSkill)s);
      int _healing = 0;

      //Turn on the cooldown on player skill list 
      c.SkillTrained.Find(skill => skill.Id == _defense.Id).CooldownControl(); 

      //Apply modifiers on the damage
      _healing += StatCheck(_defense.PlayerStat, _defense, c);

      _healing += _defense.Applying();

      //If _healing is higher then Damage the c.Damage is set to 0 else is calculated normally 
      c.Damage = _healing >= c.Damage ? 0 : c.Damage - _healing;

      Console.WriteLine($"{c.Name} uses {_defense.Name} healing {Convert.ToString(_healing)} of Damage");
    }
    else{
      Console.WriteLine("Error.");
    }
  }

  //Method for controlling the cooldown and turn passage 
  public static void PlayerCooldownCounting(Character c, Monster m){
    //Easy to navigate variables
    List<SkillBase> playerBuffs = c.BuffActive;
    List<SkillBase> monsterDebuffs = m.DebuffActive;

    foreach(SkillBase s in c.SkillTrained){
      //Check if the buff or debuff is still activated on enemy or player, if is them the cooldown wont count 
      bool _stillActive = false;
      //If this is true the cooldown start to count 
      bool _OnCooldown = false;        

      //In order to initiate a cooldown count and turn the Cooldown boolean to false, first they need to be active.
      //This condition is here because it is checked every turn 
      if(s.Cooldown == true){
        if(s.GetType() == typeof(BuffSkill)){
          _stillActive = playerBuffs.Exists(skill => skill.Id == s.Id) ? true : false;
        }else if(s.GetType() == typeof(DebuffSkill)){
          _stillActive = monsterDebuffs.Exists(skill => skill.Id == s.Id) ? true : false;
        }else{
          //Attack and Defense Skill don't have an active state so it always false 
          _stillActive = false;
        }

        _OnCooldown = s.CooldownTurns < s.TurnMax ? true : false;

        if(!_stillActive){
          if(_OnCooldown){
            s.CooldownCount();
          }
          else{
            s.CooldownControl();
          }
        }
      }      
    }
  }

  public static int StatCheck(StatsType stat, OneShotSkill skill, Character c){
    switch(stat){
      case StatsType.Str:
        return skill.ApplyModifier(c.Str);

      case StatsType.Inte:
        return skill.ApplyModifier(c.Int);

      case StatsType.Agi:
        return skill.ApplyModifier(c.Agi);

      case StatsType.Vig:
        return skill.ApplyModifier(c.Vig);

      default:
        Console.WriteLine("Error.");
        return 0;
    }
  }
}