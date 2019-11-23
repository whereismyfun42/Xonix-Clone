using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public float distance = 0.1f;
    public int whoIsAround;
    public Material highlightMaterial;
    public Material standartMaterial;
    private void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.forward, out hit, distance);
        Physics.Raycast(transform.position, (-Vector3.forward), out hit, distance);
        Physics.Raycast(transform.position, Vector3.right, out hit, distance);
        Physics.Raycast(transform.position, (-Vector3.right), out hit, distance);

        if (hit.collider.gameObject)
        {
            if (hit.collider.gameObject.GetComponent<Renderer>().material = standartMaterial)
            {
                whoIsAround++;
            }
        }
    }
}
