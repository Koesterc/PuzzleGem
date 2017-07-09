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

    public void Options()
    {
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
                break;
        }
    }
    public void Higlight()
    {
        Color c = Color.white;
        c.a = .05f;
        foreach (Transform item in options)
        {
            //item.gameObject.GetComponent<Outline>().enabled = false;
            item.gameObject.GetComponent<Text>().color = c;
            // item.gameObject.SetActive(false);
        }
        c.a = 1f;
        UnityEngine.EventSystems.EventSystem myEvent = GameObject.Find("Canvas/EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        //myEvent.currentSelectedGameObject.GetComponent<Outline>().enabled = true;
        myEvent.currentSelectedGameObject.GetComponent<Text>().color = c;
    }
}
