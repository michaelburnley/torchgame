using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
   public Light lightToDim = null;   
   public bool party = false; 
   public float maxTime = 300; //30 seconds
   public float intensity = 10;
   private float mEndTime = 0;
   private float mStartTime = 0;
   private void Start()
   {
    //  GetTotalTorches();
     lightToDim.intensity = intensity;
     mStartTime = Time.time;
     if(party) {
      mEndTime= GetPartyTorcheTime();
     } else {
       mEndTime = mStartTime + maxTime;
     }
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

  private float GetPartyTorcheTime() {
    GameObject party = GameObject.Find("Party");
    float time = 0;
    foreach (Transform child in party.transform) {
      foreach (Transform party_child in child.transform) {
        Torch torch_time = party_child.gameObject.GetComponent(typeof(Torch)) as Torch;
        time = time + torch_time.mEndTime;
      }
    }
    return time;
  }
}
