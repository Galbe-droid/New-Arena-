using System; 
using System.Collections.Generic;
using System.Linq;

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
          Console.WriteLine("Stats Training not ready.");
          Console.Clear();
          break;

        case "K":
          Console.WriteLine("Skil Training not ready.");
          if(skillOfTheDay.Count >= 1){
            SkillToLearn(ref chosen);
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

  public static void SkillToLearn(ref Character c){
    int choice;

    Console.WriteLine();
    choice = InputCheck.IntCheck("Skill Choice (0 to go back): ", "Invalid");

    choice -= 1;
    
    if(choice == -1){

    }
    else{
      
    }    
  }
}

