using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicScript : MonoBehaviour {
    [SerializeField]
    AudioSource music;

    // Use this for initialization
    void Start () {
        StartCoroutine(LerpMusic());

    }
	
	IEnumerator LerpMusic()
    {
        while (music.volume < PauseMenus.BGMvolume)
        {
            music.volume += .01f;
            if (music.volume > PauseMenus.BGMvolume)
                music.volume = PauseMenus.BGMvolume;
            yield return new WaitForSeconds(.1f);
        }
    }
}
