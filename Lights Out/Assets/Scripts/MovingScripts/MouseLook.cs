using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class handles the movement of the 
    player's vision in response to mouse movement 
*/
public class MouseLook : MonoBehaviour
{

    // mouse vars 
    private float mouseSensitivity = 250f;
    private float xRotation = 0; 

    // var for camera rotaton 
    public Transform playerBody;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -40f, 40);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
