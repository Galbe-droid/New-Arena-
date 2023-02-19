using System;
using System.Collections.Generic;
using System.Linq;

class SkillListPreparation{
  public static List<SkillBase> ListOfSkillOfTheDay = new List<SkillBase>();

  public static List<SkillBase> SkillOfTheDay(List<SkillBase> SkillAvaliable, Character c){
    Random rand = new Random();

    List<int> IdsAvaliable = new List<int>();

    foreach(SkillBase s in SkillAvaliable){
      if(!c.SkillTrained.Exists(x => x.Id == s.Id)){
        IdsAvaliable.Add(s.Id);
      }      
    }

    if(IdsAvaliable.Count >= 5){
      do{
        int choice = rand.Next(-1, IdsAvaliable.Count);

        ListOfSkillOfTheDay.Add(SkillAvaliable.Find(x => x.Id == IdsAvaliable.ElementAt(choice)));

        ListOfSkillOfTheDay.Distinct().ToList();
        
      }while(ListOfSkillOfTheDay.Count == 5);

      return ListOfSkillOfTheDay;
    }
    else if(IdsAvaliable.Count < 5){
      do{
        int choice = rand.Next(-1, IdsAvaliable.Count);

        ListOfSkillOfTheDay.Add(SkillAvaliable.Find(x => x.Id == IdsAvaliable.ElementAt(choice)));

        ListOfSkillOfTheDay.Distinct().ToList();
        
      }while(ListOfSkillOfTheDay.Count == IdsAvaliable.Count);

      return ListOfSkillOfTheDay;
    }
    else{
      return ListOfSkillOfTheDay;
    }
  } 
}