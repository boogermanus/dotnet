#nullable enable
namespace PrizeGame.Players
{
    public class HighestPrizePlayer : Player
    {
        public HighestPrizePlayer() : base(nameof(HighestPrizePlayer))
        {
        }

        public override void Move(Board board)
        {
            var maxPoints = int.MinValue;
            Direction? dir = null;
            
            foreach (var prize in board.GetPrizes())
            {
                if (prize.Points <= maxPoints || GetDirection(board, prize) == null) 
                    continue;
                maxPoints = prize.Points;
                dir = GetDirection(board, prize);
            }
            
            if (dir != null)
            {
                board.Move(this, (Direction) dir);
            }
            // otherwise there's nothing we can do
        }
    }
}