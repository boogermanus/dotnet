#nullable enable
using System;

namespace PrizeGame
{
    public abstract class Player : BoardObject, ICloneable
    {
        private static int _numPlayers;
        
        private static int GetNewPlayerNum()
        {
            return ++_numPlayers;
        }

        private int _score;
        private readonly int _playerNum;
        private readonly string _name;

        
        // Create a Player
        protected Player(string name)
        {
            this._name = name;
            _playerNum = GetNewPlayerNum();
        }
        
        // Default constructor creates an Player with a dumb name.
        protected Player()
        {
            this._name = "Unknown";
            _playerNum = GetNewPlayerNum();
        }

        
        // Make a move on the given Board.  The Player should call Board.move(this, Direction)
        // to make the move.  If that call is not made, the Player stays in place.
        public abstract void Move(Board board);

        public int Score => _score;

        public override bool BlocksMovement()
        {
            return true;
        }

        public void IncreaseScore(int morePoints)
        {
            _score += morePoints;
        }
        
        // @return The name of this player.
        public string GetName()
        {
            return _name;
        }

        public int GetNumber()
        {
            return _playerNum;
        }


        public sealed override bool Equals(object? obj)
        {
            return obj is Player player && GetNumber().Equals(player.GetNumber());
        }

        public sealed override int GetHashCode()
        {
            return GetNumber().GetHashCode();
        }

        public override string ToString()
        {
            return GetName();
        }

 
        // Clone this player.  The player should call the clone constructor.
        // Players are cloned to produce move histories, among other things.
        public object Clone()
        {
            return MemberwiseClone();
        }
        
        // Determines a direction an player can move to reduce the distance to
        // a target.  This player may move in the direction.  Other moves may be possible.
        // @param board The board state to consider.
        // @param target The object we're trying to reach.
        // @return A direction which will reduce the distance to the target object, or null if
        // there is no direct unblocked path to the target.
        protected Direction? GetDirection(Board board, BoardObject target)
        {
            // try X first
            if (target.X > X && IsOpen(board, Direction.RIGHT))
            {
                return Direction.RIGHT;
            }
            if (target.X < X && IsOpen(board, Direction.LEFT))
            {
                return Direction.LEFT;
            }
            if (target.Y > Y && IsOpen(board, Direction.UP))
            {
                return Direction.UP;
            }
            if (target.Y < Y && IsOpen(board, Direction.DOWN))
            {
                return Direction.DOWN;
            }
            return null;
        }

        private bool IsOpen(Board board, Direction direction)
        {
            return board.GetAllowedMoves(X, Y).Contains(direction);
        }
    }
}