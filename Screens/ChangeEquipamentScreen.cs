using System;

namespace New_Arena_.Screens
{
    class ChangeEquipamentScreen
    {
        public static void PlayerEquipamentDisplay(Character character)
        {
            Console.WriteLine("Weapon: ( " + character.Weapon.ToString() + " )");
            Console.WriteLine("================================================");
            Console.WriteLine("Armor: ( " + character.Armor.ToString() + " )");
            Console.WriteLine("================================================");
        }
    }
}