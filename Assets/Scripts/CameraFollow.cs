using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Player player;

    private float boundX;
    private float boundY;
    private Vector3 bounds;
    private bool isFollowing;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }


        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}