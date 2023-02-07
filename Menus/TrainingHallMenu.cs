using System; 

class TrainingHallMenu{
  public static Character TrainingDecision(ref Character chosen){
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

    return chosen;
  }
}