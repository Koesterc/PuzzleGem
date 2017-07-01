﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicMenusScript : MonoBehaviour {
    [SerializeField]
    List<GameObject> button = new List<GameObject>();
    UnityEngine.EventSystems.EventSystem myEvent;
    GameObject lastSelected;
    [SerializeField]
    AudioClip hover;
    [SerializeField]
    AudioClip click;
    [SerializeField]
    AudioSource au;
    public static bool canSelect = true; //determiens whether or not the players can select the menu

    bool isLerping = false; //this is used to determine whether or not the coroutine is running

    void Update()
    {
        //if (!myEvent.currentSelectedGameObject)
        //     myEvent.SetSelectedGameObject(lastSelected);

    }


    // Use this for initialization
    void Start ()
    {
        //loading all data
        SaveLoadPrefs.Load();
        au.volume = PauseMenus.SFXvolume;
        //Time.timeScale = PauseMenus.gameSpeed;

        myEvent = GameObject.Find("Canvas/EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        //finding all butons within the menu
        Transform menu = gameObject.transform;
		foreach (Transform child in menu)
        {
            button.Add(child.gameObject);
        }
        myEvent.SetSelectedGameObject(button[0]);
    }
	
	public void SelectingNew()
    {
        if (isLerping || !canSelect)
            return;
        isLerping = true;
        au.PlayOneShot(hover, PauseMenus.SFXvolume);
 
        Color c = button[0].GetComponent<Text>().color;
        c.a = 0;
        Transform menu = gameObject.transform;
        foreach (Transform child in menu)
        {
            child.gameObject.GetComponent<Text>().color = c;
            child.gameObject.GetComponent<Text>().raycastTarget = false;
        }
        if (!myEvent.currentSelectedGameObject)
        return;
        c.a = 1f;
        myEvent.currentSelectedGameObject.GetComponent<Text>().fontSize = 33;
        myEvent.currentSelectedGameObject.GetComponent<Text>().color = c;
        c.a = .05f;
        if (myEvent.currentSelectedGameObject == button[0])
        {
            lastSelected = button[0];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[button.Count-1].GetComponent<Text>().fontSize = 30;
            button[button.Count-1].GetComponent<Text>().color = c;
            button[1].GetComponent<Text>().fontSize = 30;
            button[1].GetComponent<Text>().color = c;
            StartCoroutine(Lerp(transform.rotation,Quaternion.Euler(0, 0, 82), button.Count - 1,1));
            //StartCoroutine(FadeColors(button[0].GetComponent<Text>().color, button[0].GetComponent<Text>(), button[1].GetComponent<Text>(), button[2].GetComponent<Text>(), button[3].GetComponent<Text>()));
            //transform.rotation = Quaternion.Euler(0, 0, 82);
        }
        else if (myEvent.currentSelectedGameObject == button[5])
        {
            lastSelected = button[5];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[4].GetComponent<Text>().fontSize = 30;
            button[4].GetComponent<Text>().color = c;
            button[0].GetComponent<Text>().fontSize = 30;
            button[0].GetComponent<Text>().color = c;
            StartCoroutine(Lerp(transform.rotation, Quaternion.Euler(0, 0, 150), 0,4));
            //transform.rotation = Quaternion.Euler(0, 0, 150);
        }
        else if (myEvent.currentSelectedGameObject == button[1])
        {
            lastSelected = button[1];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[2].GetComponent<Text>().fontSize = 30;
            button[2].GetComponent<Text>().color = c;
            button[0].GetComponent<Text>().fontSize = 30;
            button[0].GetComponent<Text>().color = c;
            button[0].GetComponent<Text>().raycastTarget = true;
            button[2].GetComponent<Text>().raycastTarget = true;
            StartCoroutine(Lerp(transform.rotation, Quaternion.Euler(0, 0, 24), 2, 0));
            // transform.rotation = Quaternion.Euler(0, 0, 24);
        }
        else if (myEvent.currentSelectedGameObject == button[2])
        {
            lastSelected = button[2];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[3].GetComponent<Text>().fontSize = 30;
            button[3].GetComponent<Text>().color = c;
            button[1].GetComponent<Text>().fontSize = 30;
            button[1].GetComponent<Text>().color = c;
            button[3].GetComponent<Text>().raycastTarget = true;
            button[1].GetComponent<Text>().raycastTarget = true;
            StartCoroutine(Lerp(transform.rotation, Quaternion.Euler(0, 0, -32), 3, 1));
            // transform.rotation = Quaternion.Euler(0, 0, -32);
        }
        else if (myEvent.currentSelectedGameObject == button[3])
        {
            lastSelected = button[3];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[4].GetComponent<Text>().fontSize = 30;
            button[4].GetComponent<Text>().color = c;
            button[2].GetComponent<Text>().fontSize = 30;
            button[2].GetComponent<Text>().color = c;
            button[4].GetComponent<Text>().raycastTarget = true;
            button[2].GetComponent<Text>().raycastTarget = true;
            StartCoroutine(Lerp(transform.rotation, Quaternion.Euler(0, 0, 265),4, 2));
            //transform.rotation = Quaternion.Euler(0, 0, 265);
        }
        else if (myEvent.currentSelectedGameObject == button[4])
        {
            lastSelected = button[4];
            lastSelected.GetComponent<Text>().raycastTarget = true;
            button[5].GetComponent<Text>().fontSize = 30;
            button[5].GetComponent<Text>().color = c;
            button[3].GetComponent<Text>().fontSize = 30;
            button[3].GetComponent<Text>().color = c;
            StartCoroutine(Lerp(transform.rotation, Quaternion.Euler(0, 0, 200), 3, 5));
            // transform.rotation = Quaternion.Euler(0, 0, 200);
        }
        foreach (Transform child in menu)
        {
            child.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    IEnumerator Lerp(Quaternion a, Quaternion b, int one, int two)
     {
        Transform menu = gameObject.transform;
        float lerpTime = 0;
        button[one].GetComponent<Text>().raycastTarget = false;
        button[two].GetComponent<Text>().raycastTarget = false;
        while (lerpTime < .2f)
        {
            transform.rotation = Quaternion.Lerp(a, b, (lerpTime/.2f));
            lerpTime += Time.deltaTime;
            yield return new WaitForSeconds(.02f);
        }
        foreach (Transform child in menu)
        {
            child.gameObject.GetComponent<Button>().enabled = true;
        }
        button[one].GetComponent<Text>().raycastTarget = true;
        button[two].GetComponent<Text>().raycastTarget = true;
        transform.rotation = b;
        isLerping = false;
     }

    public void GameStart()
    {
        Color c = button[0].GetComponent<Text>().color;
        c.a = .05f;
        au.PlayOneShot(click, PauseMenus.SFXvolume);
        MusicScript music = GameObject.Find("GameManager/Music").GetComponent<MusicScript>();
        music.StopAllCoroutines();
        music.StartCoroutine(music.MusicOff());
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.GetComponent<Text>().color = c;
            child.gameObject.GetComponent<Text>().raycastTarget = false;
        }
        StartCoroutine(myCor());
    }
    public IEnumerator myCor()
    {
        Animator title = GameObject.Find("Canvas/Menus/GameTitle").GetComponent<Animator>();
        title.Play("Crumble");
        yield return new WaitForSeconds(title.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("Level01");
    }
}
