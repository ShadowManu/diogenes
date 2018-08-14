using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour
{
  public GameObject[][] grid;
  public TileCollection tileCollection;

  void Start()
  {
    BuildGrid();
  }

  private void BuildGrid()
  {
    grid = Enumerable.Range(0, 4).Select(i =>
      Enumerable.Range(0, 4).Select(j =>
      {
        int index = (i * 4) + j;
        GameObject tile = tileCollection.tiles[index];
        Vector3 position = new Vector3(i, 0, j);
        return Instantiate<GameObject>(tile, position, tile.transform.rotation, transform);
      }).ToArray()
    ).ToArray();
  }
}