using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    public int cellStatus = 0;
    public GameObject ActivatedCell;
    
    // Update is called once per frame
    void Update()
    {
        if(cellStatus == 1)
        {
            Activate();
        }
    }

    private void Activate()
    {
        Instantiate(ActivatedCell, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        this.enabled = false;
    }
}
