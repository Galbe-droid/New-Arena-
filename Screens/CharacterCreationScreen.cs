using System;

class CharacterCreation
{
  public static void Creator(string name, int xp, int lvl, int str, int inte, int agi, int vig)
  {
    int Health = 5 * vig;
    int Mana = 3 * inte;
        
    Console.WriteLine("=================================");    
    Console.WriteLine("Name:" + name + "   XP:" + xp + "   Level:" + lvl);
    Console.WriteLine("HP:" + Health + " Mana:" + Mana);
    Console.WriteLine("Str:" + str + " Int:" + inte + " Agi:" +  agi + " Vig:" + vig);
    Console.WriteLine("=================================");
  }
}