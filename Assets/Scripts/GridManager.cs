using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width, height;
    public GameObject tileGameObject;
    public Dictionary<Vector3, bool> grid = new Dictionary<Vector3, bool>();

    void Start()
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                grid.Add(new Vector3(i, 0, j), false);
        setUpVisualize();
    }

    private void setUpVisualize()
    {
        foreach (Vector3 v in grid.Keys)
        {
            Instantiate(tileGameObject, transform.position + v, Quaternion.identity);
        }
    }
}
