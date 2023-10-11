using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Screens;

//Controls player and monster Basic combat options
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
      Console.WriteLine(_defense.IsActivedOnce.ToString());
      creature.BuffActive.Add(new BuffSkill(_defense));
    }else{
      creature.BuffActive.Find(skill => skill.Id == 0).Turns = 0;
    }  
  }

  public static Consumable ItemOption(List<ItemBase> itemBag)
  {
    int choice = 0;
    int page = 1;

    //Recreates the item bag but with only consumables
    List<ItemBase> consumableList = itemBag.Where(item => item.GetType() == typeof(Consumable)).ToList();
    //This int needs to be initiated after everything, it controls the 3 itens per page and need to be initiated after the list but before the pageLimite
    int itemCount = consumableList.Count;
    //Create pages in case the skill list has more then 3 itens
    decimal pageLimit = (consumableList.Count < 3) ? 1 : Math.Ceiling(Convert.ToDecimal(consumableList)/3);

    //Create a page for each 3 Itens
    pageLimit = (consumableList.Count > 3 + ((page - 1) * 3)) ? 3 : itemCount = consumableList.Count - (page - 1) * 3;

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
          return null;
        }
        else{
          //multiplay the choice with the page getting the correct position 
          choice = (choice * page) - 1;

          if(choice == -1)
          {
            Consumable consumeNull = new(9999, "", 0, 0, 0, 0);
            return consumeNull;
          }

          Consumable consume = new((Consumable)consumableList[choice]);
          return consume;
        }        
      }
      else
      {
        choice = InputCheck.ListLength("Choose Item by number: ", itemCount);
        choice -= 1;

        if(choice == -1)
        {
          Consumable consumeNull = new(9999, "", 0, 0, 0, 0);
          return consumeNull;
        }
          

        Consumable consume = new((Consumable)consumableList[choice]);
        return consume;
      }  
    }while((choice == 4 || choice == 5));   

    return null;
  }

  public static Character ConsumableUse(Character c, Consumable consume)
  {
    c.Damage = consume.RecoveryHp >= c.Damage ? 0 : consume.RecoveryHp - c.Damage;
    c.ManaSpend = consume.RecoveryMp >= c.ManaSpend ? 0 : consume.RecoveryHp - c.ManaSpend;

    Console.WriteLine($"Recovered: HP - {consume.RecoveryHp} / MP - {consume.RecoveryMp}");
    Console.ReadKey();

    return c;
  }
}