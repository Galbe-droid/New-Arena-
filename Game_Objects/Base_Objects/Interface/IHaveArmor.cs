namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    public interface IHaveArmor
    {
        Armor Armor {get; set;}
        void InitializeArmor();
        void ChangeArmor(Armor newArmor);
        void RemoveArmor();
    }
}