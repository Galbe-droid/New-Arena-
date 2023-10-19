using System;
using New_Arena_.Configuration;

abstract class OneShotSkill : SkillBase{
    public int MinValue {get;set;}
    public int MaxValue {get;set;}
    public double Modifier {get;set;}
    public string StatString {get; set;}
    public StatsType Stat {get;set;}

    public int ApplyModifier(int stat){
        return (int)Math.Truncate(stat * this.Modifier);
    }

    public override int Applying(){

        int finalValue = ManagerRandom.GetThreadRandom().Next(this.MinValue, (this.MaxValue + 1));
        return finalValue;
    }  

    public StatsType ApplyingType(string type){
        if(type == "str")
            return StatsType.Str;

        if(type == "agi")
            return StatsType.Agi;

        if(type == "int")
            return StatsType.Inte;

        if(type == "vig")
            return StatsType.Vig;

        return StatsType.Agi;
    }
}