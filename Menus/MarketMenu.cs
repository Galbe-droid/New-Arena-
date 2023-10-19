using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Screens;

namespace New_Arena_.Menus
{
    class MarketMenu
    {
        public static void MarketDecision(ref Character chosen, List<Potion> potionList, List<Weapon> weaponList, List<Armor> armorList)
        {
            string choice;
            
            do
            {
                GameScreen.CharacterStats(chosen);

                Console.WriteLine("Inside the Training Hall");
                Console.WriteLine("P - Potion Market /// W - Weapon Market /// A - Armor Market");
                Console.Write("Choose (X to go back):");
                choice = Console.ReadLine().ToUpper();

                switch(choice)
                {
                    case "P":
                        PotionMarketScreen.PotionDisplay(potionList);
                        MarketBehaviour.PotionShop(ref chosen, potionList);
                        Console.Clear();
                        break;

                    case "W":
                        WeaponMarketScreen.DisplayWeapons(weaponList);
                        MarketBehaviour.WeaponShop(ref chosen, weaponList);
                        Console.Clear();
                        break;

                    case "A":
                        ArmorMarketScreen.DisplayArmor(armorList);
                        MarketBehaviour.ArmorShop(ref chosen, armorList);
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid.");
                        Console.Clear();
                        break;
                }
            
            }while(choice.ToUpper() != "X");
            Console.Clear();
        }
    }
}