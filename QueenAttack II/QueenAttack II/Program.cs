var res = Result.queensAttack(5, 3, 4, 3, [
    [5, 5],
    [4, 2],
    [2, 3]
]);

var expected = 10;

Console.WriteLine($"Actual value: {res}, Expected value: {expected}");
Console.WriteLine($"Is result expected: {res == expected}");

class Result
{
    public record Coords(int X, int Y) : IEquatable<Coords>
    {
        public static Coords operator +(Coords a, Coords b)
        {
            return new Coords(a.X + b.X, a.Y + b.Y);
        }

        public virtual bool Equals(Coords? other)
        {
            if (other is null) return false;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        var directions = new List<Coords>
        {
            new(-1, 1),  // Diagonal up-right
            new(0, 1),   // Right
            new(1, 1),   // Diagonal down-right
            new(1, 0),   // Down
            new(1, -1),  // Diagonal down-left
            new(0, -1),  // Left
            new(-1, -1), // Diagonal up-left
            new(-1, 0)   // Up
        };

        var obstacleSet = new HashSet<Coords>(
            obstacles.Select(obs => new Coords(obs[0], obs[1]))
        );

        var counter = 0;

        foreach (var direction in directions)
        {
            var coords = new Coords(r_q, c_q);
            while (true)
            {
                coords += direction;

                if (coords.X <= 0 || coords.X > n || coords.Y <= 0 || coords.Y > n)
                    break;

                if (obstacleSet.Contains(coords))
                    break;

                counter++;
            }
        }

        return counter;
    }
}
