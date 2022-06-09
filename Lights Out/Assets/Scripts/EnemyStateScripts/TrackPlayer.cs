using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This class determines how a Enemy object will 
    track the Player object  
*/
public class TrackPlayer : MonoBehaviour
{

    private enum State // Different states the enemy object can be in
    {
        Attack, // approach and attack the player 
        Move, // Move to the nearest midpoint
        Stop // stop moving 
        // respawn - will be done later  
    }

    public GameObject Player; // player
    public GameObject Enemy; // enemy

    private State EnemyState; // enemy state
    private float enemySpeed; // enemy speed  

    // Start is called before the first frame update
    private void Start()
    {
        // initialize enemy variables
        EnemyState = State.Attack;
        enemySpeed  = 3.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        // update the state 
        UpdateState();

        // run code bases on the state 

        if (EnemyState == State.Attack)
        {
            // have the enemy move towards the player 
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, (enemySpeed * Time.deltaTime)); 
        }
        else 
        {
            // do nothing 
        }
        Debug.Log(EnemyState);
    }

    // Called every frame to check the state of the enemy
    private void UpdateState()
    {
        // distance between the enemy and player
        float totalDistance = 
            Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x) +
            Mathf.Abs(Enemy.transform.position.z - Player.transform.position.z);

        if (totalDistance > 2.0f && totalDistance < 30.0f) // arbitrary values for now 
        {
            EnemyState = State.Attack;
        }
        else 
        {
            EnemyState = State.Stop;
        }
    }

    // Lets the game know if the A* should pause and
    // let the enemy pursue the player
    public bool CanAttack()
    {
        if (EnemyState == State.Attack)
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }
}
