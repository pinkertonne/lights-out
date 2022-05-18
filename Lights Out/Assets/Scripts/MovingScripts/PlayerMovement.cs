using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 3.25f;
    
     private void Start()
     {
         controller = GetComponent<CharacterController>();
     }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

    
        Vector3 move = transform.right * x + transform.forward * z;

        // checks if the player is grounded 
        if (controller.isGrounded == false) 
        {
            move += Physics.gravity; // applies gravity
        }
        controller.Move(move * playerSpeed * Time.deltaTime);  

    }
}
