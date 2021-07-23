#nullable enable
using System;

namespace PrizeGame.Players
{
    public class MinDistancePlayer : Player
    {
        public MinDistancePlayer() : base(nameof(MinDistancePlayer))
        {
        }

        public override void Move(Board board)
        {
            var minDistance = Int32.MaxValue;
            Direction? direction = null;
            
            foreach (Prize prize in board.GetPrizes())
            {
                if (Distance(prize) < minDistance && GetDirection(board, prize) != null)
                {
                    minDistance = Distance(prize);
                    direction = GetDirection(board, prize);
                }
            }
            
            if (direction.HasValue)
            {
                board.Move(this, direction.GetValueOrDefault());
            }
            // otherwise there's nothing we can do
        }

        private int Distance(BoardObject target)
        {
            return Math.Abs(target.X - X) + Math.Abs(target.Y - Y);
        }
    }
}