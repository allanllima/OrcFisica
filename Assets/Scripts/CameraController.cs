using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x,
        player.transform.position.y + offset.y, offset.z);
    }
}
