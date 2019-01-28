using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public GameObject party;
    public GameObject plrSpawnPoint;
    public Image X;
    public int Days;
    public float fadeWaitTime;
    private int completed_days = 0;
    private int currentDay = 1;
    private float torch_level;

    public GameObject player;
    private GameObject player_torch;
    private float max_torch_intensity;
    private float torch_end;
    //private Calendar calendar;

    private GameObject[] daySheets; 

    // Start is called before the first frame update
    void Start()
    {
        FadeLevelChange.fadeIn = true;

        
        Debug.Log(daySheets.Length);
       // Instantiate(party, plrSpawnPoint.transform.position, Quaternion.identity);
        player = GameObject.Find("Player");
        player_torch = player.transform.GetChild(0).gameObject;
        max_torch_intensity = player_torch.GetComponent<Torch>().intensity;
        torch_end = player_torch.GetComponent<Torch>().mEndTime;
        Debug.Log("Max torch intensity" + max_torch_intensity);
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
        
        if(player.GetComponent<Player>().failed == true) {
            GameOver();
        }
    }

    void updateCalendar() {
        daySheets = GameObject.FindGameObjectsWithTag("Calendar");
        for (int i = 0; i < completed_days - 1; i++)
        {
            Image xImage = Instantiate(X, daySheets[i].transform.position, Quaternion.identity);
            xImage.transform.SetParent(daySheets[i].transform);
        }
    }

    void GameOver() {
        FadeLevelChange.level = "GameOver";
        FadeLevelChange.fadeOutEnd = true;  
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
            player.GetComponent<Player>().gas_cans = 0;
            StartCoroutine(Fade());            
        }
                
    }

    void StartOfDay()
    {
        party.transform.position = plrSpawnPoint.transform.position;
        // updateCalendar();
        player.GetComponent<Player>().enabled = true;
    }

    public IEnumerator Fade()
    {        
        yield return new WaitForSeconds(fadeWaitTime);
        FadeLevelChange.fadeOut = false;
        FadeLevelChange.fadeIn = true;
        yield return new WaitForSeconds(1.25f);
        StartOfDay();

    }



}
