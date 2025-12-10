using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public GameObject objectOnThis { get; private set; }

    private Material baseMaterial;
    public Material hoverMaterial;

    private void Start()
    {
        baseMaterial = gameObject.GetComponent<Renderer>().material;
    }

    public void setUpAnObjectOnThis(GameObject gO)
    {
        if (objectOnThis != null)
            return;
        objectOnThis = gO;
        gO.transform.position = transform.position + Vector3.up;
    }

    public void startHover()
    {
        transform.localScale = Vector3.one * 1.5f;
        gameObject.GetComponent<Renderer>().material = hoverMaterial;
    }
    public void stopHover()
    {
        transform.localScale = Vector3.one;
        gameObject.GetComponent<Renderer>().material = baseMaterial;
    }
}
