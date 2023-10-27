using System;
using New_Arena_.Game_Objects.Base_Objects.Interface;
public abstract class Potion : ItemBase, IQuantity
{
    public int Quantity { get; set; }
    public new HpAndMpPotionType Quality {get; set;}
}