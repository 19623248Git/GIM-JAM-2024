using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int Width;
    public int Height;
    public int X;
    public int Y;
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("You press play in the wrong scene");
            return;
        }
        RoomController.instance.RegisterRoom(this);
    }


    void OnDrawGizmos()
    {
        // Get the center position of the room
        Vector3 roomCenter = GetRoomCentre();

        // Calculate half of the width and height
        float halfWidth = Width * 0.5f;
        float halfHeight = Height * 0.5f;

        // Draw wire cube using the center position and half dimensions
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(roomCenter, new Vector3(Width, Height, 0));
    }



    public Vector3 GetRoomCentre()
    {
        // Calculate the center position of the room
        float centerX = (X + 0.5f) * Width;
        float centerY = (Y + 0.5f) * Height;

        return new Vector3(centerX, centerY, 0);
    }

}
