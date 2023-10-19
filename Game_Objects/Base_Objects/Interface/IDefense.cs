namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    public interface IDefense
    {
        int MinDefense {get; set;}
        int MaxDefense { get; set; }
        float MinDefenseModifier {get; set;}
        float MaxDefenseModifier {get; set;}
    }
}