using System;

//Use to check if the input uses only numbers 
class InputCheck{
  public static int IntCheck(string message, string errorMessage){
    bool isNumeric;
    int inputResult;
    
    Console.Write(message);
    
    do{
      isNumeric = int.TryParse(Console.ReadLine(), out inputResult);
      if(!isNumeric)
        Console.Write(errorMessage);        
    }while(!isNumeric);
    
    return inputResult;
  }

  public static int ListLength(string message, int listLength){
    Console.Write(message);
    int inputResult = 0;
    
    do{
      inputResult = IntCheck("", "Number Only");
      if(inputResult > listLength){
         Console.Write("Number not listed");
      }      
    }while(inputResult > listLength || inputResult < 0);

    return inputResult;
  }

  public static int LimitCheck(string message, int limit){
    Console.Write(message);
    int inputResult = 0;

    do{
      inputResult = IntCheck("", "Number Only");
      if(inputResult > limit){
         Console.Write("Number not listed");
      }      
    }while(inputResult > limit || inputResult < 0);

    return inputResult;
  }
}