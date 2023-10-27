using System;

public abstract class ItemBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost {get; set;}  
    public int Rarity {get; set;}
    public Enum Quality {get; set;}
}