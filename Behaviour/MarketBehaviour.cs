using System;
using System.Collections.Generic;
using New_Arena_.Screens;

namespace New_Arena_.Behaviour
{
    class MarketBehaviour
    {
        public static void PotionShop(ref Character character, List<Potion> potionList)
        {
            int choicePotion;           
            
            do{
                choicePotion = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choicePotion > potionList.Count || choicePotion < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    PotionMarketScreen.PotionDisplay(potionList);
                }
            }while(choicePotion > potionList.Count || choicePotion < -1);            

            if(choicePotion != 0)
            {
                choicePotion--;

                if(potionList[choicePotion].Quantity > 0)
                {
                    character.AddingItens(potionList[choicePotion]);
                    potionList[choicePotion].Quantity--;
                    UpdateConsole.StaticMessage($"{potionList[choicePotion].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            }            
        }

        public static void WeaponShop(ref Character character, List<Weapon> weaponList)
        {
            int choiceWeapon;           
            
            do{
                choiceWeapon = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choiceWeapon > weaponList.Count || choiceWeapon < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    WeaponMarketScreen.DisplayWeapons(weaponList);
                }
            }while(choiceWeapon > weaponList.Count || choiceWeapon < -1);          

            if(choiceWeapon != 0)
            {
                choiceWeapon--;

                if(!weaponList[choiceWeapon].IsBrought)
                {
                    character.AddingItens(weaponList[choiceWeapon]);
                    weaponList[choiceWeapon].IsBrought = true;
                    UpdateConsole.StaticMessage($"{weaponList[choiceWeapon].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            }   
        }

        public static void ArmorShop(ref Character character, List<Armor> armorList)
        {
            int choiceArmor;           
            
            do{
                choiceArmor = InputCheck.IntCheck("Choice(0 To go back):", "Only Number:");

                if(choiceArmor > armorList.Count || choiceArmor < -1 )
                {
                    Console.Clear();
                    GameScreen.CharacterStats(character);
                    ArmorMarketScreen.DisplayArmor(armorList);
                }
            }while(choiceArmor > armorList.Count || choiceArmor < -1);    

            if(choiceArmor != 0)
            {
                choiceArmor--;

                if(!armorList[choiceArmor].IsBrought)
                {
                    character.AddingItens(armorList[choiceArmor]);
                    armorList[choiceArmor].IsBrought = true;
                    UpdateConsole.StaticMessage($"{armorList[choiceArmor].Name} was brought");
                }
                else
                    UpdateConsole.StaticMessage("No more of this item...");
            } 
        }
    }
}