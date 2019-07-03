using UnityEngine;
using System.Linq;

/// Instantiates tiles on scene, based on a Map
public class MapBuilder : MonoBehaviour
{
  public Map map;
  private GameObject[][] goTiles;

  void Start()
  {
    // TODO remove hardcoding the map
    map = Map.basicMock(5);
    InstantiateTiles();
  }

  private void InstantiateTiles()
  {
    goTiles = map.tiles.Select((row, i) =>
      row.Select((tile, j) =>
      {
        Vector3 position = new Vector3(i, 0, j);
        return tile.Instantiate(transform, position);
      }).ToArray()
    ).ToArray();
  }
}