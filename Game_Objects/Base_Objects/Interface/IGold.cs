namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    public interface IGold
    {
        public int Gold { get; set; } 

        bool CheckCost(int cost);
    }
}