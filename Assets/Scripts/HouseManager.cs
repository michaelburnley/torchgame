using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public Calendar calendar;
    public GameObject party;
    public int Days;
    private int completed_days = 0;
    private int currentDay = 1;
    private int torch_level;

    private GameObject player;
    private GameObject player_torch;
    private Component calendar;

    private GameObject[] daySheets; 

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<=Days; i++)
        {
            daySheets = GameObject.FindGameObjectsWithTag("Calendar");
        }
        Instantiate(party, transform.position, Quaternion.identity);
        player = GameObject.Find("Player");
        player_torch = player.transform.GetChild(0);
        torch_level = player_torch.intensity;
        calendar = GetComponent<Calendar>();
        calendar.numOfDays = Days;
        Debug.Log("Game Start");
        
    }

    // Update is called once per frame
    void Update()
    {
       checkTorchLevel();
       updateCalendar;
    }

    void checkTorchLevel() {
        torch_level = player_torch.intensity;
        if(torch_level <= 0) {
            GameOver();
        }
    }

    void updateCalendar() {
        
        for (int i = 0; i < completed_days - 1; i++)
        {
            Image x = daySheets[i].transform.GetChild(1);
            Color color = x.GetComponent<Image>().color;
            color.a = 1;
            x.GetComponent<Image>().color = color;    
        }
    }

    void GameOver() {
        Debug.Log("Game Over");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EndDay();
        }
    }


    void EndDay()
    {
        if(player.gas_cans == 0) {
            GameOver();
        } else if {
            completed_days += player.gas_cans;
            party.transform.position = transform.position;
            updateCalendar();
        }

        //fade out
        //deactivate script
    }



}
