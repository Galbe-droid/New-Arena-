namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IHaveArmor
    {
        Armor Armor {get; set;}
        void InitializeArmor();
        void ChangeArmor(Armor newArmor);
        void RemoveArmor();
    }
}