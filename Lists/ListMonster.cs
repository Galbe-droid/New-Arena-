using System;
using System.Collections.Generic;

//Prefab mosters, this list are load in the beginning and used inseide de the game to produce the monster that the player fights 
class MonsterList{

  public static List<Monster> Monsters = new List<Monster>();
  public static Dictionary<int, List<MonsterVariation>> ListOfMonsterVariation = new Dictionary<int, List<MonsterVariation>>();

  public static List<MonsterVariation> SlimeVariation = new List<MonsterVariation>();
  public static List<MonsterVariation> SpiderVariation = new List<MonsterVariation>();
  public static List<MonsterVariation> GolemVariation = new List<MonsterVariation>();

  //Monster Prefabs public Monster(int id, string name, int level, Type type, int str, int inte, int agi, int vig)
  //This are the base of the monster species, this objects are generate and then combine with the specific monster class 
  //Monster Variations Require (int variationId, string name, int ExtraStr, int ExtraInt, int ExtraAgi, int ExtraVig)
  public static void AddMonsters()
  {
    Monsters.Add(new Monster(0, "Slime", 1, Types.Prefab, 3, 3, 3, 3));
    Monsters.Add(new Monster(1, "Spider", 1, Types.Prefab, 3, 1, 4, 4));
    Monsters.Add(new Monster(2, "Golem", 1, Types.Prefab, 5, 1, 1, 7));

    SlimeVariation.Add(new MonsterVariation(0, "Unstable", 0, 1, 1, 0));
    SlimeVariation.Add(new MonsterVariation(1, "Resistent", 0, 0, 0, 3));
    SlimeVariation.Add(new MonsterVariation(2, "Spiked", 3, 0, 0, 1));

    SpiderVariation.Add(new MonsterVariation(0, "Poisonous", 0, 2, 1, 0));
    SpiderVariation.Add(new MonsterVariation(1, "Tiny", 0, 1, 3, 0));
    SpiderVariation.Add(new MonsterVariation(2, "Giant", 2, 0, 0, 2));

    GolemVariation.Add(new MonsterVariation(0, "Incomplete", 1, 0, 0, 1));
    GolemVariation.Add(new MonsterVariation(1, "Helper", 0, 1, 0, 2));
    GolemVariation.Add(new MonsterVariation(2, "Armored", 2, 0, 0, 2));
  }

  public static void CreateMonsterVariationList(){
    ListOfMonsterVariation.Add(0, SlimeVariation);
    ListOfMonsterVariation.Add(1, SpiderVariation);
    ListOfMonsterVariation.Add(2, GolemVariation);
  }
}