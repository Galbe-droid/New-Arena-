using System;
using New_Arena_.Game_Objects.Base_Objects.Interface;

public class Armor : ItemBase, IDefense
{
    public int MinDefense { get; set; }
    public int MaxDefense { get; set; }
    public float MinDefenseModifier { get; set; }
    public float MaxDefenseModifier { get; set; }
    public bool IsBrought {get; set;}
    public Armor(int id, string name, int cost, int rarity, int minDefense, int maxDefense, float minDefenseModifier, float maxDefenseModifier)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Rarity = rarity; 
        Quality = WeaponType.Prefab;
        MinDefense = minDefense;
        MaxDefense = maxDefense;
        MinDefenseModifier = minDefenseModifier;
        MaxDefenseModifier = maxDefenseModifier;
        IsBrought = false;
    }
    public Armor(Armor armor)
    {
        Id = armor.Id;
        Name = armor.Name;
        Cost = armor.Cost;
        Rarity = armor.Rarity; 
        Quality = armor.Quality;
        MinDefense = armor.MinDefense;
        MaxDefense = armor.MaxDefense;
        MinDefenseModifier = armor.MinDefenseModifier;
        MaxDefenseModifier = armor.MaxDefenseModifier;
        IsBrought = false;
    }       
    public Armor()
    {
        Id = 0;
        Name = "";
        Cost = 0;
        Rarity = 0; 
        Quality = WeaponType.Prefab;
        MinDefense = 0;
        MaxDefense = 0;
        MinDefenseModifier = 0;
        MaxDefenseModifier = 0;
        IsBrought = false;
    }         
    public override string ToString()
    {
        return $"Name: {Name} Quality: {Quality} / Defense: {MinDefense}-{MaxDefense} / Mod: {Math.Truncate(MinDefenseModifier*100)}%-{Math.Truncate(MaxDefenseModifier*100)}%";
    }
}