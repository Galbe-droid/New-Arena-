using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Screens;

namespace New_Arena_.Menus
{
    class MarketMenu
    {
        public static void MarketDecision(ref Character chosen)
        {
            string choice;
            
            do
            {
                GameScreen.CharacterStats(chosen);

                Console.WriteLine("Inside the Market");
                Console.WriteLine("P - Potion Market /// W - Weapon Market /// A - Armor Market");
                Console.Write("Choose (X to go back):");
                choice = Console.ReadLine().ToUpper();

                switch(choice)
                {
                    case "P":
                        PotionMarketScreen.PotionDisplay();
                        MarketBehaviour.PotionShop(ref chosen);
                        Console.Clear();
                        break;

                    case "W":
                        WeaponMarketScreen.DisplayWeapons();
                        MarketBehaviour.WeaponShop(ref chosen);
                        Console.Clear();
                        break;

                    case "A":
                        ArmorMarketScreen.DisplayArmor();
                        MarketBehaviour.ArmorShop(ref chosen);
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