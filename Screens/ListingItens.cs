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
            int count = 0;
            Console.WriteLine($"=================Page {page}/{pageLimit} ====================");
            for(int i = 0; i < itemBag.Count; i ++){
                count++;
                int currentPage = (page - 1) * 3;
                currentPage += i;
                Console.WriteLine(count +" "+  itemBag[currentPage].ToString());
                Console.WriteLine("======================================");  
            } 
        }
    }
}