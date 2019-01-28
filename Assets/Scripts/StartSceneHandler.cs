using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartSceneHandler : MonoBehaviour
{
    public float fadewait;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        FadeLevelChange.fadeIn = true;
        StartCoroutine(FadoutWait());
    }

    public IEnumerator FadoutWait()
    {
        yield return new WaitForSeconds(fadewait);
        FadeLevelChange.level = scene;
        FadeLevelChange.fadeOutEnd = true;
    }
}
