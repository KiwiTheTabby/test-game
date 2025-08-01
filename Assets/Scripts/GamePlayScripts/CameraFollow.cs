using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Camera camera;
    public RoomStats room;

    //Camera is 18 by 10 at size 5

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        if (camera.orthographicSize * 1.8 + playerTransform.position.x > room.roomWidth / 2)
        {
            transform.position = new Vector3(-camera.orthographicSize * 1.8f + room.roomWidth / 2, transform.position.y, -10);
        }
        else if (-camera.orthographicSize * 1.8 + playerTransform.position.x < room.roomWidth / -2)
        {
            transform.position = new Vector3(room.roomWidth / -2 + camera.orthographicSize * 1.8f, transform.position.y, -10);
        }

        if (camera.orthographicSize + playerTransform.position.y > room.roomHeight / 2)
        {
            transform.position = new Vector3(transform.position.x, room.roomHeight / 2 - camera.orthographicSize, -10);
        }
        else if (-camera.orthographicSize + playerTransform.position.y < room.roomWidth / -2)
        {
            transform.position = new Vector3(transform.position.x, room.roomHeight / -2 + camera.orthographicSize, -10);
        }
    }

}
