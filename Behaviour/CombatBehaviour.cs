using System;

//Controls player Attacks options, here is where the commands of the player happen
class CombatBehaviour
{
  //Basic Attack option, it receives the player attack, monster defender and monster dodge chance
  public static int AttackOption(int Attacker, int Defender, int DefenderDodge)
  {
    //Basic attacks generate from '' to +20 for the basic damage and defense
    Random rand = new Random();
    int TotalAttack = rand.Next(0,21) + Attacker;
    int TotalDefense = rand.Next(0,21) + Defender;

    //Dodge Change uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500 if dodge change is less than Monster Dodge then the monster dodged the attack 
    int DodgeChance = rand.Next(0,100001);

    if(DodgeChance < DefenderDodge)
    {
      Console.WriteLine("Monster Dodged");
      return 0;
    }
    else
    {
      //If Defense is equal of greater then attack then this keep informs the player 
      if(TotalDefense >= TotalAttack)
      {
        Console.WriteLine("Monster Defended");
        return 0;
      }
      else
      {
        //The method return the damage that the player made on the monster 
        Console.WriteLine("Monster Damage !!");
        Console.WriteLine("Damage: -" + (TotalAttack - TotalDefense));
        return TotalAttack - TotalDefense;
      }
    }
  }

  //Executes a basic Defense Movement, it increases the Defense for 2 turns
  public static void DefensiveChoice(ref Character c){
    Console.WriteLine(c.Name + " is assuming a Defensive stance");
    //It searches if the skill is already activated, if it is then it time is reset
    foreach(BuffSkill b in c.SkillTrained){
      if(b.Name == "Defensive Position" && !c.BuffAndDebuffActive.Exists(x => x.Name == "Defensive Position")){
        c.BuffAndDebuffActive.Add(new BuffSkill(b){}); 
      }
      else{
        if(c.BuffAndDebuffActive.Exists(x => x.Name == "Defensive Position")){
          c.BuffAndDebuffActive.Find(x => x.Name == "Defensive Position").Turns = 0;
        }
      }
    }
  }

  public static void SkillChoice(ref Character c){
    int count = 0; 
    int choice = 0;

    foreach(BuffSkill buff in c.SkillTrained){
      if(s.Id != 0){
        if(s.GetType() == typeof(BuffSkill)){
          Console.WriteLine($"{count+1} Name: {s.Name} || Type:{s.GetType()} \n
                          Description: {s.Desc} \n
                          Affects: {(BuffSkill)s.WhereToApply}");
          count++;
        }
        else if(s.GetType() == typeof(DebuffSkill)){
          Console.WriteLine($"{count+1} Name: {s.Name} || Type:{s.GetType()} \n
                          Description: {s.Desc} \n
                          Affects: {(DebuffSkill)s.WhereToApply}");
        }
        else{
          Console.WriteLine($"{count+1} Name: {s.Name} || Type:{s.GetType()} \n
                          Description: {s.Desc} \n
                          Damage: ({(AttackSkill)s.MinDamage} ~ {(AttackSkill)s.MaxDamage}) * {(AttackSkill)s.Modifier}({(AttackSkill)s.PlayerStat})");
          count++;
        }
      }
    }
  }
}