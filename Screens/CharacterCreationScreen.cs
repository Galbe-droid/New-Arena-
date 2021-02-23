using System;

class CharacterCreation
{
  public static void Creator(string name, int xp, int lvl, int str, int inte, int agi, int vig)
  {
    int Health = 5 * vig;
    int Mana = 3 * inte;
           
    Console.WriteLine("STATS");
    Console.WriteLine("Name:" + name + "   XP:" + xp + "   Level:" + lvl);
    Console.WriteLine("HP:" + Health + " Mana:" + Mana);
    Console.WriteLine("Str:" + str + " Int:" + inte + " Agi:" +  agi + " Vig:" + vig);
  }

  public static void CreatorMainScreen()
  {
    Console.WriteLine("Select one of the options to chance its values.");
    Console.WriteLine("N - Name\nS - Str / I - Int\nA- Agi / V - Vig\nE - Exit(it will not save the character) / F - Finish");
  }
}