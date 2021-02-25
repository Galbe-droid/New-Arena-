using System;
using System.Collections.Generic;

class MonsterGeneration
{
  public static List<Monster> monsterListPrefab = MonsterList.Monsters;
  public static Array typeList = Enum.GetValues(typeof(Types));

  public static Monster Creator()
  {
    Random random = new Random();
    Monster monsterChoosen = monsterListPrefab.Find(m => m.Id == random.Next(0, monsterListPrefab.Count -1));

    monsterChoosen.Level = random.Next(monsterChoosen.Level, monsterChoosen.Level + 3);

    //1Offensive, 2Defensive, 3Balance 
    monsterChoosen.Type = (Types)typeList.GetValue(random.Next(1, typeList.Length));

    Console.WriteLine("Estou Aqui");

    int atributes = monsterChoosen.Level * 3;
    int spend = 0;

    Console.WriteLine("Estou Aqui");
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
      else if(monsterChoosen.Type == Types.Prefab)
      {
        spend++;
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
    int count = 0;
    List<Monster> MonstersListOfTheDay = new List<Monster>();

    while(count <= 5)
    {
      MonstersListOfTheDay.Add(Creator());
      count++;
    }

    return MonstersListOfTheDay;
  }
}