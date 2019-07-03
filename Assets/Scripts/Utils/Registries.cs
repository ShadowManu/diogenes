using System.Collections.Generic;

class Registries<K, V>
{
  public Dictionary<TileCode, Tile> tiles;

  public Registries()
  {
    tiles = new Dictionary<TileCode, Tile>();
  }
}