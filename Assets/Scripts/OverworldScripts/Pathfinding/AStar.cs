using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    public AStarNode[,] grid;
    AStarHeap<AStarNode> openSet;
    public int Width { get; private set; }
    public int Height { get;  private set; }
    public AStar(int w, int h)
    {
        Init(w, h);
    }

    public void Init(int w, int h){
        Width = w;
        Height = h;
        grid = new AStarNode[Width, Height];
        openSet = new AStarHeap<AStarNode>(Width*Height);
        Vector2 startingPos = Vector2.zero;//transform.position;
        //Tiles centered at world center
        // new Vector2(
        //     transform.position.x - (Width/2f - 1f/2f), 
        //     transform.position.y - (Height/2f - 1f/2f));
        for(int i = 0; i < Width; i++){
            for(int j = 0; j < Height; j++) {
                grid[i,j] = new AStarNode(i, j, startingPos + new Vector2(i, j));
            }
        }
        for(int i = 0; i < Width; i++){
            for(int j = 0; j < Height; j++) {
                grid[i,j].AddNeighbors(grid);
            }
        }
    }

    public AStarNode[] FindPath(Vector3 start, Vector3 end){
        return FindPath(GetClosest(start), GetClosest(end));
    }

    public AStarNode[] FindPath(AStarNode start, AStarNode end){
        openSet.Clear();
        openSet.Add(start);
        List<AStarNode> closedSet = new();
        (start.gCost, start.hCost) = (0, 0);
        while(openSet.Count > 0){
            AStarNode current = openSet.RemoveFirst();
            closedSet.Add(current);
            if(current == end) break;
            foreach(AStarNode neighbor in current.neighbors){
                if(closedSet.Contains(neighbor)) continue;
                
                if(!openSet.Contains(neighbor)) openSet.Add(neighbor);
                
                neighbor.gCost = current.gCost + 1 <= neighbor.gCost ? current.gCost + 1 : neighbor.gCost;
                neighbor.hCost = Vector2Int.Distance(neighbor.gridPosition, end.gridPosition);
            }
        }
        return closedSet.ToArray();
    }

    public AStarNode GetClosest(Vector3 pos){
        AStarNode winner = grid[0, 0];
        float winningDist = Mathf.Infinity;
        foreach(AStarNode node in grid){
            float d = Vector3.Distance(pos, node.actualPosition);
            if(d > winningDist){
                continue;
            }
            winner = node;
            winningDist = d;
        }
        return winner;
    }

}
