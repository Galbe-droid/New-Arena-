using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Arena_.Behaviour
{
    class InnBehaviour
    {
        public static void InnFunction(ref Character chosen, List<Food> foodtable)
        {      
            InnScreen.FoodDisplay(foodtable);

            FoodConsuption(ref chosen, foodtable);

            Console.Clear();

            GameScreen.CharacterStats(chosen);

            InnScreen.FoodDisplay(foodtable);

            TakeFood(ref chosen, foodtable);

            Console.Clear();
        }
        private static void FoodConsuption(ref Character chosen, List<Food> foodTable)
        {
            Console.WriteLine("Ready To Eat");
            int choiceEat = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
            int[] acceptedOptions = {1,2,3,4,5};

            if(choiceEat != 0){
              Food foodChoice = foodTable[choiceEat];

            do
            {
              Console.WriteLine("Food eaten!");
              foodChoice.Action(ref chosen);
              foodTable[choiceEat--].Quantity --;
              Console.ReadKey();
            }while(!acceptedOptions.Contains(choiceEat));    
            }      
        }
        private static void TakeFood(ref Character chosen, List<Food> foodTable)
        {
          int choiceTake = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
          int[] acceptedOptions = {1,2,3,4,5};
        
          if(choiceTake != 0)
          {
            Food foodTake;
            do
            {
              foodTake = foodTable[choiceTake--];
        
              if(foodTake.Quantity == 0)
              {
                UpdateConsole.StaticMessage("Food Already Eaten ");
                Console.ReadKey();
                Console.Clear();
                GameScreen.CharacterStats(chosen);
                InnScreen.FoodDisplay(foodTable);
                choiceTake = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
              }
              else
              {
                chosen.AddingItens(foodTake);
              }
        
            }while(!acceptedOptions.Contains(choiceTake) || foodTake.Quantity == 0);
          }   
        }
    }
}