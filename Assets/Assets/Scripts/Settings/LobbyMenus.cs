using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenus : MonoBehaviour
{
    enum CurMenu { Basic, Options, Audio, Video };
    private CurMenu curMenu;
    [SerializeField]
    Transform options;
    [SerializeField]
    AudioClip hover;
    [SerializeField]
    AudioClip click;
    [SerializeField]
    AudioSource au;

    public void Options()
    {
        au.PlayOneShot(click, PauseMenus.SFXvolume);
        GameObject myObject = GameObject.Find("Canvas/Menus/Basic/Options");
        myObject.GetComponent<Text>().raycastTarget = false;
        myObject = GameObject.Find("Canvas/Menus/Basic/Leaderboards");
        myObject.GetComponent<Text>().raycastTarget = false;
        myObject = GameObject.Find("Canvas/Menus/Basic/Credits");
        myObject.GetComponent<Text>().raycastTarget = false;
        curMenu = CurMenu.Options;
        GetComponent<Animator>().Play("ToOptions");
        Animator title = GameObject.Find("Canvas/Menus/GameTitle").GetComponent<Animator>();
        title.Play("FlippyFlippy");
        BasicMenusScript.canSelect = false;
    }

    public void Return()
    {
        switch (curMenu)
        {
            default:
                curMenu = CurMenu.Options;
                au.PlayOneShot(click, PauseMenus.SFXvolume);
                break;
            case CurMenu.Options:
                curMenu = CurMenu.Basic;
                GameObject myObject = GameObject.Find("Canvas/Menus/Basic/Options");
                myObject.GetComponent<Text>().raycastTarget = true;
                myObject = GameObject.Find("Canvas/Menus/Basic/Leaderboards");
                myObject.GetComponent<Text>().raycastTarget = true;
                myObject = GameObject.Find("Canvas/Menus/Basic/Credits");
                myObject.GetComponent<Text>().raycastTarget = true;
                GetComponent<Animator>().Play("FromOptions");
                BasicMenusScript.canSelect = true;
                au.PlayOneShot(click, PauseMenus.SFXvolume);
                break;
        }
    }
    public void Higlight()
    {
        Color c = Color.white;
        c.a = .05f;
        au.PlayOneShot(hover, PauseMenus.SFXvolume);
        foreach (Transform item in options)
        {
            item.gameObject.GetComponent<Text>().color = c;
        }
        c.a = 1f;
        UnityEngine.EventSystems.EventSystem myEvent = GameObject.Find("Canvas/EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        //myEvent.currentSelectedGameObject.GetComponent<Outline>().enabled = true;
        myEvent.currentSelectedGameObject.GetComponent<Text>().color = c;
    }
}
