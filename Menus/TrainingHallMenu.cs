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
          bool statusIncreasing = true;
          do
          { 
            Console.Clear();
            GameScreen.CharacterStats(chosen);
            statusIncreasing = StatsIncrease(ref chosen);                        
          }while(statusIncreasing);  
          ArenaBehaviour.UpdateCharacter(chosen);        
          break;

        case "K":
          if(skillOfTheDay.Count >= 1){
            chosen = SkillToLearn(chosen, skillOfTheDay);
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

  public static Character SkillToLearn(Character c, List<SkillBase>skillOfTheDay){
    int choice;
    //Show the skill avaliable to learn for a day
    SkillTrainingScreen.SkillDisplay(skillOfTheDay);
    
    Console.WriteLine();
    //Player Choice
    do{
      choice = InputCheck.ListLength("Skill Choice (0 to go back): ", skillOfTheDay.Count);
    }while((choice -1) > skillOfTheDay.Count || (choice -1) < -1);

    choice -= 1;
    
    if(choice == -1){
        
    }
    else{
      //Initiate applying the skill on the player caracter and removing the skill from the day list
      if(c.Xp >= skillOfTheDay[choice].XpCost){
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
        else if(skillOfTheDay[choice].GetType() == typeof(DefenseSkill)){
          c.SkillTrained.Add(new DefenseSkill((DefenseSkill)skillOfTheDay[choice]));
        }
        //Remove the skill so it cannot appear again 
        c.ExcludingSkills(skillOfTheDay[choice].Id);
        skillOfTheDay.Remove(skillOfTheDay[choice]);
        
        Console.ReadKey();
      }
      else{
        Console.WriteLine("Insulficient Xp.");
        Console.ReadKey();
      }
    }   

    return c;
  }

  public static bool StatsIncrease(ref Character chosen)
  {
    string choice = "";

    Console.WriteLine("Choose a status to improve: "); 
    Console.WriteLine("S - Str / A - Agi / I - Int / V - Vig");
    Console.Write("Choose (Any other key to go back):");
    choice = Console.ReadLine().ToUpper();        

    switch(choice)
    {
      case("S"):
        chosen.Str++;
        return true;

      case("A"):
        chosen.Agi++;
        return true;

      case("I"):
        chosen.Int++;
        return true;

      case("V"):
        chosen.Vig++;
        return true;

      default:
        Console.WriteLine("Error.");
        return false;
    }
  }
}