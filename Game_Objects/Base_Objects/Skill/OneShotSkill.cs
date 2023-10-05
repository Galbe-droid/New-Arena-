using System;

abstract class OneShotSkill : SkillBase{
    public int MinValue {get;set;}

    public int MaxValue {get;set;}

    public double Modifier {get;set;}

    public StatsType Stat {get;set;}

    public int ApplyModifier(int stat){
        return (int)Math.Truncate(stat * this.Modifier);
    }

    public override int Applying(){
        Random rand = new Random();

        int finalValue = rand.Next(this.MinValue, (this.MaxValue + 1));
        return finalValue;
    }  
}