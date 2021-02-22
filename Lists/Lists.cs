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
    return PlayerId;
  }
}