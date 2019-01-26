﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
   public Light lightToDim = null;    
   public float maxTime = 300; //30 seconds
   public float intensity = 10;
   private float mEndTime = 0;
   private float mStartTime = 0;
   private void Start()
   {
     lightToDim.intensity = intensity;
     mStartTime = Time.time;
     mEndTime= mStartTime + maxTime;
   }
   private void Update()
   {
     if(lightToDim)
       lightToDim.intensity = lightToDim.intensity - Mathf.InverseLerp(mStartTime, mEndTime, Time.time);
   }

   private void AddTime(float additionalTime) {
       mEndTime = mEndTime + additionalTime;
   }

   private void OnTriggerEnter(Collider other) {
       
   }
}
