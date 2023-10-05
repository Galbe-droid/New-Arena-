using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Arena_.Behaviour
{
  class PlayerSkillUse
  {
    public static int SkillChoice(Character c, Monster m, out int skillChoice)
    {
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
      do
      {
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
        if(pageLimit > 1)
        {
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
        else
        {
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
    public static void UsingSkill(Character c, Monster m, SkillBase s)
    {
      if (s.GetType() == typeof(BuffSkill))
      {
        SkillUse.BuffSkillUse<Character>(c, (BuffSkill)s);
      }
      else if (s.GetType() == typeof(DebuffSkill))
      {
        SkillUse.DebuffSkillUse<Creature>(c, m, (DebuffSkill)s);
      }
      else if (s.GetType() == typeof(AttackSkill))
      {
        SkillUse.AttackSkillUse<Creature>(c, m, (AttackSkill)s);
      }
      else if (s.GetType() == typeof(DefenseSkill))
      {
        SkillUse.DefenseSkillUse<Character>(c, (DefenseSkill)s);
      }
      else
      {
          Console.WriteLine("Error.");
      }
    }
  }
}