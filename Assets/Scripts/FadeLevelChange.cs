using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeLevelChange : MonoBehaviour {

    Animator anim;
    public static bool fadeIn;
    public static bool fadeOutEnd;
    public static bool fadeOut;
    public static string level;

	// Use this for initialization
	void Start () {
        fadeIn = false;
        fadeOut = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (fadeIn == true)
        {
            anim.SetBool("FadeIn", true);
            anim.SetBool("FadeOut", false);
    
        }
        if (fadeOut == true)
        {
            anim.SetBool("FadeOut", true);
            anim.SetBool("FadeIn", false);
        }
        if(fadeOutEnd == true)
        {
            anim.SetBool("FadeOut", true);

            StartCoroutine(LoadLevel());
        }
		
	}

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

}
