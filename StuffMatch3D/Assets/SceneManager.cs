using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] public GameObject bkg;
    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject game;
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject notime;
    [SerializeField] public GameObject win;
    [SerializeField] public GameObject fail;
    [SerializeField] public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        bkg.SetActive(false);
        menu.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        notime.SetActive(false);
        win.SetActive(false);
        fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("MainMenuScreen showed via function");
    }

    public void ShowGameplay()
    {
        bkg.SetActive(false);
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        notime.SetActive(false);
        win.SetActive(false);
        fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("GameplayScreen showed via function");
    }

    public void ShowPause()
    {
        bkg.SetActive(true);
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(true);
        notime.SetActive(false);
        win.SetActive(false);
        fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("PauseScreen showed via function");
    }

    public void ShowNoTime()
    {
        bkg.SetActive(true);
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(false);
        notime.SetActive(true);
        win.SetActive(false);
        fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("NoTimeLeftScreen showed via function");
    }

    public void ShowWin()
    {
        bkg.SetActive(true);
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(false);
        notime.SetActive(false);
        win.SetActive(true);
        fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("WinScreen showed via function");
    }

    public void ShowFail()
    {
        bkg.SetActive(true);
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(false);
        notime.SetActive(false);
        win.SetActive(false);
        fail.SetActive(true);
        shop.SetActive(false);
        Debug.Log("FailScreen showed via function");
    }

    public void ShowStore()
    {
        //bkg.SetActive(false);
        //menu.SetActive(false);
        //game.SetActive(false);
        //pause.SetActive(false);
        //notime.SetActive(false);
        //win.SetActive(false);
        //fail.SetActive(false);
        shop.SetActive(true);
        Debug.Log("ShopScreen showed via function");
    }

    public void HideStore()
    {
        //bkg.SetActive(false);
        //menu.SetActive(false);
        //game.SetActive(false);
        //pause.SetActive(false);
        //notime.SetActive(false);
        //win.SetActive(false);
        //fail.SetActive(false);
        shop.SetActive(false);
        Debug.Log("ShopScreen hided via function");
    }
}
