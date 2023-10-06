using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class ArenaBehaviour
{
  //Controls Day and night behaviour, certain activities depend on it 
  public static void TurnControl(ref Character chosen, ref Monster monster, bool initiative)
  {
    if(initiative)
    {
      Console.WriteLine("Turn Start !!");
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        CombatMenu. PlayerChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage("Player turn ended.");
      }      
      //Monster Turn
      if(!monster.DeathCheck())
      {
        CombatMonsterBehaviour.MonsterChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage($"{monster.Name} turn ended.");
      }
      
    }
    else
    {
      //Monster Turn
      if(!monster.DeathCheck())
      {
        CombatMonsterBehaviour.MonsterChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage($"{monster.Name} turn ended.");
      }
      //Player Turn 
      if(!chosen.DeathCheck())
      {
        CombatMenu. PlayerChoice(ref chosen, ref monster);
        UpdateConsole.StaticMessage("Player turn ended.");
      }      
    }    
  }

  //In case of status straining the player needs to be updated 
  public static void UpdateCharacter(Character chosen)
  {
    chosen.Defense = chosen.Vig/2;
    chosen.Dodge = 0 + (500 * chosen.Agi);
    chosen.Attack = chosen.Str;

    chosen.Health = 10 + (chosen.Vig * 10);
    chosen.Mana = 5 + (chosen.Int * 5);
  }

  public static void InnFunction(ref Character chosen, List<IFood> foodtable)
  {      
    InnScreen.FoodDisplay(foodtable);

    ArenaBehaviour.FoodConsuption(ref chosen, foodtable);

    Console.Clear();

    GameScreen.CharacterStats(chosen);

    InnScreen.FoodDisplay(foodtable);

    ArenaBehaviour.TakeFood(ref chosen, foodtable);

    Console.Clear();
  }

  public static void FoodConsuption(ref Character chosen, List<IFood> foodTable)
  {
    int choiceEat = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
    int[] acceptedOptions = {1,2,3,4,5};

    if(choiceEat != 0){
      choiceEat--;
      IFood foodChoice = foodTable[choiceEat];

      do
      {
        Console.WriteLine("Food eaten!");
        chosen.Damage -= chosen.Damage < foodChoice.RecoveryHp ? chosen.Damage : foodChoice.RecoveryHp;
        chosen.ManaSpend -= chosen.ManaSpend < foodChoice.RecoveryMp ? chosen.ManaSpend : foodChoice.RecoveryMp;
        foodTable[choiceEat].FoodEaten = true;
        Console.ReadKey();

      }while(!acceptedOptions.Contains(choiceEat));    
    }   

    
  }
  public static void TakeFood(ref Character chosen, List<IFood> foodTable)
  {
    int choiceTake = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
    int[] acceptedOptions = {1,2,3,4,5};

    if(choiceTake != 0)
    {
      choiceTake--;
      IFood foodTake = foodTable[choiceTake];

      do
      {
        if(foodTake.FoodEaten == true)
        {
          UpdateConsole.StaticMessage("Food Already Eaten ");
          Console.ReadKey();
        }
        else
        {

        }

      }while(!acceptedOptions.Contains(choiceTake) && foodTake.FoodEaten != true);
    }   
  }
}