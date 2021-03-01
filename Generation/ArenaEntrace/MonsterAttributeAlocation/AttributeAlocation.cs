using System; 


class AttributeAlocation
{
  public static Monster BalanceMonster(Monster monster)
  {
    Random random = new Random();
    int atributes = monster.Level * 3;
    int spend = 0;

    while(spend != atributes)
    {
      int chance = random.Next(0, 100); 

      if(chance >= 0 && chance <= 25)
      {
        monster.Str++;
        spend++;
      }

      if(chance >= 26 && chance <= 50)
      {
        monster.Int++;
        spend++;
      }

      if(chance >= 51 && chance <= 75)
      {
        monster.Agi++;
        spend++;
      }

      if(chance >= 76 && chance <= 100)
      {
        monster.Vig++;
        spend++;
      }
    }
    return monster;
  }

  public static Monster OffensiveMonster(Monster monster)
  {
    Random random = new Random();
    int atributes = monster.Level * 3;
    int spend = 0;

    while(spend != atributes)
    {
      int chance = random.Next(0, 100); 
      if(chance >= 0 && chance <= 60)
      {
        monster.Str++;
        spend++;
      }

      if(chance >= 61 && chance <= 70)
      {
        monster.Int++;
        spend++;
      }

      if(chance >= 71 && chance <= 85)
      {
        monster.Agi++;
        spend++;
      }

      if(chance >= 86 && chance <= 100)
      {
        monster.Vig++;
        spend++;
      }
    }
    return monster;
  }

  public static Monster DefensiveMonster(Monster monster)
  {
    Random random = new Random();
    int atributes = monster.Level * 3;
    int spend = 0;

    while(spend != atributes)
    {
      int chance = random.Next(0, 100); 
      if(chance >= 0 && chance <= 60)
      {
        monster.Vig++;
        spend++;
      }

      if(chance >= 61 && chance <= 70)
      {
        monster.Str++;
        spend++;
      }

      if(chance >= 71 && chance <= 85)
      {
        monster.Int++;
        spend++;
      }

      if(chance >= 86 && chance <= 100)
      {
        monster.Agi++;
        spend++;
      }
    }
    return monster;
  }
}