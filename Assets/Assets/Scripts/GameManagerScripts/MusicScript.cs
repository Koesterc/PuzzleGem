using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour
{
    [SerializeField]
    AudioClip[] music;
    public static AudioSource auSource;

    private void Start()
    {
        auSource = gameObject.GetComponent<AudioSource>();
        int temp = Random.Range (0, music.Length);
        auSource.clip = music[temp];
        auSource.Play();

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
