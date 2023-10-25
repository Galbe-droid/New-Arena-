using System;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class StatusPotion : Potion, IStatusManipualtions, IUseInPlayer
{
    public string BuffString { get; set; }
    public BuffType BuffManipulated { get; set; }
    public int StatusQuantity { get; set; }
    public int TurnMax { get; set; }
    public int Turn { get; set; }
    public bool UseOnPlayer { get; set; }
    public bool IsActive {get; set;}
    public new StatusPotionType Quality { get; set; }
    public StatusPotion(int id, string name, int cost, int rarity, string buffString, int statusQuantity, int turnMax, bool useOnPlayer)
    {
        this.Id = id;
        this.Name = name;
        this.Cost = cost;
        this.Rarity = rarity;
        this.Quality = StatusPotionType.Poorly; 
        this.BuffString = buffString;
        this.StatusQuantity = statusQuantity;
        this.BuffManipulated = ApplyingType();
        this.TurnMax = turnMax;
        this.Turn = 0;
        this.UseOnPlayer = useOnPlayer;
        this.Quantity = 1;
        this.IsActive = false;
    }
    public StatusPotion(StatusPotion statPotion)
    {
        this.Id = statPotion.Id;
        this.Name = statPotion.Name;
        this.Cost = statPotion.Cost;
        this.Rarity = statPotion.Rarity;
        this.Quality = StatusPotionType.Poorly; 
        this.BuffString = statPotion.BuffString;        
        this.StatusQuantity = statPotion.StatusQuantity;
        this.BuffManipulated = statPotion.BuffManipulated;
        this.TurnMax = statPotion.TurnMax;
        this.Turn = 0;
        this.UseOnPlayer = statPotion.UseOnPlayer;
        this.Quantity = 1;
        this.IsActive = false;
    }
    public StatusPotion()
    {
        this.Id = 9999;
        this.Name = "";
        this.Cost = 0;
        this.Rarity = 0;
        this.Quality = StatusPotionType.Poorly; 
        this.BuffString = "";
        this.BuffManipulated = BuffType.Attack;
        this.StatusQuantity = 0;
        this.TurnMax = 0;
        this.Turn = 0;
        this.UseOnPlayer = false;
        this.Quantity = 1;
        this.IsActive = false;
    }
    public int Applying()
    {
        return this.StatusQuantity;
    }
    public void TurnCount()
    {
        this.Turn++;
    }
    public BuffType ApplyingType()
    {
        if(this.BuffString == "defense")
        return BuffType.Defense;
        if(this.BuffString == "dodge"){
            this.StatusQuantity *= 1000;
            return BuffType.Dodge;
        }               
        if(this.BuffString == "attack")
            return BuffType.Attack;
        return BuffType.Defense;
    }
    public override string ToString()
    {
        string qualityString;
        if(this.Quality.ToString() == StatusPotionType.Double_Dose.ToString())
            qualityString = "Double Dose";
        else if(this.Quality.ToString() == StatusPotionType.Extra_Strong.ToString())
            qualityString = "Extra Strong";
        else if(this.Quality.ToString() == StatusPotionType.Long_Duration.ToString())
            qualityString = "Long Duration";
        else
            qualityString = this.Quality.ToString();


        string playerOrEnemy = UseOnPlayer ? "" : "Applied On Monster";
        string dodgePoints = this.BuffString == "dodge" ? Convert.ToString(this.StatusQuantity/1000) : Convert.ToString(this.StatusQuantity);
        string negativeQuantity = UseOnPlayer ? $"Qty: {dodgePoints}" : $"Qty: -{dodgePoints}";
        return @$"Name: {this.Name} Quality: {qualityString} / Stat Affected: {this.BuffManipulated} {negativeQuantity} Turns: {this.TurnMax} x{this.Quantity} {playerOrEnemy}";
    }
}
