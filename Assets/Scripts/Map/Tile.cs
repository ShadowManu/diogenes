using UnityEngine;

public class Tile
{
  Material material;

  public Tile(Material material)
  {
    this.material = material;
  }

  public GameObject Instantiate(Transform parent, Vector3 position)
  {
    var go = Object.Instantiate<GameObject>(prefab, position, Quaternion.Euler(90, 0, 0), parent);
    go.GetComponent<Renderer>().material = material;
    return go;
  }

  public static Tile basicMock()
  {
    return new Tile(Resources.Load<Material>("Materials/GrassMock"));
  }

  static GameObject prefab = Resources.Load<GameObject>("Prefabs/Tile");
}