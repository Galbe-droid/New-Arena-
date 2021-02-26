using System;
using System.Collections.Generic;

class MonsterList{

  public static List<Monster> Monsters = new List<Monster>();

  //Monster Prefabs public Monster(int id, string name, int level, Type type, int str, int inte, int agi, int vig)
  public static void AddMonsters()
  {
    Monsters.Add(new Monster(0, "Slime", 1, Types.Prefab, 3, 3, 3, 3));
    Monsters.Add(new Monster(1, "Spider", 1, Types.Prefab, 3, 1, 4, 4));
  }
 
}