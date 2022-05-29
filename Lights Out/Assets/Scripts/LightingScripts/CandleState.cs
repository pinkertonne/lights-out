using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

/*
    This class maintains the state of a candle 
*/
public class CandleState : MonoBehaviour
{
    // private vars 
    private bool inRange;
    private static System.Timers.Timer aTimer;

    // public vars 
    public bool isLit;
    public bool canLight; 
    public static float litTime;
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
        int temp = PlayerInventory.matchCount;
        if (Input.GetMouseButtonUp(0))
        {
            if (canLight)
            {
                playerInventoryRef.PopMatchStack();
                LightCandle(ref m_candle, litTime, isLit);
            }
            else if (temp == 0 && inRange)
            {
                Debug.Log("There are no Matches in your inventory"); // for testing
            }
        }
        else if (litTime <= 0.0f)
        {
            m_candle.enabled = false; 
        }
    }

    // Called when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        int i = PlayerInventory.matchCount; 
        if (other.CompareTag("Player") && inSight() && i > 0)
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
    public void LightCandle(ref Light candle, float timeRemaining, bool litState)
    {
        if (!litState)
        {
            candle.enabled = true;
            canLight = false;  
        }
        aTimer = new System.Timers.Timer();
        aTimer.Elapsed += CandleTimer;
        aTimer.Interval = 1000;
        aTimer.Enabled = true; 
    }

    public static void CandleTimer(object source, ElapsedEventArgs e)
    {
        litTime -= 0.5f;
        Debug.Log("The new littime is: " + litTime);
         if (litTime <= 0.0f)
        {
            aTimer.Stop();
        } 
    }
}
