using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{ 
   private Light m_Light; 

   void Start()
   {
        m_Light = GetComponent<Light>();
   }

   void Update()
   {
       if (Input.GetMouseButtonUp(1))
       {
           m_Light.enabled = !m_Light.enabled;
       }
   }
}