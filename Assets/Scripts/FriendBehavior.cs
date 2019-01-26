using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public GameObject[] friends;
    public bool orderInLine;
    public float step;//Set = to players speed;
    public float maxDistance;
    
    public bool okToFollow;
    private bool following;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        okToFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(okToFollow)
        {
            Transform friendToFollow;
            if (transform.GetSiblingIndex() == 0)
            {
                friendToFollow = player.transform;
            }
            else
            {
                friendToFollow = player.transform.GetChild(transform.GetSiblingIndex() - 1);
            }
            
            if (Vector2.Distance(transform.position, friendToFollow.position) >= maxDistance)
            {
                following = true;               
            }
            else
            {
                following = false;
            }

            if(following)
            {
                transform.position = Vector3.MoveTowards(transform.position, friendToFollow.position, step);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name =="Player")
        {
            transform.SetParent(collision.transform);
            okToFollow = true;
            
        }
    }

}
