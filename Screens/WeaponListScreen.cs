using System;
using System.Collections.Generic;

namespace New_Arena_.Screens
{
    public class WeaponListScreen
    {
        public static void Display(int page, decimal pageLimit, List<ItemBase> weaponList)
        {
            int count = 0;
            Console.WriteLine($"=================Page {page}/{pageLimit} ====================");
            for(int i = 0; i < weaponList.Count; i ++){
                count++;
                int currentPage = (page - 1) * 3;
                currentPage += i;
                Console.WriteLine(count +" "+  weaponList[currentPage].ToString());
                Console.WriteLine("======================================");  
            } 
        }
    }
}