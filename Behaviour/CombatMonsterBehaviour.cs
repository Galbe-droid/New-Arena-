using System;

//Monster Behaviour in combate 
//Still a lot of work
class CombatMonsterBehaviour
{
  //Method receive Player defense, Player Dodge chance, Monster damage and monster type
  public static Character MonsterChoice(ref Character c, ref Monster m )
  {
    //Depending of the monster type it will be more inclined to use certain actions 
    Random rand = new Random();
    int choice = rand.Next(0,101);
    
    if(m.Type == Types.Offensive)
    { 
      if((choice >= 0 && choice <= 75)){
        c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
        return c;
      }
      else{
        if(!m.BuffAndDebuffActive.Exists(x => x.Id == 0)){
          MonsterDefense(ref m);
          return c;
        }
        //Prevent Monsters from Repeat Defende Every Time 
        else if(m.BuffAndDebuffActive.Exists(x => x.Id == 0) && m.BuffAndDebuffActive.Find(x => x.Id == 0).Turns > 2){
          MonsterDefense(ref m);
          return c;
        }
        else{
          c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
          return c;
        }
      }      
    }
    else if(m.Type  == Types.Defensive)
    {
      if((choice >= 0 && choice <= 25)){
        c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
        return c;
      }
      else{
        if(!m.BuffAndDebuffActive.Exists(x => x.Id == 0)){
          MonsterDefense(ref m);
          return c;
        }
        else if(m.BuffAndDebuffActive.Exists(x => x.Id == 0) && m.BuffAndDebuffActive.Find(x => x.Id == 0).Turns > 2){
          MonsterDefense(ref m);
          return c;
        }
        else{
          c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
          return c;
        }
      } 
    }
    else if(m.Type  == Types.Balance)
    {
      if((choice >= 0 && choice <= 50)){
        c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
        return c;
      }
      else{
        if(!m.BuffAndDebuffActive.Exists(x => x.Id == 0)){
          MonsterDefense(ref m);
          return c;
        }
        else if(m.BuffAndDebuffActive.Exists(x => x.Id == 0) && m.BuffAndDebuffActive.Find(x => x.Id == 0).Turns > 2){
          MonsterDefense(ref m);
          return c;
        }
        else{
          c.Damage += MonsterAttack(c.TotalDefense(), c.TotalDodge(), m.TotalAttack(), c.Name);
          return c;
        }
      }
    }
    else{
      Console.WriteLine("An error occur");
      return c;
    }
  }

  public static int MonsterAttack(int charDefense, int charDodge, int monsterDamage, string charName){
    //Basic attacks generate from '' to +20 for the basic damage and defense
    Random rand = new Random();
    int TotalAttack = rand.Next(0,21) + monsterDamage;
    int TotalDefense = rand.Next(0,21) + charDefense;

    //Dodge Change uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500 if dodge change is less than Monster Dodge then the monster dodged the attack 
    int DodgeChance = rand.Next(0,100001);

    if(DodgeChance < charDodge)
    {
      Console.WriteLine(charName + " Dodged");
      return 0;
    }
    else
    {
      //If Defense is equal of greater then attack then this keep informs the player 
      if(TotalDefense >= TotalAttack)
      {
        Console.WriteLine(charName + " Defended");
        return 0;
      }
      else
      {
        //The method return the damage that the player made on the monster
        Console.WriteLine(charName + " Damage !!");
        Console.WriteLine("Damage: - " + (TotalAttack - TotalDefense));
        return TotalAttack - TotalDefense;
      }
    }
  }

  //Allows monsters to use the Defensive Position
  public static void MonsterDefense(ref Monster m){
    Console.WriteLine(m.Name + " is Assuming a Defensive Position");
    
    if(!m.BuffAndDebuffActive.Exists(x => x.Id == 0)){
      m.BuffAndDebuffActive.Add(new BuffSkill((BuffSkill)m.SkillTrained.Find(x => x.Id == 0)){});
    }else{
      m.BuffAndDebuffActive.Find(x => x.Id == 0).Turns = 0;
    }
  }
}