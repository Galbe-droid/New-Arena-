using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Configuration;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Screens;

//Controls player and monster Basic combat options
class BasicCombatBehaviour
{
  //Basic Attack option, it receives a attacker and a defender
  public static int AttackOption<T>(T attacker, T defender) where T : Creature
  {
    //Basic attacks generate from 0 to +20 for the basic damage and defense
    int _totalAttack = ManagerRandom.GetThreadRandom().Next(attacker.MinDamage, attacker.MaxDamage + 1);
    int _totalDefense = ManagerRandom.GetThreadRandom().Next(defender.MinDefense, defender.MaxDefense + 1);

    //Dodge uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500
    //Accuracy uses the same mechanic, if accuracy is higher then it hits 
    int _accuracy = ManagerRandom.GetThreadRandom().Next(0,100001);

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
      BuffSkill _defense = new((BuffSkill)creature.SkillTrained.Find(skill => skill.Id == 0));
      creature.BuffActive.Add(new BuffSkill(_defense));
    }else{
      creature.BuffActive.Find(skill => skill.Id == 0).Turns = 0;
    }  
  }

  public static bool ItemOption(Character character, Monster monster, List<ItemBase> itemBag)
  {
    int choice;
    int page = 1;

    //Recreates the item bag but with only consumables
    List<ItemBase> consumableList = itemBag;
    //This int needs to be initiated after everything, it controls the 3 itens per page and need to be initiated after the list but before the pageLimite
    int itemCount = consumableList.Count;
    //Create pages in case the skill list has more then 3 itens
    decimal pageLimit = (consumableList.Count < 3) ? 1 : Math.Ceiling(Convert.ToDecimal(itemCount)/3);

    ListingItens.Screens(page, pageLimit, itemBag);

    //Loop for changing the page in case it has more then 3 Itens 
    do
    {
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
        else if(choice == 0){
          return false;
        }
        else{
          //multiplay the choice with the page getting the correct position 
          choice = (choice * page) - 1;

          if(choice != -1)
          {
            ChoiceMade(consumableList, choice, character, monster);
            return true;
          }
          else
            return false;           
        }        
      }
      else
      {
        choice = InputCheck.ListLength("Choose Item by number: ", itemCount);
        choice -= 1;

        if(choice != -1)
        {
          ChoiceMade(consumableList, choice, character, monster);
          return true;
        }
        else
          return false;          
      }  
    }while(choice == 4 || choice == 5);   

    return false;
  }

  private static void ChoiceMade(List<ItemBase> itemBases, int choice, Character character, Monster monster)
  {
    switch(itemBases[choice].GetType().ToString())
    {
      case "Food":
        Food food = (Food)itemBases[choice];
        food.Action(ref character);
        if(food.Quantity > 1)
          food.Quantity--;
        else if(food.Quantity == 1)
          itemBases.Remove(itemBases[choice]);

        UpdateConsole.StaticMessage($"{character.Name} eats {food.Name} and restores {food.HpModifier}Hp and {food.MpModifier}Mp, There is time for this !?");
        break;

      case "HpAndMpPotion":
        HpAndMpPotion hPotion = (HpAndMpPotion)itemBases[choice];
        if(hPotion.UseOnPlayer)
        {
          hPotion.Action(ref character);
          UpdateConsole.StaticMessage($"{character.Name} uses {hPotion.Name} and restores {hPotion.HpModifier}Hp and {hPotion.MpModifier}Mp");
        }          
        else
        {
          hPotion.Action(ref monster);
          UpdateConsole.StaticMessage($"{character.Name} uses {hPotion.Name} on {monster.Name} and causes -{hPotion.HpModifier}Hp and -{hPotion.MpModifier}Mp of Damage");
        }
               
        if(hPotion.Quantity > 1)
          hPotion.Quantity--;
        else if(hPotion.Quantity == 1)
          itemBases.Remove(itemBases[choice]);
        break;

      case "StatusPotion":
        StatusPotion sPotion = (StatusPotion)itemBases[choice];
        if(sPotion.UseOnPlayer)
        {
          character.AddEffects(sPotion);
          UpdateConsole.StaticMessage($"{character.Name} uses {sPotion.Name} this increase {sPotion.BuffString} for some time");
        }          
        else
        {
          monster.AddEffects(sPotion);
          UpdateConsole.StaticMessage($"{character.Name} uses {sPotion.Name} on {monster.Name} this decreased {sPotion.BuffString} for some time");
        }

        if(sPotion.Quantity > 1)
          sPotion.Quantity--;
        else if(sPotion.Quantity == 1)
          itemBases.Remove(itemBases[choice]);
        break;
    }
  }
}