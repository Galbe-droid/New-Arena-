//Monster Types is used to make the decisions of the monster in combat 
enum Types
{
  Prefab,
  Offensive,
  Defensive,
  Balance
}

//Subtypes controls the use of regular options or skill options
//Brutal and survival uses regular attack and defense 
//Tatical and Support uses skills 
enum SubTypes
{
  Prefab,
  //Regular attacks or skills
  Brute,
  Tatical,
  //Support or Healer
  Support,
  Survival
}