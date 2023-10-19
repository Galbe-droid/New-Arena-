using System;

abstract class PerTurnSkill : SkillBase{
    //if the skill is activated once (false) or it increases per turn (true)
    public bool IsActivedOnce {get; set;}
    //Stat Increase
    public int Qty {get; set;}
    //Keeps track of the buff so it can be safely removed and added in case the buff has a multiple stages 
    public int Tracked{get;set;}
    //Prevent Repetition 
    public bool IsUsed {get; set;}
    //Where to put the buff 
    public BuffType WhereToApply {get; set;}
    //For JSON
    public string WhereToApplyString {get; set;}

    public override int Applying(){          
        if(!this.IsActivedOnce){
            this.Tracked += this.Qty;
            return this.Qty;
        }else if (this.IsActivedOnce && !this.IsUsed){
            this.IsUsed = true;
            this.Tracked += this.Qty;
            return this.Qty;
        }else{
            return 0;
        }           
    }

    public int Removal(){
        return this.Tracked;
    }

    public BuffType ApplyingType(string type){
        if(type == "defense")
            return BuffType.Defense;

        if(type == "dodge")
        {
            this.Qty *= 1000;
            return BuffType.Dodge;
        }
            

        if(type == "attack")
            return BuffType.Attack;

        if(type == "hp")
            return BuffType.Hp;

        if(type == "mp")
            return BuffType.Mp;

        return BuffType.Defense;
    }
}