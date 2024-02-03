using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,
    left = 1,
    down = 2,
    right = 3,
}

public class DungeonCrawler
{
    public Vector2Int Position { get; set; }

    public DungeonCrawler(Vector2Int startPos)
    {
        Position = startPos;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap, List<Vector2Int> positionsVisited)
    {
        // Check if all directions lead to visited positions, if so, choose randomly
        bool allVisited = true;
        foreach (Vector2Int direction in directionMovementMap.Values)
        {
            Vector2Int newPos = Position + direction;
            if (!positionsVisited.Contains(newPos))
            {
                allVisited = false;
                break;
            }
        }

        // Choose a direction randomly if all lead to visited positions
        if (allVisited)
        {
            Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
            Position += directionMovementMap[toMove];
            return Position;
        }

        // Otherwise, bias movement towards unvisited areas
        List<Direction> unvisitedDirections = new List<Direction>();
        foreach (KeyValuePair<Direction, Vector2Int> kvp in directionMovementMap)
        {
            Vector2Int newPos = Position + kvp.Value;
            if (!positionsVisited.Contains(newPos))
            {
                unvisitedDirections.Add(kvp.Key);
            }
        }

        // Choose a random unvisited direction
        Direction randomDirection = unvisitedDirections[Random.Range(0, unvisitedDirections.Count)];
        Position += directionMovementMap[randomDirection];
        return Position;
    }
}