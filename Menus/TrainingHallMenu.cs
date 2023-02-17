using System; 
using System.Collections.Generic;

class TrainingHallMenu{
  public static Character TrainingDecision(ref Character chosen, List<SkillBase>SkillList){
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

  public static Character SkillForToday(ref Character c, List<SkillBase>SkillList){
   List<SkillBase> ListOfAvaliableSkills = new List<SkillBase>();

    foreach(SkillBase s in SkillList){
      if(!c.SkillTrained.Exists(x => x.Id == s.Id)){
        ListOfAvaliableSkills.Add(s);
      }
    }

    return c;
  }

  public static Character SkillTraining(ref Character c, SkillBase skillChoice){
    if(skillChoice.GetType() == typeof(DebuffSkill)){
      c.SkillTrained.Add(new DebuffSkill((DebuffSkill)skillChoice));
    }
    else if(skillChoice.GetType() == typeof(BuffSkill)){
      c.SkillTrained.Add(new BuffSkill((BuffSkill)skillChoice));
    }

    return c;
  }
}

