using System;
using New_Arena_.Game_Objects.Base_Objects.Interface;

public class Weapon : ItemBase, IDamage
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public float MinDamageModifier { get; set; }
    public float MaxDamageModifier { get; set; }
    public bool IsBrought {get; set;}
    public Weapon(int id, string name, int cost, int rarity, int minDamage, int maxDamage, float minDamamgeModifier, float maxDamageModifier)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Rarity = rarity; 
        Quality = WeaponType.Prefab;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        MinDamageModifier = minDamamgeModifier;
        MaxDamageModifier = maxDamageModifier;
        IsBrought = false;
    }
    public Weapon(Weapon weapon)
    {
        Id = weapon.Id;
        Name = weapon.Name;
        Cost = weapon.Cost;
        Rarity = weapon.Rarity; 
        Quality = weapon.Quality;
        MinDamage = weapon.MinDamage;
        MaxDamage = weapon.MaxDamage;
        MinDamageModifier = weapon.MinDamageModifier;
        MaxDamageModifier = weapon.MaxDamageModifier;
        IsBrought = false;
    }
    public Weapon()
    {
        Id = 0;
        Name = "";
        Cost = 0;
        Rarity = 0; 
        Quality = WeaponType.Prefab;
        MinDamage = 0;
        MaxDamage = 0;
        MinDamageModifier = 0;
        MaxDamageModifier = 0;
        IsBrought = false;
    }
    public override string ToString()
    {
        return $"Name: {Name} Quality: {Quality} / Damage: {MinDamage}-{MaxDamage} / Mod: {Math.Truncate(MinDamageModifier*100)}%-{Math.Truncate(MaxDamageModifier*100)}%";
    }
}
