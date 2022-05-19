using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleState : MonoBehaviour
{
    // private var 
    private bool inRange;

    // public vars 
    public bool isLit;
    public bool canLight; 
    public float litTime;
    public LayerMask mask; 
    public Light m_candle;
    public PlayerInventory playerInventoryRef; 

    // Start is called before the first frame update
    private void Start()
    {
        inRange = false; 
        isLit = false;
        canLight = false;
        litTime = 10.0f;
        m_candle.enabled = false; 
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (canLight)
            {
                LightCandle(m_candle, litTime, isLit);
            }
            else if (playerInventoryRef.matchCount == 0 && inRange)
            {
                Debug.Log("There are no Matches in your inventory"); // for testing
            }
        }
    }

    // Called when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        inRange = true; 
        if (other.CompareTag("Player") && inSight() && playerInventoryRef.matchCount > 0)
        {
            canLight = true; 
        }
    }

    // Called when the Player exits the trigger zone 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false; 
            canLight = false; 
        }
    }

    // Checks if the player is looking at the object 
    private bool inSight()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }

    // lights the candle 
    public void LightCandle(Light light, float timeRemaining, bool litState)
    {
        if (!litState)
        {
            light.enabled = true; 
        }
    }
}
