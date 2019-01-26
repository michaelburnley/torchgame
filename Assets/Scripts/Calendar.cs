﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public float numOfDays;
    public Canvas canvas;
    public Image daySquare;
    public Image checkOffX;
    public Image resource;
    public Text dayNum;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(35f, 733f, 0f);
        float updateX = pos.x;

        for (int i = 0; i <= numOfDays; i++)
        {                    
            if (i%8 == 0)
            {
                pos.y -= 100f;
                pos.x = 35f;
            }
            
            Image Day = Instantiate(daySquare, pos, Quaternion.identity);
            Day.transform.SetParent(canvas.transform);
            Day.GetComponentInChildren<Text>().text = i.ToString();

            pos.x =+ 70f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
