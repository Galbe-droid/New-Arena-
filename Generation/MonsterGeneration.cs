using System;
using System.Collections.Generic;

class MonsterGeneration
{
  public static List<Monster> monsterListPrefab = MonsterList.Monsters;
  public static Array typeList = Enum.GetValues(typeof(Types));

  public static Monster Creator()
  {
    Random random = new Random();
    Monster monsterChoosen = monsterListPrefab.Find(m => m.Id == random.Next(monsterListPrefab.Count));

    monsterChoosen.Level = random.Next(monsterChoosen.Level, monsterChoosen.Level + 3);

    //1Offensive, 2Defensive, 3Balance 
    monsterChoosen.Type = (Types)typeList.GetValue(random.Next(1, typeList.Length));

    int atributes = monsterChoosen.Level * 3;
    int spend = 0;

    while(spend != atributes)
    {
      if(monsterChoosen.Type == Types.Ofensive)
      {
        int chance = random.Next(0, 100); 

        if(chance >= 0 && chance <= 60)
        {
          monsterChoosen.Str++;
          spend++;
        }

        if(chance >= 61 && chance <= 70)
        {
          monsterChoosen.Int++;
          spend++;
        }

        if(chance >= 71 && chance <= 85)
        {
          monsterChoosen.Agi++;
          spend++;
        }

        if(chance >= 86 && chance <= 100)
        {
          monsterChoosen.Vig++;
          spend++;
        }
      }
    }

    return monsterChoosen;
  }

  public static List<Monster> MonsterOfTheDay(Monster monsterReady)
  {
    int count = 0;
    List<Monster> MonstersListOfTheDay = new List<Monster>();

    while(count > 5)
    {
      MonstersListOfTheDay.Add(Creator());
    }

    return MonstersListOfTheDay;
  }

  /*public static void MonsterOfTheDayDisplay(List<Monster> displayList)
  {
    
  }*/
}