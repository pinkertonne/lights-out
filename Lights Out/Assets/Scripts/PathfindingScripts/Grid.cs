// Special thanks to "Daniel" youtube channel for his A* tutorial
// https://www.youtube.com/watch?v=AKKpPmxx07w

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This class contains data for the 2d grid
    plane that the A* pathfinding algorithm will
    ultilize 
*/
public class Grid : MonoBehaviour
{
    // collision and position vars
    public Transform StartPosition;
    public LayerMask WallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float distance; 

    // grid vars
    Node[,] NodeArray;
    public List<Node> FinalPath; 
    float nodeDiameter; 
    int gridSizeX;
    int gridSizeY;
    

    // Start method at the beginning of the program
    // calculates the dimensions of the grid 
    private void Start()
    {
        nodeDiameter = nodeRadius * 2; 
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    // Greates the grid
    private void CreateGrid()
    {
        int num = 0;
        NodeArray = new Node[gridSizeX, gridSizeY];
        // calculates the bottom left position of the grid 
        Vector3 bottomLeft = transform.position - 
            Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; 
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // calculates the world position of the current node 
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + 
                    Vector3.forward * (y * nodeDiameter + nodeRadius);
                
                // assumes that the node is touching a wall 
                bool wall = true; 

                // Checks if currently colliding with a wall
                if (Physics.CheckSphere(worldPoint, nodeRadius, WallMask))
                {
                    wall = false; 
                }
                // create a new node in the grid array 
                NodeArray[x, y] = new Node(wall, worldPoint, x, y);   
                num++;
            }
        }
        Debug.Log("the number of nodes is   " + num);
    }

    // gets the closest node to a vector3's world position
    public Node GetNodeFromWorldPosition(Vector3 arg_WorldPosition)
    {
        float xPoint = ((arg_WorldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float yPoint = ((arg_WorldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);

        xPoint = Mathf.Clamp01(xPoint);
        yPoint = Mathf.Clamp01(yPoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);

        return NodeArray[x, y]; 
    }

    // gets a list of nodes that share an edge with the argument node 
    public List<Node> GetNeighboringNodes(Node arg_Node)
    {
        List<Node> NeighborNodeList = new List<Node>();
        int xCheck, yCheck; // makes sure the Node is in range 

        // check right side 
        xCheck = arg_Node.gridX + 1;
        yCheck = arg_Node.gridY;
        
        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check diagonal top right side 
        xCheck = arg_Node.gridX + 1;
        yCheck = arg_Node.gridY + 1; 

        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }
        
        // check left side 
        xCheck = arg_Node.gridX - 1;
        yCheck = arg_Node.gridY;
        
        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check diagonal top left side 
        xCheck = arg_Node.gridX - 1;
        yCheck = arg_Node.gridY - 1; 

        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check top side
        xCheck = arg_Node.gridX;
        yCheck = arg_Node.gridY + 1;
        
        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check bottom side 
        xCheck = arg_Node.gridX;
        yCheck = arg_Node.gridY - 1;
        
        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check diagonal bottom left side
        xCheck = arg_Node.gridX - 1;
        yCheck = arg_Node.gridY - 1; 

        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        // check diagonal bottom right side
        xCheck = arg_Node.gridX + 1;
        yCheck = arg_Node.gridY - 1; 

        if (xCheck >= 0 &&  xCheck < gridSizeX && yCheck >= 0 && yCheck < gridSizeY)
        {
            NeighborNodeList.Add(NodeArray[xCheck, yCheck]);
        }

        return NeighborNodeList;
    }

    // Draws the grid from the CreateGrid method
    private void OnDrawGizmos()
    {
        // Grid box
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        //Debug.Log(FinalPath == null) + " " + grid == null;

        // checks if grid is initializes
        if (NodeArray != null)
        {
            // loops through each node and sees if it is touching a wall 
            foreach(Node node in NodeArray)
            {
                // coloring based on if it is a wall
                if (node.isWall)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                // sets the final path color
                if (FinalPath != null && FinalPath.Contains(node))
                {
                    
                    Gizmos.color = Color.red;
                }

                // draws the nodes 
                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - distance));
            }
        }
    }

}
