using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomInfo
{
    public string name;
    public int X;
    public int Y;
}

public class RoomController : MonoBehaviour
{

    public static RoomController instance;
    string currentWorldName = "Basement";
    RoomInfo currentLoadRoomData;
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isloadingRoom = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        List<Vector2Int> loadedPositions = new List<Vector2Int>();

        // Load the starting room
        LoadRoom("Start", 0, 0);
        loadedPositions.Add(new Vector2Int(0, 0));

        // Loop to load additional rooms
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;

            // Determine the position to load the room
            int x = 0;
            int y = 0;

            if (i % 2 == 0)
            {
                x = i < 2 ? randomNumber : 0;
                y = i >= 2 ? randomNumber : 0;
            }
            else
            {
                x = i < 2 ? (randomNumber == 1 ? -1 : 1) : 0;
                y = i >= 2 ? (randomNumber == 1 ? -1 : 1) : 0;
            }

            // Check if the position is already loaded
            Vector2Int position = new Vector2Int(x, y);
            if (!loadedPositions.Contains(position))
            {
                // Load the room if the position is not loaded
                LoadRoom("Empty", x, y);
                loadedPositions.Add(position);
            }
        }
    }






    void Update()
    {
        updateRoomQueue();
    }

    void updateRoomQueue()
    {
        if (isloadingRoom)
        {
            return;
        }

        if (loadRoomQueue.Count == 0)
        {
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isloadingRoom = true;
        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    public void LoadRoom(string name, int x, int y)
    {
        if (DoesRoomExist(x, y))
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;
        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        while (loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    // Define the starting position of the grid

    // Other existing code...

    public void RegisterRoom(Room room)
    {
        // Calculate the position of the room based on its X and Y coordinates
        Vector3 roomPosition = new Vector3(
            currentLoadRoomData.X * room.Width,
            currentLoadRoomData.Y * room.Height,
            0
        );

        // Set the position of the room
        room.transform.position = roomPosition;

        // Set room's properties
        room.X = currentLoadRoomData.X;
        room.Y = currentLoadRoomData.Y;
        room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + ", " + room.Y;
        room.transform.parent = transform;

        // Update loading state and room list
        isloadingRoom = false;
        loadedRooms.Add(room);
    }








    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;
    }

}

