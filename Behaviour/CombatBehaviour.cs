using System;

//Controls player Attacks options, here is where the commands of the player happen
class CombatBehaviour
{
  //Basic Attack option, it receives the player attack, monster defender and monster dodge chance
  public static int AttackOption(int Attacker, int Defender, int DefenderDodge)
  {
    //Basic attacks generate from '' to +20 for the basic damage and defense
    Random rand = new Random();
    int TotalAtaque = rand.Next(0,21) + Attacker;
    int TotalDefense = rand.Next(0,21) + Defender;

    //Dodge Change uses 6 digits to make a 0.000 to 100.000% chance 
    //Ex. 2.5% of dodge is 2.500 if dodge change is less than Monster Dodge then the monster dodged the attack 
    int DodgeChance = rand.Next(0,100001);

    if(DodgeChance < DefenderDodge)
    {
      Console.WriteLine("Dodged");
      return 0;
    }
    else
    {
      //If Defense is equal of greater then attack then this keep informs the player 
      if(TotalDefense >= TotalAtaque)
      {
        Console.WriteLine("Defended");
        return 0;
      }
      else
      {
        //The method return the damage that the player made on the monster 
        return TotalAtaque - TotalDefense;
      }
    }
  }
}