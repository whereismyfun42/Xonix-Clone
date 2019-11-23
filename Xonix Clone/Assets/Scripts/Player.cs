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
    public int moveCounter = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && moveCounter>0)
        {
            DecreaseCounter();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) && moveCounter > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.forward * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.A) && moveCounter > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce((-Vector3.right) * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.D) && moveCounter > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.right * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S) && moveCounter > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce((-Vector3.forward) * movementSpeed);
        }

        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround);

        if (hit.collider.gameObject)
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = highlightMaterial;
            hit.collider.gameObject.GetComponent<GridCell>().cellStatus = 1;
        }        
    }

    void DecreaseCounter()
    {
        moveCounter--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bounds")
        {
            moveCounter = 2;
        }
    }

}
