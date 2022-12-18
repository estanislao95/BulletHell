using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public List<MenuScreen> Screens = new List<MenuScreen>();

    public int currScreen = 0;

    protected virtual void Awake()
    {
        for (int i = 0; i < Screens.Count; i++)
        {
            Screens[i].Hide();
        }

        //currScreen = 0;

        Screens[currScreen].Show();
    }
    protected virtual void Update()
    {

    }

    //public void Play(int SceneNum)
    //{
    //    GameManager.instance.ChangeScene(SceneNum);
    //}
    //
    //public virtual void Quit()
    //{
    //    GameManager.instance.Menu();
    //}

    public void StopPause()
    {
        //GameManager.instance.PauseTheGame();
    }

    public void changeScreen(int nextScreen)
    {
        int oldscreen = currScreen;
        currScreen = nextScreen;

        Screens[nextScreen].Show();
        //if (submenu){return;}
        Screens[oldscreen].Hide();


        if (!Screens[currScreen].gameObject.activeSelf)
        {
            Screens[currScreen].Show();
        }
    }

}
