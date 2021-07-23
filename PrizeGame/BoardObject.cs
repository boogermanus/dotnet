namespace PrizeGame
{
    public abstract class BoardObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        
        // Indicates whether this object prevents an Player from moving in.
        // @return True if this object prevents entry, false otherwise.
        public abstract bool BlocksMovement();
        
        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}