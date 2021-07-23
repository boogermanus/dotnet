namespace PrizeGame
{
    public class Prize : BoardObject
    {
        public int Points { get; private set; }
        public string PrizeId { get; private set; }

        public Prize(string prizeId, int points)
        {
            PrizeId = prizeId;
            Points = points;
        }

        public override bool BlocksMovement()
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Prize prize && PrizeId.Equals(prize.PrizeId);
        }

        public override int GetHashCode()
        {
            return PrizeId.GetHashCode();
        }

        public override string ToString()
        {
            return "Prize " + PrizeId + " worth " + Points + " points";
        }
    }
}