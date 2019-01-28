using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{

    public float offsetX = 0;
    public float offsetY = 0;
    public Player player;
    public GameObject monster;
    public GameObject player_torch;
    public float player_torch_intensity;
    public float time;
    private float boundX;
    private float boundY;
    private Vector3 bounds;
    private bool isFollowing;

    // Use this for initialization
    void Start()
    {
        time = Time.time;
        player = FindObjectOfType<Player>();
        player_torch = player.transform.GetChild(0).gameObject;
        player_torch_intensity = player_torch.GetComponent<Torch>().intensity;
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        MonsterAppear();
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, 0);
    }
    void MonsterAppear() {
        if(player_torch.GetComponent<Torch>().intensity <= player_torch_intensity / 2 ) {
            Image x = GetComponent<Image>();
            Color color = x.GetComponent<Image>().color;
            color.a = 1 - (player_torch.GetComponent<Torch>().intensity / player_torch_intensity);
            x.GetComponent<Image>().color = color;
            offsetX -= .15f*(Time.time - time);
            offsetY -= .15f*(Time.time - time);
        } /*else {
            Image x = GetComponent<Image>();
            Color color = x.GetComponent<Image>().color;
            color.a = 0;
            x.GetComponent<Image>().color = color;    
        }
*/    }

    
}