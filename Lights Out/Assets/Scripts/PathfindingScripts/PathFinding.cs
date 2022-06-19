// Special thanks to "Daniel" youtube channel for his A* tutorial
// https://www.youtube.com/watch?v=AKKpPmxx07w

// Currently this code works fine but still needs full data encapsulation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class implements the A* pathfinding algorithm
*/ 
public class PathFinding : MonoBehaviour
{
    // grid class reference 
    public  Grid grid;

    // the start and end positions in Unity
    public Transform StartPosition;
    public Transform TargetPosition;

    // movement vars 
    private float speed = 2.0f; 
    private int xMoveFrom;
    private int xMoveToTemp;
    private int yMoveFrom;
    private int yMoveToTemp;
    private int xMoveTo;
    private int yMoveTo;
    private bool xFlag = false; 
    private bool yFlag = false; 
    private List<int> finalPathIndex = new List<int>();

    // test var
    private bool finalExists = false; 
    Vector3 targetTemp;

    // Called at the beginning of the scene
    private void Awake()
    {
        //grid = GetComponent<Grid>(); // gets grid component
        finalPathIndex.Add(0); // adds zero for x index 
        finalPathIndex.Add(0); // adds zero for  y index 
    }

    // Runs before the first frame 
    private void Start()
    {
        targetTemp = TargetPosition.position;

        UpdatePath(StartPosition.position, TargetPosition.position); // creates the opitmized path

        Debug.Log(grid.FinalPath.Count);
        finalPathIndex = SetMovement(grid.FinalPath, finalPathIndex[0], finalPathIndex[1]);
    }

    // Runs for every frame
    private void Update()
    {
        if (targetTemp != TargetPosition.position && (finalPathIndex[0] != null && finalPathIndex[1] != null))
        {
           
            UpdatePath(StartPosition.position, TargetPosition.position);
            finalPathIndex[0] = 0;
            finalPathIndex[1] = 0;
        }
        MoveObject(); // moves the player object 
        Debug.Log(grid.FinalPath.Count);
    }

    // sets the x and y movement vars 
    List<int> SetMovement(List<Node> arg_FinalPath, int xIndex, int yIndex)
    {
        Debug.Log(xIndex);
        // Assign start node 
        Node StartNode = arg_FinalPath[xIndex];

        // find x and y starting coordinates
        xMoveFrom = StartNode.gridX;
        yMoveFrom = StartNode.gridY;

        // find x and y coordinates to move to
        xMoveTo = xMoveFrom;
        yMoveTo = yMoveFrom;

        // temp values used for logic comparison
        xMoveToTemp = xMoveTo;
        yMoveToTemp = yMoveTo;

        // x moves if y is not moving 
        if (!yFlag)
        {
            // loop through the final path index 
            for (int i = xIndex; i < arg_FinalPath.Count; i++)
            {
                // index 0 edge case 
                if (yMoveTo != arg_FinalPath[i].gridY && yMoveToTemp == arg_FinalPath[i].gridY && i < 1)
                {
                    xFlag = true;
                    yFlag = false; 
                    xMoveTo = arg_FinalPath[i + 1].gridX;
                    xIndex = i + 1; 
                    break; 
                } 
                // move in the x direction until there is a change in direction 
                else if (yMoveTo != arg_FinalPath[i].gridY && yMoveToTemp == arg_FinalPath[i].gridY && i < arg_FinalPath.Count)
                {
                    xFlag = true;
                    yFlag = false; 
                    xMoveTo = arg_FinalPath[i - 1].gridX;
                    xIndex = i; 
                    break;
                }
                // if there is a change in direction and both directions change 
                else if (yMoveTo != arg_FinalPath[i].gridY)
                {
                    xIndex = i;
                    xFlag = false; 
                    break;
                }
                else // move temp
                {
                    yMoveToTemp = arg_FinalPath[i].gridX;
                }
            }
        }
        else 
        {
            xIndex = yIndex; // if y is moving move x up to y
        }
        
        // if x is not moving 
        if (!xFlag)
        {
            // loop through the final path index 
            for (int i = yIndex; i < arg_FinalPath.Count; i++)
            {
                // first index edge case 
                if (xMoveTo != arg_FinalPath[i].gridX && xMoveToTemp == arg_FinalPath[i].gridX && i < 1)
                {
                    yFlag = true;
                    xFlag = false; 
                    yMoveTo = arg_FinalPath[i + 1].gridY;
                    yIndex = i + 1; 
                    break; 
                } 
                // moves y until there is a change of direction 
                else if (xMoveTo != arg_FinalPath[i].gridX && xMoveToTemp == arg_FinalPath[i].gridX && i < arg_FinalPath.Count)
                {
                    yFlag = true;
                    xFlag = false; 
                    yMoveTo = arg_FinalPath[i - 1].gridY;
                    yIndex = i; 
                    break;
                }
                // if both directions change at once 
                else if (xMoveTo != arg_FinalPath[i].gridX)
                {
                        yIndex = i;
                        yFlag = false; 
                        break;
                }
                // move temp 
                else 
                {
                    xMoveToTemp = arg_FinalPath[i].gridY;
                }
            }
        }
        else 
        {
            yIndex = xIndex; // move the y index to x index 
        }

        // handles the diagonal edge case 
        if (!xFlag && !yFlag)
        {
            xMoveTo = arg_FinalPath[xIndex].gridX;
            yMoveTo = arg_FinalPath[xIndex].gridY;
            xFlag = false; 
            yFlag = false; 
        }
 
        // returns a list of the x and y indexes
        List<int> intList = new List<int>();
        intList.Add(xIndex);
        intList.Add(yIndex);
        return intList; 
    }

    // moves the object every frame 
    private void MoveObject()
    {
        // Moves the object along the x axis 
        if (xMoveFrom < xMoveTo)
        {
            StartPosition.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (xMoveFrom > xMoveTo)
        {
            StartPosition.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        // moves the object along the y axis 
        if (yMoveFrom < yMoveTo)
        {
            StartPosition.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (yMoveFrom > yMoveTo)
        {
            StartPosition.Translate(Vector3.back * speed * Time.deltaTime);
        }
        
        // recalulates the move to variables if the current x and y movements are completed 
        if ( xMoveFrom == xMoveTo && yMoveFrom == yMoveTo && (StartPosition.position != TargetPosition.position) && grid.FinalPath.Count > finalPathIndex[0])
        {
            finalPathIndex = SetMovement(grid.FinalPath, finalPathIndex[0], finalPathIndex[1]);
        }

        // get new move from positions while the object is moving
        xMoveFrom = grid.GetNodeFromWorldPosition(StartPosition.position).gridX;
        yMoveFrom = grid.GetNodeFromWorldPosition(StartPosition.position).gridY;        
    }
    
    // Determines if the minimized path should be updated 
    private void UpdatePath(Vector3 arg_StartPosition, Vector3 arg_TargetPosition)
    {
        // The closest nodes at the start and end position
        Node StartNode = grid.GetNodeFromWorldPosition(arg_StartPosition);
        Node TargetNode = grid.GetNodeFromWorldPosition(arg_TargetPosition);

        // nodes that have not been evaluated yet
        List<Node> OpenList = new List<Node>();

        // nodes that have been evaluated 
        HashSet<Node> ClosedList = new HashSet<Node>();

        // Starts the open list
        OpenList.Add(StartNode);

        // while there are unevaluated nodes 
        while (OpenList.Count > 0)
        {
            // current node in the list
            Node CurrentNode = OpenList[0];

            // iterates through the nodes in OpenList 
            for (int i = 1; i < OpenList.Count; i++)
            {
                // checks if the object in OpenList is closer to the goal than the current node 
                if (OpenList[i].FCost < CurrentNode.FCost || 
                (OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost))
                {
                    CurrentNode = OpenList[i];
                }
            }

            // Tranfers current node from OpenList to ClosedList
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode); 

            // checks if the current node is the target node
            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            // Finds all the nodes that share an edge with the current node 
            foreach (Node NeighborNode in grid.GetNeighboringNodes(CurrentNode))
            {
                // avoids neighboring nodes that are touching a wall or already in the closed list 
                if (!NeighborNode.isWall || ClosedList.Contains(NeighborNode))
                {
                    continue; // skip this node 
                }
                
                // Calculates the f cost of the Current node 
                int costToMove = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighborNode);

                // if the f cost is greater than the g cost or if the open list does not contain the neighbor node
                if (costToMove < NeighborNode.gCost || !OpenList.Contains(NeighborNode))
                {
                    // set the new g and h cost of the neigbor node and then set its parent for retracing 
                    NeighborNode.gCost = costToMove;
                    NeighborNode.hCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.Parent = CurrentNode;

                    // adds the neighbor node to the open list if it is not in there
                    // since it is a neighbor of the current node it will need to be evaluated 
                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }
        }
    }

    // gets the final path for the pathfinding algorithm 
    private void GetFinalPath(Node arg_StartPosition, Node arg_EndPosition)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = arg_EndPosition;

        // populates the FinalPath list
        while (CurrentNode != arg_StartPosition)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        // Puts the FinalPath in the correct order
        FinalPath.Reverse();

        grid.FinalPath = FinalPath;

        if (grid.FinalPath.Count > 0)
        {
            finalExists = true;
        }
    }

    // Calcuates the h cost by using the manahtten distance of 2 nodes 
    private int GetManhattenDistance(Node arg_NodeA, Node arg_NodeB)
    {
        int x = Mathf.Abs(arg_NodeA.gridX - arg_NodeB.gridX);
        int y = Mathf.Abs(arg_NodeA.gridY - arg_NodeB.gridY);
        return x + y;
    }
}
