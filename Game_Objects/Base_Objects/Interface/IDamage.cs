namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IDamage
    {
        int MinDamage {get; set;}
        int MaxDamage { get; set; }
        float MinDamageModifier {get; set;}
        float MaxDamageModifier {get; set;}
    }
}