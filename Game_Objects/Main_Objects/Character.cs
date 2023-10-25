using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;
using New_Arena_.Generation.Market;
using New_Arena_.Loading;
//Character uses abstraction Creature 
//Under modifications, passing some stats to an Abstract class
//Base Stats, Death
class Character : Creature, IPotionEffect, IHaveWeapons, IHaveArmor, IGold, IXp, IReceiveReward
{
  //Character Settings
  public int Id {get; set;}  
  public new int Level {get; set;}
  public int Xp {get; set;}
  public int XpTotal {get; set;}
  public int Gold {get; set;}
  public Weapon Weapon { get; set; }
  public Armor Armor { get; set; }
  public List<Potion> PotionEffect { get; set; }
  public List<SkillBase> CapableOfLearn = new();
  public List<ItemBase> ItemBag = new();
  public List<ItemBase> EquipamentBag = new();
  public Dictionary<int, int> Levels { get; set; } 
  
  //Arena settings
  public int Days { get; set; }
  public bool Daytime { get; set; }
  public bool TimePass { get; set; }
  public List<Food> InnTodayFood = new(); 
  public List<Potion> MarketTodayPotion = new();
  public List<Weapon> MarketTodayWeapon = new();
  public List<Armor> MarketTodayArmor = new();
  public List<SkillBase> TrainingHallTodaySkills = new();
  public List<Monster> MonstersInArenaToday = new();
  

  public Character(int id, string name, int str, int inte, int agi, int vig)
  {
    Id = id;
    Name = name;

    Xp = 0;
    XpTotal = 0;

    Str = str;
    Int = inte;
    Agi = agi;
    Vig = vig; 

    Defense = (int)Math.Ceiling(Vig * 0.5);
    Dodge = 0 + (500 * Agi);
    Attack = (int)Math.Ceiling(Str * 1.4f);

    Health = 10 + (vig * 10);
    Mana = 5 + (inte * 5);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0 * 500;
    ModAttack = 0;

    Weapon = null;
    Armor = null;

    Dead = false;

    Days = 0;

    Daytime = true;
    TimePass = true;
  }

  public Character(Character character)
  {
    Id = character.Id;
    Name = character.Name;

    Xp = 0;
    XpTotal = 0;

    Str = character.Str;
    Int = character.Int;
    Agi = character.Agi;
    Vig = character.Vig; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str * 2;

    Health = 10 + (character.Vig * 10);
    Mana = 5 + (character.Int * 5);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0 * 500;
    ModAttack = 0;

    Weapon = null;
    Armor = null;

    Dead = false;

    Days = 0;

    Daytime = true;
    TimePass = true;
  }

  public Character()
  {
    Id = 9999;
    Name = "";

    Xp = 0;
    XpTotal = 0;

    Str = 0;
    Int = 0;
    Agi = 0;
    Vig = 0; 

    Defense = Vig/2;
    Dodge = 0 + (500 * Agi);
    Attack = Str * 2;

    Health = 10 + (0 * 10);
    Mana = 5 + (0 * 5);

    Damage = 0;
    ManaSpend = 0;
    
    Initiative = 0;
    ModDefense = 0;
    ModDodge = 0 * 500;
    ModAttack = 0;

    Weapon = null;
    Armor = null;

    Dead = false;

    Days = 0;

    Daytime = true;
    TimePass = true;
  }

  
  public void FillAvaliableSkill(){
    foreach(SkillBase s in SkillsLoading.AllSkills){
      if(!this.CapableOfLearn.Exists(x => x.Id == s.Id) && !this.SkillTrained.Exists(x => x.Id == s.Id)){
        if(s.GetType() == typeof(BuffSkill)){
          this.CapableOfLearn.Add(new BuffSkill((BuffSkill)s));
        }
        else if(s.GetType() == typeof(DebuffSkill)){
          this.CapableOfLearn.Add(new DebuffSkill((DebuffSkill)s));
        }
        else if(s.GetType() == typeof(AttackSkill)){
          this.CapableOfLearn.Add(new AttackSkill((AttackSkill)s));
        }
        else if(s.GetType() == typeof(DefenseSkill)){
          this.CapableOfLearn.Add(new DefenseSkill((DefenseSkill)s));
        }
      }      
    }
  }
 
  public void UpdateCharacter()
  {
    this.Defense = this.Vig/2;
    this.Dodge = 0 + (500 * this.Agi);
    this.Attack = this.Str;

    this.Health = 10 + (this.Vig * 10);
    this.Mana = 5 + (this.Int * 5);

    UpdateMinMaxValues();
  }
  
  public void ExcludingSkills(int id){
    this.CapableOfLearn.Remove(this.CapableOfLearn.Find(s => s.Id == id));
  }
 
  public void AddingItens(ItemBase item)
  {
    switch(item.GetType().ToString())
    {
      case "Food":
        Food food = new((Food)item);
        Food foodInTheList = (Food)ItemBag.FirstOrDefault(X => X.Id == food.Id && X.Quality.ToString() == food.Quality.ToString());

        if(foodInTheList != null)
          foodInTheList.Quantity++;
        else
        {
          ItemBag.Add(food);
        }
        break;

      case "HpAndMpPotion":
        HpAndMpPotion hPotion = new((HpAndMpPotion)item);
        HpAndMpPotion hPotionInList = (HpAndMpPotion)ItemBag.FirstOrDefault(X => X.Id == hPotion.Id && X.Quality.ToString() == hPotion.Quality.ToString());

        if(hPotionInList != null)
          hPotionInList.Quantity++;
        else
        {
          ItemBag.Add(hPotion);
        }
        break;

      case "StatusPotion":
        StatusPotion sPotion = new((StatusPotion)item);
        StatusPotion sPotionInList = (StatusPotion)ItemBag.FirstOrDefault(X => X.Id == sPotion.Id && X.Quality.ToString() == sPotion.Quality.ToString());

        if(sPotionInList != null)
          sPotionInList.Quantity++;
        else
        {
          ItemBag.Add(sPotion);
        }
        break;

      case "Weapon":
        Weapon weapon = new((Weapon)item);

        EquipamentBag.Add(weapon);
        break;

      case "Armor":
        Armor armor = new((Armor)item);

        EquipamentBag.Add(armor);
        break;
    }
  }
 
  public override string ToString(){
    return $"Name: {this.Name} \n" +
           $"Xp: {this.Xp} || Total Gold: 0 \n" +
           $"Str: {this.Str} || Agi: {this.Agi} || Int: {this.Int} || Vit: {this.Vig} \n" +
           $"Weapon: {this.Weapon.Name} || Quality: {this.Weapon.Quality} \n" +
           $"Armor: {this.Armor.Name} || Quality: {this.Armor.Quality} \n" +
           $"Min/Max Damage: {this.MinDamage} - {this.MaxDamage} \n" +
           $"Min/Max Defense: {this.MinDefense} - {this.MinDefense}";
  }
  
  public string ShowSkills(){
    string longString = "";
    foreach(SkillBase s in this.SkillTrained){
      if(s.Id != 0){
        longString += $"Name: {s.Name} || Type: {s.GetType()} \n";
        }
    }
    return longString;
  }
  
  public string ShowBag(){
    string longString = "";
    foreach(ItemBase i in ItemBag){
      longString += i.ToString() + "\n";
    }
    Console.WriteLine("=========Equipament========");
    foreach(ItemBase i in EquipamentBag){
      longString += i.ToString() + "\n";
    }

    return longString;
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
        PotionEffect.Remove(potion);
      }
    }
  }
  
  public void Checking(){
    StatusPotionTurnPass();
    PotionEffectRemoval();
  }
  
  public void Initalization()
  {
    FillAvaliableSkill();
    InitializeWeapon();
    InitializeArmor();
    InitializationDefense();
    UpdateMinMaxValues();
    InitializeLevel();
    CheckCharacterLevel();
    InitialGold();
  }
 
  public void InitializeWeapon()
  {
    Weapon = new(ItemsLoading.WeaponList.Find(weapon => weapon.Id == 0))
    {
        Quality = WeaponType.Regular
    };
  }
  
  public new void UpdateMinMaxValues(){
    MinDamage = (int)Math.Ceiling(TotalAttack() * Weapon.MinDamageModifier) + Weapon.MinDamage;
    MaxDamage = (int)Math.Ceiling(TotalAttack() * Weapon.MaxDamageModifier) + Weapon.MaxDamage;
    MinDefense = (int)Math.Ceiling(TotalDefense() * Armor.MinDefenseModifier) + Armor.MinDefense;
    MaxDefense = (int)Math.Ceiling(TotalDefense() * Armor.MaxDefenseModifier) + Armor.MaxDefense;
  }
  
  public void InitializeArmor()
  {
    Armor = new(ItemsLoading.ArmorList.Find(armor => armor.Id == 0))
    {
        Quality = WeaponType.Regular
    };
  }
  
  public void InitializeLevel()
  {
    Levels = ParametersLoading.GlobalLevels;
  }

  public void ChangeWeapon(Weapon newWeapon)
  {
    if(Weapon.Id == 0)
    {
      Weapon = newWeapon;
      EquipamentBag.Remove(newWeapon);
    }
    else
    {
      EquipamentBag.Add(Weapon);
      EquipamentBag.Remove(newWeapon);
      Weapon = newWeapon;
    }
  }
  
  public void ChangeArmor(Armor newArmor)
  {
    if(Armor.Id == 0)
    {
      Armor = newArmor;
      EquipamentBag.Remove(newArmor);
    }
    else
    {
      EquipamentBag.Add(Armor);
      EquipamentBag.Remove(newArmor);
      Armor = newArmor;
    }
  }
  
  public void RemoveWeapon()
  {
    if(Weapon.Id != 0)
    {
      EquipamentBag.Add(Weapon);
      InitializeWeapon();
    }
  }
  
  public void RemoveArmor()
  {
    if(Armor.Id != 0)
    {
      EquipamentBag.Add(Armor);
      InitializeArmor();
    }
  }
  
  public bool CheckCost(int cost)
  {
    if(Gold >= cost)
    {
      Gold -= cost;
      return true;
    }
    else
    {
      UpdateConsole.StaticMessage($"You dont have the necessary gold");
      return false;
    }  
  }

  public bool CheckXpCost(int cost)
  {
    if(Xp >= cost)
    {
      Xp -= cost;
      return true;
    }
    else
    {
      UpdateConsole.StaticMessage("Not enought Xp.");
      return false;
    }
  }

  public void CheckCharacterLevel()
  {
    //Level is defined by Total Xp, the more the higher the rarity level and other benefits
    Level = Levels.FirstOrDefault(xp => xp.Value >= XpTotal).Key;
  }

  public void ReceiveReward(int xp, int gold)
  {
    Gold += gold;
    XpTotal += xp;
    Xp += xp;
  }

  private void InitialGold()
  {
    Gold = 150;
  }

  //Arena Methods
  public void GetTodayLists()
  {
    FoodGeneration.ListOfFruitOfTheDay(InnTodayFood);
    PotionGeneration.ListOfPotionsOfTheDay(MarketTodayPotion);
    WeaponGeneration.ListOfWeaponsOfTheDay(MarketTodayWeapon);
    ArmorGeneration.ListOfArmorOfTheDay(MarketTodayArmor);
    SkillChoices.LearningSkill(this, TrainingHallTodaySkills);
    MonsterGeneration.MonsterOfTheDay(MonstersInArenaToday);
  }

  public void CleanTodayLists()
  {
    FoodGeneration.ClearFoods(InnTodayFood);
    PotionGeneration.ClearPotion(MarketTodayPotion);
    WeaponGeneration.ClearWeapons(MarketTodayWeapon);
    ArmorGeneration.ClearArmor(MarketTodayArmor);
    SkillChoices.ClearSkills(TrainingHallTodaySkills);
    MonsterGeneration.CleaningCages(MonstersInArenaToday);
  }
}
