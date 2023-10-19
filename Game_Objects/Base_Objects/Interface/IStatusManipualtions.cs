namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IStatusManipualtions
    {
        public string BuffString {get; set;}
        public BuffType BuffManipulated {get; set;}
        public int StatusQuantity { get; set; }
        public int TurnMax {get; set;}
        public int Turn {get; set;}
        int Applying();    
        BuffType ApplyingType();
        void TurnCount();
    }
}