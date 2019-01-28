using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public int numOfDays;
    public Canvas canvas;
    public Image daySquare;
    public Image resource;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(35f, 733f, 0f);
        for (int i = 1; i <= numOfDays; i++)
        {
            if (i % 8 == 0)
            {
                pos.y -= 70f;
                pos.x = 35f;
            }

            Image Day = Instantiate(daySquare, pos, Quaternion.identity);
            Day.transform.SetParent(canvas.transform);
            Day.GetComponentInChildren<Text>().text = i.ToString();

            pos = new Vector3(pos.x + 70f, pos.y, 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
