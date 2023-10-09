using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Arena_.Screens
{
    class SkillListInCombat
    {
        public static void Screen(int page, decimal pageLimit, int skillCount, List<SkillBase> skillList, Character c, Monster m)
        {
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
        }
    }
}