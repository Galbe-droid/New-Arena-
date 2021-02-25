using System;
using System.Collections.Generic;

class ArenaEntrance
{
  public static void MonsterOfTheDayDisplay(List<Monster> displayList)
  {
    int cage = 1;

    foreach(Monster m in displayList)
    {
      Console.WriteLine("===========Cage:" + cage + "================");
      Console.WriteLine("Name:" + m.Name + " Lvl:" + m.Level + " Behavior: " + m.Type );
      Console.WriteLine("Stats: Str:" + m.Str + " Int:" + m.Int + " Agi:" + m.Agi + " Vig:" + m.Vig);
      cage ++;
    }

    for(int x = 0; x < displayList.Count; x++)
    {
      Console.WriteLine("===========Cage:" + cage + "================");
      Console.WriteLine("Name:" + displayList[x].Name + " Lvl:" + displayList[x].Level + " Behavior: " + displayList[x].Type );
      Console.WriteLine("Stats: Str:" + displayList[x].Str + " Int:" + displayList[x].Int + " Agi:" + displayList[x].Agi + " Vig:" + displayList[x].Vig);
      cage ++;
    }
  }
}