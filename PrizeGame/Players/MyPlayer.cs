using System.Linq;

namespace PrizeGame.Players
{
    public class MyPlayer : Player
    {
        public MyPlayer()
            : base(nameof(MyPlayer))
        {

        }

        // Goal: Implement the "Move" method below.

        // Try to win the game as often as possible.

        // But, it is NOT possible to win every time. No code will be perfect.

        // Ask me lots of questions! I am here to help.

        // You can google anything you want.

        public override void Move(Board board)
        {
            // TODO: remove the line below and write your own code
            board.Move(this, board.GetAllowedMoves(X, Y).First());
        }
    }
}