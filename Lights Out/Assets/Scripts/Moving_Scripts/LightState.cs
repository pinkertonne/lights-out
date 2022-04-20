using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{ 
   private Light light; 

   void Start()
   {
       light = GetComponent<Light>();
   }

   void Update()
   {
       if (Input.GetMouseButtonUp(1))
       {
           light.enabled = !light.enabled;
       }
   }
}