using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f; //public
    private float turnSpeed = 25.0f; //public
    private float horizontalInput; //public
    private float verticalInput; //public

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input for right & left movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Get the input for forward & backward movement
        verticalInput = Input.GetAxis("Vertical");

        // Move the vehicle forward and backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Move the vehicle right and left
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        //Turn the vehicle right and left
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
