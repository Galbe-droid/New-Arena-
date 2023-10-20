using System; 
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;

class TrainingHallMenu{  
  public static void TrainingDecision(ref Character chosen){
    string choice;

    do{
      GameScreen.CharacterStats(chosen);

      Console.WriteLine("Inside the Training Hall");
      Console.WriteLine("S - Stats Training /// K - Skill Training");
      Console.Write("Choose (X to go back):");
      choice = Console.ReadLine().ToUpper();

      switch(choice){
        case "S":
          bool statusIncreasing = true;
          do
          { 
            Console.Clear();
            GameScreen.CharacterStats(chosen);
            statusIncreasing = TrainingHallBehaviour.StatsIncrease(ref chosen);                        
          }while(statusIncreasing);  
          chosen.UpdateCharacter();        
          break;

        case "K":
          if(ArenaBehaviour.skillOfTheDay.Count >= 1){
            chosen = TrainingHallBehaviour.SkillToLearn(chosen);
          }else{
            Console.WriteLine("There is no Skill To Learn");
            Console.ReadKey();
          }          
          Console.Clear();
          break;

        case "X":
          Console.Clear();
          break;
          
        default:
          Console.WriteLine("Invalid.");
          Console.Clear();
          break;
      }
    }while(choice.ToUpper() != "X");
    Console.Clear();
  }  
}