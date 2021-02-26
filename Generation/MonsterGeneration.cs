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
    while(monsterChoosen.Type == Types.Prefab)
    {
      monsterChoosen.Type = (Types)typeList.GetValue(random.Next(typeList.Length));
    }   

    int atributes = monsterChoosen.Level * 3;
    int spend = 0;

    while(spend != atributes)
    {
      int chance = random.Next(0, 100); 
      if(monsterChoosen.Type == Types.Offensive)
      {
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
      else if(monsterChoosen.Type == Types.Defensive)
      {
        if(chance >= 0 && chance <= 60)
        {
          monsterChoosen.Vig++;
          spend++;
        }

        if(chance >= 61 && chance <= 70)
        {
          monsterChoosen.Str++;
          spend++;
        }

        if(chance >= 71 && chance <= 85)
        {
          monsterChoosen.Int++;
          spend++;
        }

        if(chance >= 86 && chance <= 100)
        {
          monsterChoosen.Agi++;
          spend++;
        }
      }
      else if(monsterChoosen.Type == Types.Balance)
      {
        if(chance >= 0 && chance <= 25)
        {
          monsterChoosen.Str++;
          spend++;
        }

        if(chance >= 26 && chance <= 50)
        {
          monsterChoosen.Int++;
          spend++;
        }

        if(chance >= 51 && chance <= 75)
        {
          monsterChoosen.Agi++;
          spend++;
        }

        if(chance >= 76 && chance <= 100)
        {
          monsterChoosen.Vig++;
          spend++;
        }
      }
      else
      {
        Console.WriteLine("Error");
      }
    }

    return monsterChoosen;
  }

  public static List<Monster> MonsterOfTheDay()
  {
    for(int i = 0; i < 5; i++)
    {
      MonstersListOfTheDay.Add(Creator());
    }

    return MonstersListOfTheDay;
  }

  public static void CleaningCages()
  {
    if(MonstersListOfTheDay.Count > 0)
    {
      MonstersListOfTheDay.Clear();
    }
  }
}