using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;

class ArenaBehaviour
{
  public static List<Monster> cages { get; set;}
  public static List<Food> innFoodTable { get; set;}
  public static List<SkillBase> skillOfTheDay { get; set;}
  public static List<Potion> potionsOfTheDay { get; set;}
  public static List<Weapon> weaponsOfTheDay { get; set;}
  public static List<Armor> armorOfTheDay { get; set;}
  //Controls Day and night behaviour, certain activities depend on it 
  public static void TurnControl(ref Character chosen, ref Monster monster, bool initiative)
  {
    if(initiative)
    {
      Console.WriteLine("Turn Start !!");
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        PlayerTurn(chosen, monster);
      }      
      //Monster Turn
      if(!monster.DeathCheck())
      {
        MonsterTurn(chosen, monster);
      }      
    }
    else
    {
      //Monster Turn
      if(!monster.DeathCheck())
      {
        MonsterTurn(chosen, monster);
      }
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        PlayerTurn(chosen, monster);        
      }      
    }    
  }

  private static void PlayerTurn(Character chosen, Monster monster)
  {
    UpdateConsole.UpdateCombatStats(chosen, monster);
    CombatMenu.PlayerChoice(ref chosen, ref monster);
    UpdateConsole.StaticMessage("Player turn ended.");
    UpdateStatus(chosen, monster); 
  }

  private static void MonsterTurn(Character chosen, Monster monster)
  {
    UpdateConsole.UpdateCombatStats(chosen, monster);
    CombatMonsterBehaviour.MonsterChoice(ref chosen, ref monster);
    UpdateConsole.StaticMessage($"{monster.Name} turn ended.");
    UpdateStatus(chosen, monster);  
  }

  private static void UpdateStatus(Character chosen, Monster monster){
    //Checking for Buffs and Debuffs and counting turns for cooldown if none skill is in cooldown then the code dont execute
      if(chosen.SkillTrained.Exists(skill => skill.Cooldown == true) || monster.SkillTrained.Exists(skill => skill.Cooldown == true)){
        SkillUse.CooldownCounting(chosen, monster);
      }      
      chosen.CheckForBuffsDebuffs();
      monster.CheckForBuffsDebuffs();   
      chosen.UpdateMinMaxValues();
      monster.UpdateMinMaxValues();
  }

  public static void ReceiveLists(Character character)
  {
    cages = character.MonstersInArenaToday;
    innFoodTable = character.InnTodayFood;
    skillOfTheDay = character.TrainingHallTodaySkills;
    potionsOfTheDay = character.MarketTodayPotion;
    weaponsOfTheDay = character.MarketTodayWeapon;
    armorOfTheDay = character.MarketTodayArmor;
  }
}