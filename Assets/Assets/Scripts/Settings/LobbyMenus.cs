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
        myObject.GetComponent<Animator>().enabled = false;
        myObject.GetComponent<Text>().raycastTarget = false;
        myObject = GameObject.Find("Canvas/Menus/Basic/Leaderboards");
        myObject.GetComponent<Text>().raycastTarget = false;
        myObject = GameObject.Find("Canvas/Menus/Basic/Credits");
        myObject.GetComponent<Text>().raycastTarget = false;
        curMenu = CurMenu.Options;
        GetComponent<Animator>().Play("ToOptions",0,0);
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
                GetComponent<Animator>().Play("FromOptions");
                au.PlayOneShot(click, PauseMenus.SFXvolume);
                StartCoroutine(FromOptions());
                break;
        }
    }
    IEnumerator FromOptions()
    {
        while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            yield return null;
        GameObject myObject = GameObject.Find("Canvas/Menus/Basic/Options");
        myObject.GetComponent<Animator>().enabled = true;
        myObject = GameObject.Find("Canvas/Menus/Basic/Options");
        myObject.GetComponent<Text>().raycastTarget = true;
        myObject = GameObject.Find("Canvas/Menus/Basic/Leaderboards");
        myObject.GetComponent<Text>().raycastTarget = true;
        myObject = GameObject.Find("Canvas/Menus/Basic/Credits");
        myObject.GetComponent<Text>().raycastTarget = true;
        BasicMenusScript.canSelect = true;
    }

    public void Higlight()
    {
        Color c = Color.white;
        c.a = .05f;
        au.PlayOneShot(hover, PauseMenus.SFXvolume);
        foreach (Transform item in options)
        {
            item.gameObject.GetComponent<Text>().color = c;
            item.gameObject.GetComponent<Animator>().enabled = false;
        }
        c.a = 1f;
        UnityEngine.EventSystems.EventSystem myEvent = GameObject.Find("Canvas/EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        //myEvent.currentSelectedGameObject.GetComponent<Outline>().enabled = true;
        myEvent.currentSelectedGameObject.GetComponent<Text>().color = c;
        myEvent.currentSelectedGameObject.GetComponent<Animator>().enabled = true;
    }
}
