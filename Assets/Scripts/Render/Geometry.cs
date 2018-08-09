using System.Collections.Generic;
using UnityEngine;

public class Geometry {

  public static Mesh FloorQuadMesh(Vector3 start, int size = 1) {
    return Geometry.QuadMesh(
      start,
      start + Vector3.forward * size,
      start + (Vector3.forward + Vector3.right) * size,
      start + Vector3.right * size
    );
  }

  public static Mesh QuadMesh(Vector3 bottomLeft, Vector3 topLeft, Vector3 topRight, Vector3 bottomRight) {
    Vector3[] vertices = { bottomLeft, topLeft, topRight, bottomRight };

    int BOTTOM_LEFT = 0;
    int TOP_LEFT = 1;
    int TOP_RIGHT = 2;
    int BOTTOM_RIGHT = 3;

    Vector2[] uv = {
      new Vector2(0, 0),
      new Vector2(0, 1),
      new Vector2(1, 1),
      new Vector2(1, 0)
    };

    int[] triangles = {
      BOTTOM_LEFT, TOP_LEFT, TOP_RIGHT,
      BOTTOM_LEFT, TOP_RIGHT, BOTTOM_RIGHT
    };

    Mesh mesh = new Mesh();
    mesh.vertices = vertices;
    mesh.uv = uv;
    mesh.triangles = triangles;
    mesh.RecalculateNormals();

    return mesh;
  }
}