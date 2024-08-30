using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode  : IHeapItem<AStarNode>
{
    public Vector2Int gridPosition;
    public Vector2 actualPosition;
    public List<AStarNode> neighbors;
    int heapIndex;
    public int HeapIndex {get {	return heapIndex;}set {	heapIndex = value;}}
    public float gCost = 0, hCost = 0;
    public float fCost {get{return gCost + hCost;}}

    public AStarNode(int gridX, int gridY, Vector2 actualPos){
        gridPosition = new Vector2Int(gridX, gridY);
        actualPosition = actualPos;
        neighbors = new();
    }

    public void AddNeighbors(AStarNode[,] grid){
        int width = grid.GetLength(0);
        int height =  grid.GetLength(1);
        for(int i = -1; i < 2; i++){
            int x  = i + gridPosition.x;
            for(int j = -1; j < 2; j++){
                int y = j + gridPosition.y;

                if(x < 0 || y < 0 || x >= width || y >= height || (gridPosition.x == x && gridPosition.y == y)) continue;

                neighbors.Add(grid[x,y ]);
            }
        }
    }

    public void RenderGizmos(float cellDimensions){
        AStarEditor.DrawString($"{neighbors.Count}", actualPosition, Color.black);
        Gizmos.DrawCube(actualPosition, new Vector3(cellDimensions, cellDimensions, cellDimensions));
    }

    public int CompareTo(AStarNode nodeToCompare) {
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if (compare == 0) {
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}
