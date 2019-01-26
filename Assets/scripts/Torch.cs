using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
   public Light lightToDim = null;    
   public float maxTime = 30; //30 seconds
   private float mEndTime = 0;
   public float mStartTime = 30;
   private void Awake()
   {
     mStartTime = Time.time;
     mEndTime= mStartTime + maxTime;
   }
   private void Update()
   {
     if(lightToDim)
       lightToDim.intensity = lightToDim.intensity - Mathf.InverseLerp(mStartTime, mEndTime, Time.time);
   }

   private void AddTime() {
       
   }
}
