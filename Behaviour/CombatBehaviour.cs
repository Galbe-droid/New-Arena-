using System;
using System.Collections.Generic;
using System.Linq;

//Controls player Attacks options, here is where the commands of the player happen
class CombatBehaviour
{
  //Basic Attack option, it receives the player attack, monster defender and monster dodge chance
  public static int AttackOption(int Attacker, int Defender, int DefenderDodge)
  {
    //Basic attacks generate from '' to +20 for the basic damage and defense
    Random rand = new Random();
    int TotalAttack = rand.Next(0,21) + Attacker;
    int TotalDefense = rand.Next(0,21) + Defender;

    //Dodge Change uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500 if dodge change is less than Monster Dodge then the monster dodged the attack 
    int DodgeChance = rand.Next(0,100001);

    if(DodgeChance < DefenderDodge)
    {
      Console.WriteLine("Monster Dodged");
      return 0;
    }
    else
    {
      //If Defense is equal of greater then attack then this keep informs the player 
      if(TotalDefense >= TotalAttack)
      {
        Console.WriteLine("Monster Defended");
        return 0;
      }
      else
      {
        //The method return the damage that the player made on the monster 
        Console.WriteLine("Monster Damage !!");
        Console.WriteLine("Damage: -" + (TotalAttack - TotalDefense));
        return TotalAttack - TotalDefense;
      }
    }
  }

  //Executes a basic Defense Movement, it increases the Defense for 2 turns
  public static void DefensiveChoice(ref Character c){
    Console.WriteLine(c.Name + " is assuming a Defensive stance");
    //It searches if the skill is already activated, if it is then it time is reset
    foreach(BuffSkill b in c.SkillTrained){
      if(b.Name == "Defensive Position" && !c.BuffAndDebuffActive.Exists(x => x.Name == "Defensive Position")){
        c.BuffAndDebuffActive.Add(new BuffSkill(b){}); 
      }
      else{
        if(c.BuffAndDebuffActive.Exists(x => x.Name == "Defensive Position")){
          c.BuffAndDebuffActive.Find(x => x.Name == "Defensive Position").Turns = 0;
        }
      }
    }
  }

  public static void SkillChoice(ref Character c, ref Monster m){
    int count = 0; 
    int choice = 0;
    int page = 0;
    int skillCount = 0;
    List<SkillBase> skillList = new List<SkillBase>(c.SkillTrained);
    skillList.Remove(skillList.Find(s => s.Id == 0));

    decimal pageLimit = (skillList.Count < 3) ? 0 : Math.Ceiling(Convert.ToDecimal(skillCount)/3);
    skillCount = (skillList.Count > (3 + (3 * page))) ? 3 : skillList.Count;

    Console.WriteLine(skillCount);
    Console.WriteLine(pageLimit);
    
    do{
      for(int i = 0; i < skillCount; i ++){
        if(!skillList.ElementAt(count + (page * 3)).Cooldown){
          Console.WriteLine($"{i + 1} - {skillList.ElementAt(count + (page * 3)).SkillDescription()}");
          Console.WriteLine("======================================");
          count++;        
        }
      }           
        Console.WriteLine();  
      if(pageLimit != 0){
        choice = InputCheck.ListLength("Choose Skill by number (0 to go back) / 4 - last page / 5 - next page", skillCount);
        if (choice == 4 && page != 0){
          page -= 1;
        }
        else if (choice == 5 && page < pageLimit){
          page += 1; 
        }
      }
      else{
        choice = InputCheck.ListLength("Choose Skill by number: ", skillCount);
      }
    }while((choice == 4 || choice == 5));   
  }
}