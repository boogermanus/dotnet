using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeGame.Players
{
    public class MyPlayer : Player
    {
        public MyPlayer()
            : base(nameof(MyPlayer))
        {

        }

        public override void Move(Board board)
        {
            Direction? direction = null;
            var prizes = new List<PrizeTarget>();
            
            foreach (var prize in board.GetPrizes())
            {
                prizes.Add(new PrizeTarget(prize, Distance(prize)));
            }
            
            // or
            // var prizes = board.GetPrizes().Select(prize => new PrizeTarget(prize, Distance(prize))).ToList();

            var targetList = prizes
                .OrderBy(tl => tl.Distance)
                .ThenByDescending(tl => tl.Points)
                .ToList();

            // use FirstOrDefault because what if all the other prizes have been consumed, and the list is empty?
            var targetPrize = targetList
                .FirstOrDefault();

            // a bug -- maybe? rider flagged this as a possible null value because of the FirstOrDefault above
            // if null was passed in, GetDirection should throw?
            // direction = GetDirection(board, targetPrize.Prize);

            // this is safe according to rider
            if (targetPrize != null)
                direction = GetDirection(board, targetPrize.Prize);
            
            if (direction.HasValue)
            {
                board.Move(this, direction.GetValueOrDefault());
            }
        }

        private int Distance(BoardObject target)
        {
            return Math.Abs(target.X - X) + Math.Abs(target.Y - Y);
        }
    }

    internal class PrizeTarget
    {
        private readonly Prize _prize;
        
        public PrizeTarget(Prize prize, int distance)
        {
            _prize = prize;
            Distance = distance;
        }

        public int Points => _prize.Points;
        public Prize Prize => _prize;
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{Distance} - {Points}";
        }
    }
}