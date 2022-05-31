using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is used to simulate the 
    movement of a player object during 
    enemy ai testing 
*/
public class MovementTester : MonoBehaviour
{

    public GameObject Player; // speed of the player 

    private float playerSpeed; // player speed

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= -12)
        {
            Player.transform.Translate(-Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}
