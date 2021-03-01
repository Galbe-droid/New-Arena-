using System;
using System.Collections.Generic;

class Lists
{
  public static List<Character> CharacterList = new List<Character>();

  public static int CountListPlayer()
  {
    int PlayerCount = CharacterList.Count;
    return PlayerCount;
  }

  public static int IdPlayerGeneration()
  {
    int PlayerId = CharacterList.Count;
    foreach(Character c in CharacterList)
    {
      if(PlayerId == c.Id)
      {
        PlayerId++;
      }
    }
    return PlayerId;
  }

  public static void PlayerShowList()
  {
    foreach(Character c in CharacterList)
    {
      Console.WriteLine("=================================");
      Console.WriteLine("ID:" + c.Id + " Name:" + c.Name + "  Lvl:" + c.Level + "  Xp:" + c.Xp);
    }
  }
}