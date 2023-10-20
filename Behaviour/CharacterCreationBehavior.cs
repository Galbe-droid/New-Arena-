using System;

namespace New_Arena_.Behaviour
{
    public class CharacterCreationBehavior
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
        
        public static int StatsInput(int stats, int avaliablePoints)
        {    
          int newStats;
          Console.WriteLine("Actual value: " + stats);
          newStats = InputCheck.IntCheck("New value:", "Only Numbers:");
        
          if(newStats <= 0)
          {
            stats = 1;
            Console.Clear();
            return stats;
          }
        
          if(CheckValidStatusChange(stats, newStats, avaliablePoints))
          {
            Console.Clear();
            return newStats;
          }      
          else
          {
            UpdateConsole.StaticMessage("Invalid change");
            Console.Clear();
            return stats;
          }    
        }
        private static bool CheckValidStatusChange(int stats, int newStats, int avaliablePoints)
        {
            if(newStats - stats <= 0)
                return true;
            
            if(avaliablePoints - (newStats - stats) < 0)
                return false;

            return true;
        }
    }
}