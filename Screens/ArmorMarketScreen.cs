using System;
using System.Collections.Generic;

namespace New_Arena_.Screens
{
    public class ArmorMarketScreen
    {
        public static void DisplayArmor(List<Armor> armorList)
        {
            int count = 0;
            Console.WriteLine("============Weapons==============");

            foreach (Armor armor in armorList)
            {
                if(!armor.IsBrought)
                {
                    Console.WriteLine(count + 1 + $" - Name: {armor.Name} / Damage: {armor.MinDefense}-{armor.MaxDefense} Str Mod: {Math.Truncate(armor.MinDefenseModifier*100)}%-{Math.Truncate(armor.MaxDefenseModifier*100)}% / Quality: {armor.Quality}  Cost: {armor.Cost}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(count + 1 + $" - Name: {armor.Name} / Damage: {armor.MinDefense}-{armor.MaxDefense} Str Mod: {Math.Truncate(armor.MinDefenseModifier*100)}%-{Math.Truncate(armor.MaxDefenseModifier*100)}% / Quality: {armor.Quality}  Cost: {armor.Cost}");
                    Console.ResetColor();
                }

                count++;
            }
        }
    }
}