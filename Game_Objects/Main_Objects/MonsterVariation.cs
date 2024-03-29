using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects.Interface;

//MonsterVariation Exists as a base for variations of another monster that may come with diferent unique gimecks and passives 
class MonsterVariation : Monster, IRewardMultiply
{
    //Extra stats that come with the species
    public int VariationId { get; set; }
    public int ExtraStr {get; set;}
    public int ExtraInt {get; set;}
    public int ExtraAgi {get; set;}
    public int ExtraVig {get; set;}
    public float XpMultiply { get; set; }
    public float GoldMultiply { get; set; }

    public MonsterVariation(Monster monster, int variationId, float xpMultiply, float goldMultiply, string name, int extraStr, int extraInt, int extraAgi, int extraVig){
        Id = monster.Id;
        VariationId = variationId;
        Name = name + " " + monster.Name;

        Level = monster.Level;
        Type = monster.Type;
        SubType = monster.SubType;

        XpReward = monster.XpReward;
        GoldReward = monster.GoldReward;
        XpMultiply = xpMultiply;
        GoldMultiply = goldMultiply;

        Str = monster.Str;
        Int = monster.Int;
        Agi = monster.Agi;
        Vig = monster.Vig; 
        ExtraStr = extraStr;
        ExtraInt = extraInt;
        ExtraAgi = extraAgi;
        ExtraVig = extraVig;

        Defense = Vig/2;
        Dodge = 0 + (500 * Agi);
        Attack = Str;

        Health = 5 + (Vig * 5);
        Mana = 3 + (Int * 3);

        Damage = 0;
        ManaSpend = 0;
    
        Initiative = 0;
        ModDefense = 0;
        ModDodge = 0;
        ModAttack = 0;

        Dead = false;
    }

    public MonsterVariation(Monster monster, MonsterVariation monsterVariation){
        Id = monster.Id;
        VariationId = monsterVariation.VariationId;
        Name = monsterVariation.Name + " " + monster.Name;

        Level = monster.Level;
        Type = monster.Type;
        SubType = monster.SubType;

        XpReward = monster.XpReward;
        GoldReward = monster.GoldReward;
        XpMultiply = monsterVariation.XpMultiply;
        GoldMultiply = monsterVariation.GoldMultiply;

        Str = monster.Str;
        Int = monster.Int;
        Agi = monster.Agi;
        Vig = monster.Vig;
        ExtraStr = monsterVariation.ExtraStr;
        ExtraInt = monsterVariation.ExtraInt;
        ExtraAgi = monsterVariation.ExtraAgi;
        ExtraVig = monsterVariation.ExtraVig;

        Defense = Vig/2;
        Dodge = 0 + (500 * Agi);
        Attack = Str;

        Health = 5 + (Vig * 5);
        Mana = 3 + (Int * 3);

        Damage = 0;
        ManaSpend = 0;
    
        Initiative = 0;
        ModDefense = 0;
        ModDodge = 0;
        ModAttack = 0;

        SkillTrained = monsterVariation.SkillTrained;

        Dead = false;
    }

    public MonsterVariation(int variationId, string name, float xpMultiply, float goldMultiply, int extraStr, int extraInt, int extraAgi, int extraVig){
        Id = 9999;
        VariationId = variationId;
        Name = name;

        Level = 0;
        Type = Types.Prefab;
        SubType[0] = SubTypes.Prefab;

        XpReward = 0;
        GoldReward = 0;
        XpMultiply = xpMultiply;
        GoldMultiply = goldMultiply;

        Str = 0;
        Int = 0;
        Agi = 0;
        Vig = 0; 
        ExtraStr = extraStr;
        ExtraInt = extraInt;
        ExtraAgi = extraAgi;
        ExtraVig = extraVig;

        Defense = Vig/2;
        Dodge = 0 + (500 * Agi);
        Attack = Str;

        Health = 5 + (Vig * 5);
        Mana = 3 + (Int * 3);

        Damage = 0;
        ManaSpend = 0;
    
        Initiative = 0;
        ModDefense = 0;
        ModDodge = 0;
        ModAttack = 0;

        Dead = false;
    }

    public MonsterVariation(){
        Id = 9999;
        VariationId = 9999;
        Name = "";

        Level = 0;
        Type = Types.Prefab;
        SubType[0] = SubTypes.Prefab;
        
        XpReward = 0;
        GoldReward = 0;
        XpMultiply = 0;
        GoldMultiply = 0;

        Str = 0;
        Int = 0;
        Agi = 0;
        Vig = 0; 
        ExtraStr = 0;
        ExtraInt = 0;
        ExtraAgi = 0;
        ExtraVig = 0;

        Defense = Vig/2;
        Dodge = 0 + (500 * Agi);
        Attack = Str;

        Health = 5 + (Vig * 5);
        Mana = 3 + (Int * 3);

        Damage = 0;
        ManaSpend = 0;
    
        Initiative = 0;
        ModDefense = 0;
        ModDodge = 0;
        ModAttack = 0;

        Dead = false;
    }
}