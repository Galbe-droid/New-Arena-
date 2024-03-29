using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects.Interface;
//Monster uses Creature Abstraction 
//Under modifications, passing some stats to an Abstract class
//Base Stats, Death, Monster Type
//Still no: Boss(Maybe)
class Monster : Creature, IPotionEffect, IReward
{
  public int Id {get; set;}
  public Types Type {get; set;}
  public List<Potion> PotionEffect = new();
  public int XpReward {get; set; }
  public int GoldReward { get; set; }
  public SubTypes[] SubType = new SubTypes[2];
  public int CharacterMinLevel {get; set;}

  public Monster(int id, string name, int str, int inte, int agi, int vig, int characterMinLevel)
  {
    Id = id;
    Name = name;

    Level = 1;
    Type = Types.Prefab;

    XpReward = 0;
    GoldReward = 0;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    CharacterMinLevel = characterMinLevel;

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = (int)Math.Ceiling(Str * 1.4f);

    Health = 5 + (Vig * 5);
    Mana = 3 + (Int * 3);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;

    Dead = false;
  }

  public Monster(Monster monster)
  {
    Id = monster.Id;
    Name = monster.Name;

    Level = 1;
    Type = monster.Type;

    XpReward = monster.XpReward;
    GoldReward = monster.GoldReward;

    Str = monster.Str;
    Int = monster.Int;
    Agi = monster.Agi;
    Vig = monster.Vig; 

    CharacterMinLevel = monster.CharacterMinLevel;

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = (int)Math.Ceiling(Str * 1.4f);

    Health = 5 + (Vig * 5);
    Mana = 3 + (Int * 3);

    Damage = 0;
    ManaSpend = 0;
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0 * 500;
    ModAttack = 0;

    Dead = false;
  }
  
  public Monster()
  {
    Id = 0;
    Name = "Monster";

    Level = 0;
    Type = Types.Prefab;

    XpReward = 0;
    GoldReward = 0;

    Str = 0;
    Int = 0;
    Agi = 0;
    Vig = 0; 

    CharacterMinLevel = 0;

    Defense = (int)Math.Ceiling(Vig * 0.5f);
    Dodge = 0 + (500 * Agi);
    Attack = (int)Math.Ceiling(Str * 1.4f);

    Health = 5 + (Vig * 5);
    Mana = 3 + (Int * 3);
    
    Damage = 0;
    ManaSpend = 0;
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0;
    ModAttack = 0;
  }

  public void AddEffects(StatusPotion statusPotion)
  {
    switch(statusPotion.BuffManipulated)
    {
      case BuffType.Attack:
        ModAttack += statusPotion.Applying();
        statusPotion.IsActive = true;
        break;
      case BuffType.Defense:
        ModDefense += statusPotion.Applying();
        statusPotion.IsActive = true;
        break;
      case BuffType.Dodge:
        ModDodge += statusPotion.Applying();
        statusPotion.IsActive = true;
        break;
    }
  }
  public void StatusPotionTurnPass()
  {
    foreach(StatusPotion potion in PotionEffect.Cast<StatusPotion>())
    {
      potion.TurnCount();
    }
  }
  public void PotionEffectRemoval()
  {
    foreach(StatusPotion potion in PotionEffect.Cast<StatusPotion>())
    {
      if(potion.IsActive && potion.Turn >= potion.TurnMax)
      {
        switch(potion.BuffManipulated)
        {
          case BuffType.Attack:
            ModAttack -= potion.Applying();
            break;
          case BuffType.Defense:
            ModDefense -= potion.Applying();
            break;
          case BuffType.Dodge:
            ModDodge -= potion.Applying();
            break;
        }                
        PotionEffect.Remove(potion);
      }
    }
  }

  public void Checking(){
    StatusPotionTurnPass();
    PotionEffectRemoval();
  }
}