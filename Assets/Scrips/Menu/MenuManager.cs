using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Menu
{
    public static MenuManager instance;
    public string ButtonName, MenuMusic, GameMusic;


    protected override void Awake()
    {
        instance = this;
        base.Awake();
    }

    private void Start()
    {
        AudioManager.instance.Play(MenuMusic, true);
        GameManager.Instance.PauseTime();
    }

    protected override void Update()
    {



    }





    public void start()
    {
        GameManager.Instance.ContinueTime();
        GameManager.Instance.LoadLevel();
        AudioManager.instance.Play(GameMusic, true);
    }
    public void exit()
    {
        Application.Quit();
    }



    public void ButtonNoice()
    {
        AudioManager.instance.Play(ButtonName);
    }

}
