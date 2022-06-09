using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midpoint : MonoBehaviour
{

    // private list of midpoints
    private List<Transform> MidpointList; 

    // game midpoint references
    Transform M1;
    Transform M2;
    // end game midpoint references 

    GameObject Player; // player reference

    GameObject Enemy; // Enemy reference 

    // Start is called before the first frame update
    void Start()
    {
        // add midpoint references to the list
    }

    private void CalculateTraversal(GameObject Player, GameObject Enemy)
    {

    }

    public Transform GetNearestMidpoint(GameObject Player, GameObject Enemy)
    {
        return null; // for now
    }
}
