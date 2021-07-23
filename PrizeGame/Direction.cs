namespace PrizeGame
{
    public class Direction
    {
        
        // Decrease in Y
        public static Direction DOWN = new Direction(0, -1);
        
        // Decrease in X
        public static Direction LEFT = new Direction(-1, 0);
    
        // Increase in X
        public static Direction RIGHT = new Direction(1, 0);
        
        // Increase in Y
        public static Direction UP = new Direction(0, 1);

        
        // Change in X position (left is negative, right is positive).
        public int DeltaX;
        // Change in Y position (down is negative, up is positive).
        public int DeltaY;

        private Direction(int deltaX, int deltaY)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }

        public override string ToString()
        {
            if (DeltaX == LEFT.DeltaX && DeltaY == LEFT.DeltaY)
                return nameof(LEFT);
            if (DeltaX == RIGHT.DeltaX && DeltaY == RIGHT.DeltaY)
                return nameof(RIGHT);
            if (DeltaX == UP.DeltaX && DeltaY == UP.DeltaY)
                return nameof(UP);
            if (DeltaX == DOWN.DeltaX && DeltaY == DOWN.DeltaY)
                return nameof(DOWN);
            return "?";
        }
    }
}