using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    public int cellStatus = 0;
    public GameObject ActivatedCell;
    public float distance = 0.1f;
    public Material highlightMaterial;
    public Material standartMaterial;

    // Update is called once per frame
    void Update()
    {
        if (cellStatus == 1)
        {
            Activate();
            FillSouth();
        }
    }

    private void Activate()
    {
        Instantiate(ActivatedCell, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        this.enabled = false;
    }

    public void FillSouth()
    {
        Physics.Raycast(transform.position, (-Vector3.forward), out RaycastHit hit, distance);

        if (hit.collider.gameObject)
        {
            if (hit.collider.gameObject.GetComponent<Renderer>().material = highlightMaterial)
            {
                return;
            }

            if (hit.collider.gameObject.GetComponent<Renderer>().material = standartMaterial)
            {
                hit.collider.gameObject.GetComponent<Renderer>().material = highlightMaterial;
            }

        }
    }
}
