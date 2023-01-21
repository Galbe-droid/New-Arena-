using System;
using System.Collections.Generic;

class MonsterGeneration
{
  public static List<Monster> MonstersListOfTheDay = new List<Monster>();

  public static List<Monster> monsterListPrefab = MonsterList.Monsters;

  public static Array typeList = Enum.GetValues(typeof(Types));
  

  public static Monster Creator()
  {
    Random random = new Random();
    int randId = random.Next(monsterListPrefab.Count);

    Monster monsterChoosen = new Monster(monsterListPrefab.Find(m => m.Id == randId));
    
    monsterChoosen.Level = random.Next(monsterChoosen.Level, monsterChoosen.Level + 3);

    //1Offensive, 2Defensive, 3Balance 
    monsterChoosen.Type = (Types)typeList.GetValue(random.Next(1, typeList.Length));

    if(monsterChoosen.Type == Types.Offensive)
    {
      AttributeAlocation.OffensiveMonster(monsterChoosen);
    }
    else if(monsterChoosen.Type == Types.Defensive)
    {
      AttributeAlocation.DefensiveMonster(monsterChoosen);
    }
    else if(monsterChoosen.Type == Types.Balance)
    {
      AttributeAlocation.BalanceMonster(monsterChoosen);
    }

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