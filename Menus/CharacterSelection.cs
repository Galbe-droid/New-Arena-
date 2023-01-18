using System;
using System.Collections.Generic;

class CharacterSelection
{
  public static List<Character> GameList = Lists.CharacterList;

  public static Character Select()
  {
    int idSelection = InputCheck.IntCheck("Select you caracter by Id:", "Only Numbers:");

    if(idSelection > GameList.Count || idSelection < -1)
    {
      Console.WriteLine("Character not Found");
      return null;
    }
    else if(idSelection == -1)
    {
      return null;
    }
    
    foreach(Character character in GameList)
    {
      Character chosen = GameList.Find(c => c.Id == idSelection);
      return chosen;
    }
    Console.WriteLine("Character not Found");
    return null;
  }
}