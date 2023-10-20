using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Generation.Market;

class ArenaBehaviour
{
  public static List<Monster> cages;
  public static List<Food> innFoodTable;
  public static List<SkillBase> skillOfTheDay;
  public static List<Potion> potionsOfTheDay;
  public static List<Weapon> weaponsOfTheDay;
  public static List<Armor> armorOfTheDay;
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

  public static void ListPopulating(Character chosen)
  {
    cages = new(MonsterGeneration.MonsterOfTheDay());
    skillOfTheDay = new(SkillChoices.LearningSkill(chosen));  
    innFoodTable = new(FoodGeneration.ListOfFruitOfTheDay());
    potionsOfTheDay = new(PotionGeneration.ListOfPotionsOfTheDay());
    weaponsOfTheDay = new(WeaponGeneration.ListOfWeaponsOfTheDay());
    armorOfTheDay = new(ArmorGeneration.ListOfArmorOfTheDay());
  }

  public static void ListCleaning()
  {
    MonsterGeneration.CleaningCages();
    FoodGeneration.ClearFoods();
    SkillChoices.ClearSkills();
    PotionGeneration.ClearPotion();
    WeaponGeneration.ClearWeapons();
    ArmorGeneration.ClearArmor();
  }
}