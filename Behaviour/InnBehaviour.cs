using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Arena_.Behaviour
{
    class InnBehaviour
    {
        public static void InnFunction(ref Character chosen)
        {      
            InnScreen.FoodDisplay();

            FoodConsuption(ref chosen);

            Console.Clear();

            GameScreen.CharacterStats(chosen);

            InnScreen.FoodDisplay();

            TakeFood(ref chosen);

            Console.Clear();
        }
        private static void FoodConsuption(ref Character chosen)
        {
            Console.WriteLine("Ready To Eat");
            int choiceEat = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
            int[] acceptedOptions = {1,2,3,4,5};

            if(choiceEat != 0){
              Food foodChoice = ArenaBehaviour.innFoodTable[choiceEat];

            do
            {
              Console.WriteLine("Food eaten!");
              foodChoice.Action(ref chosen);
              ArenaBehaviour.innFoodTable[choiceEat--].Quantity --;
              Console.ReadKey();
            }while(!acceptedOptions.Contains(choiceEat));    
            }      
        }
        private static void TakeFood(ref Character chosen)
        {
          int choiceTake = InputCheck.IntCheck("Choice(0 To go back/Exit will pass time !):", "Only Number:");
          int[] acceptedOptions = {1,2,3,4,5};
        
          if(choiceTake != 0)
          {
            Food foodTake;
            do
            {
              foodTake = ArenaBehaviour.innFoodTable[choiceTake--];
        
              if(foodTake.Quantity == 0)
              {
                UpdateConsole.StaticMessage("Food Already Eaten ");
                Console.ReadKey();
                Console.Clear();
                GameScreen.CharacterStats(chosen);
                InnScreen.FoodDisplay();
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