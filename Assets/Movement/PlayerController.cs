using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 mousePos;
    public float rotationSpeed = 1;
    public Rigidbody rb;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {




        Vector3 movement = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
       
    
}
