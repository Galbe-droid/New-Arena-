using System;
using System.Collections.Generic;
using System.Linq;

class MonsterGeneration
{
  public static List<Monster> MonstersListOfTheDay = new List<Monster>();

  public static List<Monster> monsterListPrefab = MonsterList.Monsters;

  public static Monster Creator()
  {
    Array typeList = Enum.GetValues(typeof(Types));  

    List<SubTypes> subTypesOffensive = new List<SubTypes>();
    subTypesOffensive.Add(SubTypes.Brute);
    subTypesOffensive.Add(SubTypes.Tatical);

    List<SubTypes> subTypesDefense = new List<SubTypes>();
    subTypesDefense.Add(SubTypes.Support);
    subTypesDefense.Add(SubTypes.Survival);

    Random random = new Random();
    int randId = random.Next(monsterListPrefab.Count);

    Monster monsterChoosen = new Monster(monsterListPrefab.Find(m => m.Id == randId));
    
    monsterChoosen.Level = random.Next(monsterChoosen.Level, monsterChoosen.Level + 3);

    monsterChoosen.Type = (Types)typeList.GetValue(random.Next(1, typeList.Length));

    monsterChoosen.SubType[0] = (SubTypes)subTypesOffensive.ElementAt(random.Next(0, subTypesOffensive.Count));
    monsterChoosen.SubType[1] = (SubTypes)subTypesDefense.ElementAt(random.Next(0, subTypesDefense.Count));

    AttributeAlocation.PlacingAtributes(monsterChoosen);

    return monsterChoosen;
  }

  //Generates 5 monster per day
  public static List<Monster> MonsterOfTheDay()
  {
    for(int i = 0; i < 5; i++)
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