using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public GameObject toSpawn;
    GridCell cell;
    GridCell oldCell;
    private void Update()
    {
        if (rayCastFromCamera().collider != null)
            cell = rayCastFromCamera().collider.GetComponent<GridCell>();
        else 
            cell = null;

        if (oldCell != cell && oldCell != null)
            oldCell.stopHover();

        if (cell != null)
            cell.startHover();

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
