using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    /*
    public Transform Enemy; 

    // grid reference 
    Grid Grid; 

    // pathfinding reference 
    PathFinding PathFinder;

    // movement vars
    
    public bool reachedEnd = false;
    public bool pathSet = false; 

    void Awake()
    {
        Grid = GetComponent<Grid>();
        PathFinder = GetComponent<PathFinding>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" MOVE FINAL COUNTTT" + Grid.FinalPath.Count);
        if (!reachedEnd && !pathSet && Grid.FinalPath != null)
        {
           // Debug.Log("Hellooo");
            SetMovement(Grid.FinalPath);
            pathSet = true;
        }
        else if (!reachedEnd)
        {
            MoveObject();
        }
    }

    // moves the start pos object to the end pos object 
    void SetMovement(List<Node> arg_FinalPath)
    {

        
        // Assign start node 
        Node StartNode = arg_FinalPath[0];

        // find x and y starting coordinates
        xMoveFrom = StartNode.gridX;
        yMoveFrom = StartNode.gridY;

        // find x and y coordinates to move to
        xMoveTo = xMoveFrom;
        yMoveTo = yMoveFrom;

        // assign values to the vars above
        bool xFlag = true;
        bool yFlag = true; 
        Debug.Log("Count is" + arg_FinalPath.Count);
        for (int i = 0; i < arg_FinalPath.Count; i++)
        {
            if (arg_FinalPath[i].gridX != xMoveFrom && xFlag)
            {
                xMoveTo = arg_FinalPath[i - 1].gridX;
                xFlag = false; 
            }
            else if (arg_FinalPath[i].gridY != yMoveFrom && yFlag)
            {
                yMoveTo = arg_FinalPath[i - 1].gridY;
            }
            else 
            {
                break;
            }

            Debug.Log(xMoveFrom + "    " + xMoveTo);
        }
    }

    // moves the object every time 
    void MoveObject()
    {
        Debug.Log("goshhhh");
        if (xMoveFrom != xMoveTo) Enemy.Translate(Vector3.right * 10 * Time.deltaTime);
        

       
    }
    */
}
