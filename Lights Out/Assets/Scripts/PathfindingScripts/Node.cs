// Special thanks to "Daniel" youtube channel for his A* tutorial
// https://www.youtube.com/watch?v=AKKpPmxx07w

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Node class that contains all the properties 
    of a node used in the A* pathfinding tutorial 
*/
public class Node
{

    // grid x and y axis 
    public int gridX;
    public int gridY; 

    // g, h and f cost
    public int gCost;
    public int hCost;
    public int FCost { get { return gCost + hCost; }}

    // If the node is touching a wall 
    public bool isWall;

    // Position in Unity
    public Vector3 Position;

    // Preceding node 
    public Node Parent;
    
    // Construtor 
    public Node(bool arg_IsWall, Vector3 arg_Position, int arg_gridX, int arg_gridY)
    {
        isWall = arg_IsWall; // True if the node is obstructed by a wall 
        Position = arg_Position; // Position in the world
        gridX = arg_gridX; // X position
        gridY = arg_gridY; // Y position
    }
}
