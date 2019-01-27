using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public GameObject party;
    public GameObject plrSpawnPoint;
    public int Days;
    public float fadeWaitTime;
    private int completed_days = 0;
    private int currentDay = 1;
    private float torch_level;

    private GameObject player;
    private GameObject player_torch;
    //private Calendar calendar;

    private GameObject[] daySheets; 

    // Start is called before the first frame update
    void Start()
    {
        FadeLevelChange.fadeIn = true;
        for (int i = 0; i<=Days; i++)
        {
            daySheets = GameObject.FindGameObjectsWithTag("Calendar");
        }
       // Instantiate(party, plrSpawnPoint.transform.position, Quaternion.identity);
        player = GameObject.Find("Player");
        player_torch = player.transform.GetChild(0).gameObject;
       // calendar = GetComponent<Calendar>();
        GetComponent<Calendar>().numOfDays = Days;
        Debug.Log("Game Start");
       
    }

    // Update is called once per frame
    void Update()
    {
       checkTorchLevel();
       updateCalendar();
    }

    void checkTorchLevel() {
        
        if(player_torch.GetComponent<Torch>().intensity <= 0) {
            GameOver();
        }
    }

    void updateCalendar() {
        
        for (int i = 0; i < completed_days - 1; i++)
        {
            Image x = daySheets[i].transform.GetChild(1).GetComponent<Image>();
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
        player.GetComponent<Player>().enabled = false;
        if(player.GetComponent<Player>().gas_cans == 0) {
            FadeLevelChange.level = "GameOver";
            FadeLevelChange.fadeOutEnd = true;           
            GameOver();
        }
        if (completed_days >= Days)
        {
            FadeLevelChange.level = "WinScreen";
            FadeLevelChange.fadeOutEnd = true;

        }
        else {
            FadeLevelChange.fadeOut = true;
            completed_days += player.GetComponent<Player>().gas_cans;
            StartCoroutine(Fade());            
        }
                
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(fadeWaitTime);
        party.transform.position = transform.position;
        updateCalendar();
        FadeLevelChange.fadeIn = true;
        player.GetComponent<Player>().enabled = true;
    }



}
