namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IHpAndMpManipulation
    {        
        int HpModifier {get; set;}
        int MpModifier {get; set;}

        void Action<T>(ref T character) where T : Creature;
    }
}