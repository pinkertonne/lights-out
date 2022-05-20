using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

// This is a class that controls the state
// of the flashlight and its behaviour
public class LightState : MonoBehaviour
{ 
    // private vars 
    private Light m_Light;
    private static System.Timers.Timer batteryTimer; 

    // public vars 
    public PlayerInventory playerInventoryRef;
    public static float flashlightTime; 

    // Unity start method 
    void Start()
    {
        m_Light = GetComponent<Light>();
        m_Light.enabled = true;
        flashlightTime = 10.0f; // arbitrary for right now 
        batteryTimer = new Timer(1000);
        batteryTimer.Elapsed += BatteryLife;
        batteryTimer.Start();
    }

    // Unity update method
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {  
            if (flashlightTime >= 0.0f)
            {
                m_Light.enabled = !m_Light.enabled;
            }
            else 
            {
                m_Light.enabled = false; 
                batteryTimer.Stop();
            }
           
        }
        
        if (Input.GetKey(KeyCode.C)) // arbitrary key code, can be changed 
        {
            int i = PlayerInventory.batteryCount;
            if (i > 0)
            {
                flashlightTime = 10.0f;
                playerInventoryRef.PopBatteryStack();
            }
            else 
            {
                Debug.Log("There are no Batteries in your inventory");
            }       
        }
       
       
        else if (flashlightTime <= 0.0f)
        {
            batteryTimer.Stop();
            m_Light.enabled = false; 
        }
        else if (m_Light.enabled)
        {
            batteryTimer.Start();
        }
        else 
        {
            batteryTimer.Stop();
        }
        
        
    }

    public static void BatteryLife(object source, ElapsedEventArgs e)
    {
        flashlightTime -= 0.5f;
        if (flashlightTime <= 0.0f)
        {
            batteryTimer.Stop();
        }
        Debug.Log("The battery Life is" + flashlightTime);
    }
}