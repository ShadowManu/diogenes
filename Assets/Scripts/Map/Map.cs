using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Map: MonoBehaviour {
  public int dimension = 5;

  private Tile[,] grid;
  private Mesh m;

  private int[] meshTriangles;
  private Vector3[] meshVertices;
  private Vector2[] meshUVs;

  void Start() {
    BuildGrid();
  }

  private void BuildGrid() {
    m = new Mesh();
    meshTriangles = new int[dimension * dimension * 6];
    meshVertices = new Vector3[dimension * dimension * 4];
    meshUVs = new Vector2[dimension * dimension * 4];

    // Create grid
    grid = new Tile[dimension, dimension];

    for (int i = 0; i < dimension; i++) {
      for (int j = 0; j < dimension; j++) {
        grid[i, j] = new Tile(i, j);
        CreateQuad(i, j);
      }
    }

    m.vertices = meshVertices;
    m.uv = meshUVs;
    m.triangles = meshTriangles;
    m.RecalculateNormals();

    GetComponent<MeshFilter>().mesh = m;
  }

  private void CreateQuad(int x, int y) {
    int offset = (x * dimension + y) * 4;

    // TODO REFACTOR naming
    meshVertices[offset] = new Vector3(x, 0, y); // bottom-left
    meshVertices[offset + 1] = new Vector3(x + 1, 0, y); // bottom-right
    meshVertices[offset + 2] = new Vector3(x + 1, 0, y + 1); // top-right
    meshVertices[offset + 3] = new Vector3(x, 0, y + 1); // top-left

    meshUVs[offset] = new Vector2(0, 0);
    meshUVs[offset + 1] = new Vector2(1, 0);
    meshUVs[offset + 2] = new Vector2(1, 1);
    meshUVs[offset + 3] = new Vector2(0, 1);

    int tOffset = (x * dimension + y) * 6;

    meshTriangles[tOffset] = offset; // bottom-left
    meshTriangles[tOffset + 1] = offset + 3; // top-left
    meshTriangles[tOffset + 2] = offset + 2; // top-right

    meshTriangles[tOffset + 3] = offset + 2; // top-right
    meshTriangles[tOffset + 4] = offset + 1; // bottom-right
    meshTriangles[tOffset + 5] = offset; // bottom-left
  }
}