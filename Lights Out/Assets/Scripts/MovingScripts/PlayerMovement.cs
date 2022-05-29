using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class dictates the movement of a 
    player controlled character
*/ 
public class PlayerMovement : MonoBehaviour
{

    // player vars
    private CharacterController controller;
    private Vector3 playerVelocity;

    // if touching the ground
    private bool groundedPlayer;

    // the player movement speed 
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
        if (!controller.isGrounded)
        {
            move += Physics.gravity; // applies gravity
        }
        controller.Move(move * playerSpeed * Time.deltaTime);

    }
}
