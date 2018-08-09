using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshFilter))]
public class Map: MonoBehaviour {
  public int size = 5;

  // private Tile[][] grid;

  void Start() {

    BuildGrid();
  }

  private void BuildGrid() {
    grid = Enumerable.Range(0, size).Select(i =>
      Enumerable.Range(0, size).Select(j =>
        new Tile(i, j)
      ).ToArray()
    ).ToArray();

    Instantiate(null, null, null, null);

    GetComponent<MeshFilter>().mesh = m;
  }

}