using System; 
using System.Collections.Generic;
using System.Linq;

class TrainingHallMenu{  
  public static void TrainingDecision(ref Character chosen, List<SkillBase> skillOfTheDay){
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
          if(skillOfTheDay.Count >= 1){
            SkillToLearn(ref chosen, skillOfTheDay);
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

  public static void SkillToLearn(ref Character c, List<SkillBase>skillOfTheDay){
    int choice;

    SkillTrainingScreen.SkillDisplay(skillOfTheDay);
    
    Console.WriteLine();
    do{
      choice = InputCheck.ListLength("Skill Choice (0 to go back): ", skillOfTheDay.Count);
    }while((choice -1) > skillOfTheDay.Count || (choice -1) < -1);

    choice -= 1;
    
    if(choice == -1){
        
    }
    else{
      if(c.Xp >= skillOfTheDay[choice].Cost){
        Console.WriteLine("Skill: {0} Learned !", skillOfTheDay[choice].Name);
        if(skillOfTheDay[choice].GetType() == typeof(BuffSkill)){
          c.SkillTrained.Add(new BuffSkill((BuffSkill)skillOfTheDay[choice]));
        }
        else if(skillOfTheDay[choice].GetType() == typeof(DebuffSkill)){
          c.SkillTrained.Add(new DebuffSkill((DebuffSkill)skillOfTheDay[choice]));
        }
        else if(skillOfTheDay[choice].GetType() == typeof(AttackSkill)){
          c.SkillTrained.Add(new AttackSkill((AttackSkill)skillOfTheDay[choice]));
        }
        c.ExcludingSkills(skillOfTheDay[choice].Id);
        skillOfTheDay.Remove(skillOfTheDay[choice]);
        
        Console.ReadKey();
      }
      else{
        Console.WriteLine("Insulficient Xp.");
        Console.ReadKey();
      }
    }    
  }
}