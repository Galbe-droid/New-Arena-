using System; 

//Creating a monster for the player to choose from 
//This code places the points on the monster
//Depending of the monter type it will focus on some stats 
class AttributeAlocation
{
  //Generate a Balace Type Monster
  public static Monster BalanceMonster(Monster monster)
  {
    Random random = new Random();
    //Quatity of points to be allocated 
    int atributes = monster.Level * 3;

    while(atributes == 0)
    {
      int chance = random.Next(0, 100); 

      if(chance >= 0 && chance <= 25)
      {
        monster.Str++;
        atributes--;
      }

      if(chance >= 26 && chance <= 50)
      {
        monster.Int++;
        atributes--;
      }

      if(chance >= 51 && chance <= 75)
      {
        monster.Agi++;
        atributes--;
      }

      if(chance >= 76 && chance <= 100)
      {
        monster.Vig++;
        atributes--;
      }
    }
    return monster;
  }
  //Generate a Offensive Monster More focus on STR less on INT
  public static Monster OffensiveMonster(Monster monster)
  {
    Random random = new Random();
    int atributes = monster.Level * 3;

    while(atributes == 0)
    {
      int chance = random.Next(0, 100); 
      if(chance >= 0 && chance <= 60)
      {
        monster.Str++;
        atributes--;
      }

      if(chance >= 61 && chance <= 70)
      {
        monster.Int++;
        atributes--;
      }

      if(chance >= 71 && chance <= 85)
      {
        monster.Agi++;
        atributes--;
      }

      if(chance >= 86 && chance <= 100)
      {
        monster.Vig++;
        atributes--;
      }
    }
    return monster;
  }

  //Generate a Defensive Monster more focus on VIG lass on STR
  public static Monster DefensiveMonster(Monster monster)
  {
    Random random = new Random();
    int atributes = monster.Level * 3;

    while(atributes == 0)
    {
      int chance = random.Next(0, 100); 
      if(chance >= 0 && chance <= 60)
      {
        monster.Vig++;
        atributes--;
      }

      if(chance >= 61 && chance <= 70)
      {
        monster.Str++;
        atributes--;
      }

      if(chance >= 71 && chance <= 85)
      {
        monster.Int++;
        atributes--;
      }

      if(chance >= 86 && chance <= 100)
      {
        monster.Agi++;
        atributes--;
      }
    }
    return monster;
  }
}