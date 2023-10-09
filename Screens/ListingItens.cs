using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Game_Objects.Base_Objects.Interface;

namespace New_Arena_.Screens
{
    class ListingItens
    {
        public static void Screens(int page, decimal pageLimit, List<ItemBase> itemBag)
        {
            Console.WriteLine($"=================Page {page}/{pageLimit} ====================");
            for(int i = 0; i < itemBag.Count; i ++){
                int currentPage = (page - 1) * 3;
                currentPage += i;

                Consumable item = new((Consumable)itemBag.ElementAt(currentPage));

                Console.WriteLine($"{i + 1} - Name:{item.Name} - Type:{item.GetType()} - Hp: {item.RecoveryHp} - Mp: {item.RecoveryMp}");
                Console.WriteLine("======================================");  
            } 
        }
    }
}