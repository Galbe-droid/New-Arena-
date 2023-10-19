using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;

class HpAndMpPotion : Potion, IHpAndMpManipulation, IUseInPlayer
{
    public int HpModifier { get; set; }
    public int MpModifier { get; set; }
    public bool UseOnPlayer { get; set; }
    public HpAndMpPotion()
    {
        Id = 9999;
        Name = "";
        Cost = 0;
        Rarity = 0;
        Quality = HpAndMpPotionType.Prefab;
        HpModifier = 0;
        MpModifier = 0;
        UseOnPlayer = true;
        Quantity = 1;
    }
    public HpAndMpPotion(int id, string name, int cost, int rarity, int recoveryHp, int recoveryMp)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Rarity = rarity;
        Quality = HpAndMpPotionType.Prefab;
        HpModifier = recoveryHp;
        MpModifier = recoveryMp;
        UseOnPlayer = true;
        Quantity = 1;
    }
    public HpAndMpPotion(HpAndMpPotion recoveryPotion)
    {
        Id = recoveryPotion.Id;
        Name = recoveryPotion.Name;
        Cost = recoveryPotion.Cost;
        Rarity = recoveryPotion.Rarity;
        Quality = HpAndMpPotionType.Prefab; 
        HpModifier = recoveryPotion.HpModifier;
        MpModifier = recoveryPotion.MpModifier;
        UseOnPlayer = recoveryPotion.UseOnPlayer;
        Quantity = 1;
    }
    public void Action<T>(ref T creature) where T : Creature
    {
        if(UseOnPlayer)
        {
            creature.Damage -= creature.Damage <= this.HpModifier ? creature.Damage : this.HpModifier;
            creature.ManaSpend -= creature.ManaSpend <= this.MpModifier ? creature.ManaSpend : this.MpModifier;
        }
        else{
            creature.Damage += creature.Damage >= creature.Health ? creature.Health : this.HpModifier;
            creature.ManaSpend += creature.ManaSpend >= creature.Mana ? creature.Mana : this.MpModifier;
        }        
    }
    public override string ToString()
    {
        string qualityString;
        if(this.Quality.ToString() == HpAndMpPotionType.Double_Dose.ToString())
            qualityString = "Double Dose";
        else if(this.Quality.ToString() == HpAndMpPotionType.Extra_Strong.ToString())
            qualityString = "Extra Strong";
        else
            qualityString = this.Quality.ToString();

        string playerOrEnemy = UseOnPlayer ? " " : "Applied On Monster";
        string hpAndMp = UseOnPlayer ? $"Hp: {this.HpModifier} Mp: {this.MpModifier}" : $"Hp: -{this.HpModifier} Mp: -{this.MpModifier}";
        
        return @$"Name: {this.Name} Quality: {qualityString} / {hpAndMp} x{this.Quantity} {playerOrEnemy}";
    }
}
