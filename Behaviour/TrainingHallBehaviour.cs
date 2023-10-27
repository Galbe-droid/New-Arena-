using System;
using System.Collections.Generic;

namespace New_Arena_.Behaviour
{
    class TrainingHallBehaviour
    {
        public static Character SkillToLearn(Character c){
            int choice;
            //Show the skill avaliable to learn for a day
            SkillTrainingScreen.SkillDisplay();
            
            Console.WriteLine();
            //Player Choice
            do{
              choice = InputCheck.ListLength("Skill Choice (0 to go back): ", ArenaBehaviour.skillOfTheDay.Count);
            }while((choice -1) > ArenaBehaviour.skillOfTheDay.Count || (choice -1) < -1);
        
            choice -= 1;
            
            if(choice == -1){
                
            }
            else{
                //Initiate applying the skill on the player caracter and removing the skill from the day list
                if(c.CheckXpCost(ArenaBehaviour.skillOfTheDay[choice].XpCost)){
                    Console.WriteLine("Skill: {0} Learned !", ArenaBehaviour.skillOfTheDay[choice].Name);

                    if(ArenaBehaviour.skillOfTheDay[choice].GetType() == typeof(BuffSkill)){
                        c.SkillTrained.Add(new BuffSkill((BuffSkill)ArenaBehaviour.skillOfTheDay[choice]));
                    }
                    else if(ArenaBehaviour.skillOfTheDay[choice].GetType() == typeof(DebuffSkill)){
                        c.SkillTrained.Add(new DebuffSkill((DebuffSkill)ArenaBehaviour.skillOfTheDay[choice]));
                    }
                    else if(ArenaBehaviour.skillOfTheDay[choice].GetType() == typeof(AttackSkill)){
                        c.SkillTrained.Add(new AttackSkill((AttackSkill)ArenaBehaviour.skillOfTheDay[choice]));
                    }
                    else if(ArenaBehaviour.skillOfTheDay[choice].GetType() == typeof(DefenseSkill)){
                        c.SkillTrained.Add(new DefenseSkill((DefenseSkill)ArenaBehaviour.skillOfTheDay[choice]));
                    }
                    //Remove the skill so it cannot appear again 
                    c.ExcludingSkills(ArenaBehaviour.skillOfTheDay[choice].Id);
                    ArenaBehaviour.skillOfTheDay.Remove(ArenaBehaviour.skillOfTheDay[choice]);

                    Console.ReadKey();
                }
            }   
        
            return c;
        }

        public static bool StatsIncrease(ref Character chosen)
        {
            int cost = chosen.StatusPrice();
            Console.WriteLine("Choose a status to improve: "); 
            Console.WriteLine($"S - Str / A - Agi / I - Int / V - Vig / Cost XP: {cost}");
            Console.Write("Choose (Any other key to go back):");            
            string choice = Console.ReadLine().ToUpper();  

            if(chosen.CheckXpCost(cost))
            {
                switch(choice)
                {
                    case"S":
                        chosen.Str++;
                        return true;

                    case"A":
                        chosen.Agi++;
                        return true;

                    case"I":
                        chosen.Int++;
                        return true;

                    case"V":
                        chosen.Vig++;
                        return true;

                    default:
                        Console.WriteLine("Error.");
                        return false;
                }
            }    

            return false;            
        }
    }
}