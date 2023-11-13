using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Loading;
using New_Arena_.Save;

//All characters created are put on a list, the list is persistent but it no preserve the character in case of a reload
class CharacterListManagement
{
  public static int IdPlayerGeneration()
  {
    List<int> alreadyUseIds = new();
    foreach(Character c in VerifySaveFile.SaveCharacterList)
    {
      alreadyUseIds.Add(c.Id);
    }
    return alreadyUseIds.Count != 0 ? alreadyUseIds.Max() + 1 : 0;
  }

  public static void PlayerShowList()
  {
    foreach(Character c in CharactersLoading.GlobalCharacterList)
    {
      Console.WriteLine("=================================");
      Console.WriteLine($"ID: {c.Id} Name: {c.Name} Lvl: {c.Level} Xp: {c.XpTotal} Gold: {c.Gold}");
    }
  }

  public static void DeleteCharacter()
  {
    Console.WriteLine("Select the ID of the character to Delete... (-1 - To go back)");
    int characterIdToBeDeleted = InputCheck.IntCheck("Choose:", "Not a Number");

    if(characterIdToBeDeleted != -1)
      ConfimationAndDeletion(characterIdToBeDeleted);
  }

  public static void ConfimationAndDeletion(int Id)
  {
    if(!CharactersLoading.GlobalCharacterList.Exists(character => character.Id == Id))
      UpdateConsole.StaticMessage("Character don't exist.");
    else
    {
      Console.WriteLine("Are you sure S/N");
      Console.Write("Choose: ");
      if(Console.ReadLine().ToUpper() == "S")
      {
        CharactersLoading.GlobalCharacterList.Remove(CharactersLoading.GlobalCharacterList.Find(character => character.Id == Id));
        VerifySaveFile.ReloadSaveList();
      }       
    }
  }
}