using System;

//Use to check if the input uses only numbers 
class InputCheck{
  public static int IntCheck(string message, string errorMessage){
    bool isNumeric = false;
    int inputResult;
    
    Console.Write(message);
    
    do{
      isNumeric = int.TryParse(Console.ReadLine(), out inputResult);
      if(!isNumeric)
        Console.Write(errorMessage);        
    }while(!isNumeric);
    
    return inputResult;
  }
}