using System;

//Monster Behaviour in combate 
//Still a lot of work
class CombatMonsterBehaviour
{
  //Method receive Player defense, Player Dodge chance, Monster damage and monster type
  public static int MonsterChoice(int charDefense, int charDodge, int monsterDamage, Types monsterType, string charName)
  {
    //Depending of the monster type it will be more inclined to use certain actions 
    if(monsterType == Types.Offensive)
    {
      
      return MonsterAttack(charDefense, charDodge, monsterDamage, charName);
    }
    else if(monsterType == Types.Defensive)
    {
      return MonsterAttack(charDefense, charDodge, monsterDamage, charName);
    }
    else if(monsterType == Types.Balance)
    {
      return MonsterAttack(charDefense, charDodge, monsterDamage, charName);
    }
    else{
      Console.WriteLine("An error occur");
      return 0;
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
        Console.WriteLine(charName + " Hit !!");
        Console.WriteLine("Damage: - " + (TotalAttack - TotalDefense));
        return TotalAttack - TotalDefense;
      }
    }
  }
}