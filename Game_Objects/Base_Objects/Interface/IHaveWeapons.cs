namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IHaveWeapons
    {
        Weapon Weapon {get; set;}
        void InitializeWeapon();
        void ChangeWeapon(Weapon newWeapon);
        void RemoveWeapon();
    }
}