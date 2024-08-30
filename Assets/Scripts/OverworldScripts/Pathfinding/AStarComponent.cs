using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarComponent : MonoBehaviour
{
    public AStar pathfinding;
    public int width, height;
    [Header("Debug Values")]
    [Range(0f, 1f)]
    public float cellDimensions;

    public void Awake(){
        if(pathfinding == null) pathfinding = new(width, height);
        else pathfinding.Init(width, height);
    }

    // public void Update(){
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     path = pathfinding.FindPath(Vector3.zero, mousePos);
    // }

    // AStarNode[] path;
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        if(pathfinding == null || pathfinding.grid == null) return;
        foreach (var item in pathfinding.grid)
        {
            item.RenderGizmos(cellDimensions);
        }
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(transform.position, Vector3.one);
    //     if(path == null) return;
    //     Gizmos.color = Color.blue;
    //     foreach(AStarNode node in path){
    //         node.RenderGizmos(cellDimensions) ;
    //     }
    //     Gizmos.color = Color.white;
    //     path[0].RenderGizmos(cellDimensions);
    //     Gizmos.color = Color.green;
    //     path[^1].RenderGizmos(cellDimensions);
    // }
}
