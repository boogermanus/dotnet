namespace PrizeGame
{
    public class EmptySpace : BoardObject
    {
        public override bool BlocksMovement()
        {
            return false;
        }

        public override string ToString()
        {
            return "Empty Space";
        }


        public override bool Equals(object obj)
        {
            if (obj is EmptySpace)
            {
                return X == ((EmptySpace)obj).X && Y == ((EmptySpace)obj).Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = hashCode += 37 * X;
            hashCode = hashCode += 37 * Y;
            return GetHashCode();
        }
    }
}