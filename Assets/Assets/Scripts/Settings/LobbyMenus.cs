using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenus : MonoBehaviour {
    enum CurMenu {Basic, Options, Audio, Video };
    private CurMenu curMenu;

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
}
