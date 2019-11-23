using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Material highlightMaterial;
    public Material boundsMaterial;
    public Rigidbody rb;
    public float distanceToGround = 0.5f;
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += (-transform.right) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += (-transform.forward) * Time.deltaTime * movementSpeed;
        }

        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround);

        if (hit.collider.gameObject)
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = highlightMaterial;
            hit.collider.gameObject.GetComponent<GridCell>().cellStatus = 1;
        }        
    }

    
}
