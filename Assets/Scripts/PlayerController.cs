using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] float speed = 10.0f; //public//private
    [SerializeField] float horsePower = 0.0f; //public//private
    [SerializeField] float turnSpeed = 25.0f; //public//private
    [SerializeField] GameObject centerOfMass; //public//private
    [SerializeField] TextMeshProUGUI speedometerText; //public//private
    [SerializeField] TextMeshProUGUI rpmText; //public//private
    [SerializeField] List<WheelCollider> allWheels; //public//private
    [SerializeField] float speed; //public//private
    [SerializeField] float rpm; //public//private
    [SerializeField] int wheelsOnGround;
    private float horizontalInput; //public
    private float verticalInput; //public
    private Rigidbody playerRb; //public

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void FixedUpdate()
    {
        // Get the input for right & left movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Get the input for forward & backward movement
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Move the vehicle forward and backward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

            // Move the vehicle right and left
            //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

            // Turn the vehicle right and left
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            // calculate and display the speed
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); // 2.237f for mph
            speedometerText.SetText("Speed: " + speed + " kph");

            // calculate and display the rpm
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
