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
    int page = 1;
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
      CombatScreen.Stats(ref c,ref m);
      //Create a page for each 3 skills
      skillCount = (skillList.Count > 3 + ((page - 1) * 3)) ? 3 : skillCount = skillList.Count - (page - 1) * 3;

      //Loop for display the image 
      Console.WriteLine($"=================Page {page}/{pageLimit} ====================");
      for(int i = 0; i < skillCount; i ++){
        int currentPage = (page - 1) * 3;
        if(!skillList.ElementAt(i + currentPage).Cooldown){
          Console.WriteLine($"{i + 1} - {skillList.ElementAt(i + currentPage).SkillDescription()}");
          Console.WriteLine("======================================");   
        }
        else{
          Console.ForegroundColor = ConsoleColor.DarkGray;
          skillList.ElementAt(i + currentPage).SkillOnCooldown();
          Console.ResetColor();
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
          choice *= page;
        }        
      }
      else{
        choice = InputCheck.ListLength("Choose Skill by number: ", skillCount);
      }
    }while((choice == 4 || choice == 5));   
  }
}