using System;
using System.Collections.Generic;
using New_Arena_.Screens;

namespace New_Arena_.Behaviour
{
    class MarketBehaviour
    {
        public static void PotionShop(ref Character character)
        {
            int choicePotion;           
            
            do{
                choicePotion = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choicePotion > ArenaBehaviour.potionsOfTheDay.Count || choicePotion < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    PotionMarketScreen.PotionDisplay();
                }
            }while(choicePotion > ArenaBehaviour.potionsOfTheDay.Count || choicePotion < -1);            

            if(choicePotion != 0)
            {
                choicePotion--;

                if(ArenaBehaviour.potionsOfTheDay[choicePotion].Quantity > 0)
                {
                    character.AddingItens(ArenaBehaviour.potionsOfTheDay[choicePotion]);
                    ArenaBehaviour.potionsOfTheDay[choicePotion].Quantity--;
                    UpdateConsole.StaticMessage($"{ArenaBehaviour.potionsOfTheDay[choicePotion].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            }            
        }

        public static void WeaponShop(ref Character character)
        {
            int choiceWeapon;           
            
            do{
                choiceWeapon = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choiceWeapon > ArenaBehaviour.weaponsOfTheDay.Count || choiceWeapon < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    WeaponMarketScreen.DisplayWeapons();
                }
            }while(choiceWeapon > ArenaBehaviour.weaponsOfTheDay.Count || choiceWeapon < -1);          

            if(choiceWeapon != 0)
            {
                choiceWeapon--;

                if(!ArenaBehaviour.weaponsOfTheDay[choiceWeapon].IsBrought)
                {
                    character.AddingItens(ArenaBehaviour.weaponsOfTheDay[choiceWeapon]);
                    ArenaBehaviour.weaponsOfTheDay[choiceWeapon].IsBrought = true;
                    UpdateConsole.StaticMessage($"{ArenaBehaviour.weaponsOfTheDay[choiceWeapon].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            }   
        }

        public static void ArmorShop(ref Character character)
        {
            int choiceArmor;           
            
            do{
                choiceArmor = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choiceArmor > ArenaBehaviour.armorOfTheDay.Count || choiceArmor < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    ArmorMarketScreen.DisplayArmor();
                }
            }while(choiceArmor > ArenaBehaviour.armorOfTheDay.Count || choiceArmor < -1);    

            if(choiceArmor != 0)
            {
                choiceArmor--;

                if(!ArenaBehaviour.armorOfTheDay[choiceArmor].IsBrought)
                {
                    character.AddingItens(ArenaBehaviour.armorOfTheDay[choiceArmor]);
                    ArenaBehaviour.armorOfTheDay[choiceArmor].IsBrought = true;
                    UpdateConsole.StaticMessage($"{ArenaBehaviour.armorOfTheDay[choiceArmor].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            } 
        }
    }
}