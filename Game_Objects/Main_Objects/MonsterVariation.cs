using System;
using System.Collections.Generic;
using System.Linq;

//MonsterVariation Exists as a base for variations of another monster that may come with diferent unique gimecks and passives 
class MonsterVariation : Monster{
    //Extra stats that come with the species
    public int ExtraStr {get; set;}
    public int ExtraInt {get; set;}
    public int ExtraAgi {get; set;}
    public int ExtraVig {get; set;}

    public MonsterVariation(Monster monster, string name, int ExtraStr, int ExtraInt, int ExtraAgi, int ExtraVit){
        Id = monster.Id;
        Species = monster.Species;
        Name = name;

        Level = monster.Level;
        Type = monster.Type;
        SubType = monster.SubType;

        Str = monster.Str + ExtraStr;
        Int = monster.Int + ExtraInt;
        Agi = monster.Agi + ExtraAgi;
        Vig = monster.Vig + ExtraVig; 

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

    public void InitiateSkillToReceive(){
        List<SkillBase> ListOfMonsterSkill = SkillList.ListPerMonster[this.Id];

        foreach (SkillBase skill in ListOfMonsterSkill){
            if(this.Level >= skill.MinLevel)
                this.SkillTrained.Add(skill);
        }
    }
}