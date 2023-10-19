namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IHaveWeapons
    {
        Weapon Weapon {get; set;}
        void InitializeWeapon();
    }
}