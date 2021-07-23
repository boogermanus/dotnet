using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeGame
{
    public class Board
    {
        private readonly BoardObject[,] _grid;
        private readonly int _maxX;
        private readonly int _maxY;
        private readonly LinkedList<Player> _players = new LinkedList<Player>();  // stored in turn order
        private readonly HashSet<Prize> _prizes = new HashSet<Prize>();
        private Player _currentPlayer;

        public Board(int x, int y)
        {
            _maxX = x - 1;
            _maxY = y - 1;
            _grid = new BoardObject[x, y];
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = new EmptySpace();
                    _grid[i, j].SetPosition(i, j);
                }
            }
        }

        private Board(Board original)
        {
            // copy constructor
            _maxX = original._maxX;
            _maxY = original._maxY;
            _grid = new BoardObject[_maxX + 1, _maxY + 1];
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = original._grid[i, j];
                }
            }
            foreach (var prize in original._prizes)
            {
                _prizes.Add(prize);
            }
            // clone the players; everything else is immutable
            for (IEnumerator<Player> iter = original._players.GetEnumerator(); iter.MoveNext(); )
            {
                Player element = iter.Current;
                Player playerClone = (Player)element.Clone();
                _players.AddLast(playerClone);
                _grid[playerClone.X, playerClone.Y] = playerClone;
            }
            _currentPlayer = _players.ElementAt<Player>(0);
        }

        /**
         * Get the highest X on the board.  The lowest is zero.
         * @return One less than the number of columns.
         */
        public int GetMaxX()
        {
            return _maxX;
        }

        /**
         * Get the highest Y on the board.  The lowest is zero.
         * @return One less than the number of rows.
         */
        public int GetMaxY()
        {
            return _maxY;
        }

        public void PositionPlayers(Player player1, Player player2)
        {
            _players.AddLast(player1);
            _players.AddLast(player2);
            int centerCol = _maxX / 2;
            int centerRow = _maxY / 2;
            player1.SetPosition(centerCol - 1, centerRow);
            player2.SetPosition(centerCol + 1, centerRow);
            for (IEnumerator<Player> iter = _players.GetEnumerator(); iter.MoveNext(); )
            {
                Player element = iter.Current;
                _grid[element.X, element.Y] = element;
            }
            _currentPlayer = player1;
        }

        public void PositionPlayers(Player player1, Player player2, Player player3, Player player4)
        {
            _players.AddLast(player1);
            _players.AddLast(player2);
            _players.AddLast(player3);
            _players.AddLast(player4);
            int left, right, top, bottom;
            if (_maxX % 2 == 0)
            { // even columns
                left = _maxX / 2 - 1;
                right = _maxX / 2 + 2;
            }
            else
            { // odd columns
                left = _maxX / 2 - 1;
                right = _maxX / 2 + 1;
            }
            if (_maxY % 2 == 0)
            { // even rows
                top = _maxY / 2 + 2;
                bottom = _maxY / 2 - 1;
            }
            else
            { // odd rows
                top = _maxY / 2 + 1;
                bottom = _maxY / 2 - 1;
            }
            player1.SetPosition(left, top);
            player2.SetPosition(right, top);
            player3.SetPosition(right, bottom);
            player4.SetPosition(left, bottom);
            for (IEnumerator<Player> iter = _players.GetEnumerator(); iter.MoveNext(); )
            {
                Player element = iter.Current;
                _grid[element.X, element.Y] = element;
            }
            _currentPlayer = player1;
        }

        public int PlacePrizesRandomly(double percent, int minPoints, int maxPoints)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i, j] is EmptySpace)
                    {
                        if (random.NextDouble() < percent)
                        {
                            int points = (int)(random.NextDouble() * (maxPoints - minPoints) + minPoints);
                            Prize prize = new Prize("Prize " + _prizes.Count, points);
                            prize.SetPosition(i, j);
                            _grid[i, j] = prize;
                            _prizes.Add(prize);
                        }
                    }
                }
            }
            return _prizes.Count;
        }

        /**
         * Move a Player one step in a given direction.
         * @param player The player to move.
         * @param direction The direction in which to move.
         * @throws InvalidOperationException if it's not the player's turn or the player tries to move to an
         * illegal location.
         */
        public void Move(Player player, Direction direction)
        {
            int curX = player.X;
            int curY = player.Y;
            if (!player.Equals(_currentPlayer))
            {
                throw new InvalidOperationException("Cannot move a piece other than your own.");
            }
            int newX = curX + direction.DeltaX;
            int newY = curY + direction.DeltaY;
            if (newX < 0 || newX > _maxX || newY < 0 || newY > _maxY)
            {
                throw new InvalidOperationException("Cannot move to (" + newX + "," + newY + "); it is off the board");
            }
            BoardObject newOccupant = _grid[newX, newY];
            if (newOccupant.BlocksMovement())
            {
                throw new InvalidOperationException("Cannot move to (" + newX + "," + newY + "); it is occupied by " + newOccupant);
            }
            if (newOccupant is Prize)
            {
                Prize prize = (Prize)newOccupant;
                player.IncreaseScore(prize.Points);
                _prizes.Remove(prize);
            }
            _grid[newX, newY] = player;
            player.SetPosition(newX, newY);
            _grid[curX, curY] = new EmptySpace();
            _grid[curX, curY].SetPosition(curX, curY);
            
            Console.WriteLine($"Player {GameEngine.GetPlayerLetter(player)} decided to move {direction}\n");
        }

        public void AdvanceTurn()
        {
            Player first = _players.ElementAt(0);
            _players.RemoveFirst();
            _players.AddLast(first);
            _currentPlayer = _players.ElementAt(0);
        }

        /**
         * @param x The column of interest.
         * @param y The row of interest.
         * @return The BoardObject at position (x, y)
         */
        public BoardObject GetBoardObject(int x, int y)
        {
            return _grid[x, y];
        }

        /**
         * @return True if all prizes have been gathered, false otherwise.
         */
        public bool GameOver()
        {
            return _prizes.Count == 0;
        }

        /**
         * @return It is this Player's turn.
         */
        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        /**
         * @return A list of Prize objects left on the board.
         */
        public List<Prize> GetPrizes()
        {
            return new List<Prize>(_prizes);
        }

        /**
         * @return All Players on the board in turn order.  The Player whose
         */
        public List<Player> GetPlayers()
        {
            return new List<Player>(_players);
        }

        /**
         * @return An unmodifyable collection of allowable moves.
         */
        public List<Direction> GetAllDirections()
        {
            List<Direction> directions = new List<Direction>();
            directions.Add(Direction.DOWN);
            directions.Add(Direction.LEFT);
            directions.Add(Direction.RIGHT);
            directions.Add(Direction.UP);
            return directions;
        }

        /**
         * Get all directions in which one can move from a given location.
         * @param x The horizontal starting point.
         * @param y The vertical starting point.
         * @return All Direction objects in which one could move.
         */
        public ICollection<Direction> GetAllowedMoves(int x, int y)
        {
            List<Direction> results = new List<Direction>();
            foreach (Direction dir in GetAllDirections())
            {
                int newX = x + dir.DeltaX;
                int newY = y + dir.DeltaY;
                if (newX >= 0 && newY >= 0 && newX <= _maxX && newY <= _maxY && !_grid[newX, newY].BlocksMovement())
                {
                    results.Add(dir);
                }
            }
            return results;
        }
    }
}