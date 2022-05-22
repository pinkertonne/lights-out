// Special thanks to "Daniel" youtube channel for his A* tutorial
// https://www.youtube.com/watch?v=AKKpPmxx07w

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class implements the A* pathfinding algorithm 
public class PathFinding : MonoBehaviour
{
    // grid class reference 
    Grid grid;

    // the start and end positions in Unity
    public Transform StartPosition;
    public Transform TargetPosition;

    // Called at the beginning of the scene
    private void Awake()
    {
        grid = GetComponent<Grid>(); // gets grid component
    }

    // Runs for every frame
    private void Update()
    {
        UpdatePath(StartPosition.position, TargetPosition.position);
    }

    // Determines if the minimized path should be updated 
    void UpdatePath(Vector3 arg_StartPosition, Vector3 arg_TargetPosition)
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
    void GetFinalPath(Node arg_StartPosition, Node arg_EndPosition)
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
    }

    // Calcuates the h cost by using the manahtten distance of 2 nodes 
    int GetManhattenDistance(Node arg_NodeA, Node arg_NodeB)
    {
        int x = Mathf.Abs(arg_NodeA.gridX - arg_NodeB.gridX);
        int y = Mathf.Abs(arg_NodeA.gridY - arg_NodeB.gridY);
        return x + y;
    }

}
