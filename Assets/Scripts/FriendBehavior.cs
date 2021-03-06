﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public GameObject Party;
    public bool orderInLine;
    public float step;//Set = to players speed;
    public float maxDistance;    
    public bool okToFollow;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Party = GameObject.Find("Party");
               
    }

    // Update is called once per frame
    void Update()
    {
        if (okToFollow)
        {
            Transform friendToFollow = transform.parent.transform.GetChild(transform.GetSiblingIndex() - 1);
            
            if (Vector2.Distance(transform.position, friendToFollow.position) >= maxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, friendToFollow.position, step);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            Transform mytorch = transform.GetChild(0);
            mytorch.gameObject.GetComponent<Torch>().inParty = true;
            transform.SetParent(Party.transform);
            okToFollow = true;
            

            
        }
    }

}
