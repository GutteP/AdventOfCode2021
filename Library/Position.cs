
namespace Library;

public record Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position North()
    {
        return new Position(X - 1, Y);
    }

    public Position South()
    {
        return new Position(X + 1, Y);
    }

    public Position West()
    {
        return new Position(X, Y - 1);
    }
    public Position East()
    {
        return new Position(X, Y + 1);
    }

    public IEnumerable<Position> Neighbors(bool diagonally = false)
    {
        yield return new Position(X - 1, Y); //North
        if (diagonally) yield return new Position(X - 1, Y + 1); //North-East
        yield return new Position(X, Y + 1); //East
        if (diagonally) yield return new Position(X + 1, Y + 1); //South-East
        yield return new Position(X + 1, Y); //South
        if (diagonally) yield return new Position(X + 1, Y - 1); //South-West
        yield return new Position(X, Y - 1); //West
        if (diagonally) yield return new Position(X - 1, Y - 1); //North-West
    }
}
