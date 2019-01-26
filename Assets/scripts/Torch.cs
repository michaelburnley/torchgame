using System.Collections;
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
     GetTotalTorches();
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

  private float GetPartyTorches() {
    GameObject party = GameObject.Find("party");
    float time = 0;
    foreach (Transform child in party.transform) {
      time = time + child.mEndTime;
    }
    return time;
  }

   private float GetTotalTorches() {
      GameObject[] torches = FindGameObjectsWithTag("torch");
      float time = 0;;
      // float intensity;
      foreach (GameObject element in torches) {
        time = time + element.mEndTime;
        // intensity = intensity + object.intensity;
      }
      return time;
   }
}
