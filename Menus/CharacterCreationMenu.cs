using System;

class CharacterCreationMenu
{
  public static string NameInput(string name)
  {
    Console.WriteLine("So you are not " + name + "...");
    Console.WriteLine("Well whats is your name then.");
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Clear();
    return name;
  }

  public static int StatsInput(int stats)
  {
    Console.WriteLine("Actual value: " + stats);
    Console.Write("New value: ");
    stats = int.Parse(Console.ReadLine());
    Console.Clear();
    return stats;
  }
}