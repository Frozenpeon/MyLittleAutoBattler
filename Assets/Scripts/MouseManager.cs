using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public GameObject toSpawn;
    public GameObject previsGO;

    GridCell cell;
    GridCell oldCell;
    GameObject previs;
    private void Start()
    {
        previs = Instantiate(previsGO);
    }
    private void Update()
    {
        if (rayCastFromCamera().collider != null)
            cell = rayCastFromCamera().collider.GetComponent<GridCell>();
        else 
            cell = null;

        if (oldCell != cell && oldCell != null)
        {
            oldCell.stopHover();
            previs.transform.position = Vector3.down;
        }

        if (cell != null)
            cell.startHover(previs);

        if (Input.GetMouseButtonDown(0))       
            if (cell != null)
                cell.setUpAnObjectOnThis(Instantiate(toSpawn));
        if (Input.GetMouseButtonDown(1))
            if (cell != null)
                Destroy(cell.gameObject);
        oldCell = cell;
    }


    private RaycastHit rayCastFromCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500f);
        return hit;
    }

}
