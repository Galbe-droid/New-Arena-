using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Loading;

class MonsterGeneration
{
  public static List<Monster> MonstersListOfTheDay = new();
  public static List<Monster> monsterListPrefab = MonsterLoading.Monsters;
  public static Dictionary<int, List<MonsterVariation>> monsterVariationDictionary = MonsterLoading.ListOfMonsterVariation;

  public static Monster Creator()
  {
    //REGULAR MONSTER GENERATION
    Array typeList = Enum.GetValues(typeof(Types));  

    List<SubTypes> subTypesOffensive = new()
    {
        SubTypes.Brute,
        SubTypes.Tatical
    };

    List<SubTypes> subTypesDefense = new()
    {
        SubTypes.Support,
        SubTypes.Survival
    };

    int randId = ManagerRandom.GetThreadRandom().Next(monsterListPrefab.Count);

    Monster monsterChoosen = new(monsterListPrefab.Find(m => m.Id == randId));
    
    monsterChoosen.Level = ManagerRandom.GetThreadRandom().Next(monsterChoosen.Level, monsterChoosen.Level + 3);

    monsterChoosen.Type = (Types)typeList.GetValue(ManagerRandom.GetThreadRandom().Next(1, typeList.Length));

    monsterChoosen.SubType[0] = subTypesOffensive.ElementAt(ManagerRandom.GetThreadRandom().Next(0, subTypesOffensive.Count));
    monsterChoosen.SubType[1] = subTypesDefense.ElementAt(ManagerRandom.GetThreadRandom().Next(0, subTypesDefense.Count));

    AttributeAlocation.PlacingAtributes(monsterChoosen);
    //

    //ADDING VARIATION
    List<MonsterVariation> monsterVariations = new(monsterVariationDictionary[monsterChoosen.Id]);
    int randVarId = ManagerRandom.GetThreadRandom().Next(monsterVariations.Count);

    MonsterVariation monsterVariation = new(monsterChoosen, monsterVariations.Find(mv => mv.VariationId == randVarId));

    AttributeAlocation.AddExtraStats(ref monsterVariation);
    AttributeAlocation.ApplyRewardMultiply(ref monsterVariation);

    monsterVariations.Clear();
    //
    monsterVariation.InitializationDefense();
    
    return monsterVariation;
  }

  //Generates 5 monster per day
  public static List<Monster> MonsterOfTheDay()
  {
    for(int i = 0; i < ProgressBehaviour.MonsterCageQuantity; i++)
    {
      MonstersListOfTheDay.Add(Creator());
    }

    return MonstersListOfTheDay;
  }

  //Remove monster from the list 
  public static void CleaningCages()
  {
    if(MonstersListOfTheDay.Count > 0)
    {
      MonstersListOfTheDay.Clear();
    }
  }
}