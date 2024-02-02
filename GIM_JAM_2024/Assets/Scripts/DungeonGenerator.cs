using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Three", 0, 0);

        // Create a list containing the possible room names
        List<string> roomNames = new List<string> { "One", "Two", "Three", "Four","Five", "Six" };

        foreach (Vector2Int roomLocation in rooms)
        {
            // Get a random room name from the list
            string randomRoomName = GetRandomRoomName(roomNames);

            // Load the room using the random room name
            RoomController.instance.LoadRoom(randomRoomName, roomLocation.x, roomLocation.y);
        }
    }

    private string GetRandomRoomName(List<string> roomNames)
    {
        // Get a random index within the range of the room names list
        int randomIndex = Random.Range(0, roomNames.Count);

        // Return the room name at the random index
        return roomNames[randomIndex];
    }
}
