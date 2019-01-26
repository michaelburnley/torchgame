using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
   public Light lightToDim = null;   
   public bool inParty = false; 
   private GameObject party;
   public int nextPartyCount;
   public int prevPartyCount;
   public float maxTime = 300; //30 seconds
   public float intensity = 10;
   private float mEndTime = 30;
   private float mStartTime = 0;

   private void Awake() {
     party = GameObject.Find("Party");
     nextPartyCount = party.transform.childCount;
     prevPartyCount = party.transform.childCount;
   }
   private void Start()
   {
    //  GetTotalTorches();
     lightToDim.intensity = intensity;
     mStartTime = Time.time;
     mEndTime = mStartTime + mEndTime;
   }
   private void Update()
   {
     if(lightToDim) {
       if(inParty) {
        lightToDim.intensity = lightToDim.intensity - Mathf.InverseLerp(mStartTime, mEndTime, Time.time);
       }
     }

     nextPartyCount = party.transform.childCount;

     if(nextPartyCount > prevPartyCount) {
      //  mEndTime = GetPartyTorchTime() / nextPartyCount;
       mEndTime = mEndTime + (mEndTime * nextPartyCount);
       lightToDim.intensity = intensity;
       prevPartyCount = nextPartyCount;
     }
   }

   private void AddTime(float additionalTime) {
       mEndTime = mEndTime + additionalTime;
   }

   private void OnTriggerEnter(Collider other) {
       
   }

  private float GetPartyTorchTime() {
    float time = 0;
    int runtimes = 0;
    foreach (Transform child in party.transform) {
      foreach (Transform party_child in child.transform) {
        Torch torch_time = party_child.gameObject.GetComponent<Torch>();
        time = time + torch_time.mEndTime;
      }
    }
    return time;
  }
}
