using System.Linq;

public class Map
{
  public Tile[][] tiles;

  public Map(Tile[][] tiles)
  {
    this.tiles = tiles;
  }

  public static Map basicMock(int size)
  {
    return new Map(
      Enumerable.Range(0, size).Select(i =>
        Enumerable.Range(0, size).Select(j =>
          Tile.basicMock()
        ).ToArray()
      ).ToArray()
    );

  }
}