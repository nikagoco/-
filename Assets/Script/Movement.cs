using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float jumpForce;
 
    private Rigidbody rb;
    private Vector3 jumpDir;
    private bool isGrounded;
 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpDir = new Vector3(0, jumpForce, 0);
    }
 
    private void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpDir);
            //rb.AddForce(0, jumpForce, 0);
        }
 
        
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        var col = collision.gameObject.GetComponent<BoxCollider>();
        // if (collision.gameObject.name == "Ground")
        // {
            isGrounded = true;
        // }
    }
 
    private void OnCollisionExit(Collision collision)
    {
        // if (collision.gameObject.name == "Ground")
        // {
            isGrounded = false;
        // }
    }
}
