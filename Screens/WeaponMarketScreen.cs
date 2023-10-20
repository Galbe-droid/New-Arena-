using System;
using System.Collections.Generic;
using New_Arena_.Game_Objects.Base_Objects;

namespace New_Arena_.Screens
{
    public class WeaponMarketScreen
    {
        public static void DisplayWeapons()
        {
            int count = 0;
            Console.WriteLine("============Weapons==============");

            foreach (Weapon weapon in ArenaBehaviour.weaponsOfTheDay)
            {
                if(!weapon.IsBrought)
                {
                    Console.WriteLine(count + 1 + $" - Name: {weapon.Name} / Damage: {weapon.MinDamage}-{weapon.MaxDamage} Str Mod: {Math.Truncate(weapon.MinDamageModifier*100)}%-{Math.Truncate(weapon.MaxDamageModifier*100)}% / Quality: {weapon.Quality}  Cost: {weapon.Cost}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(count + 1 + $" - Name: {weapon.Name} / Damage: {weapon.MinDamage}-{weapon.MaxDamage} Str Mod: {Math.Truncate(weapon.MinDamageModifier*100)}%-{Math.Truncate(weapon.MaxDamageModifier*100)}% / Quality: {weapon.Quality}  Cost: {weapon.Cost}");
                    Console.ResetColor();
                }

                count++;
            }
        }
    }
}