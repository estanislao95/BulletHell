using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : Menu
{
    public int _Game, _Dead, _Victory, _PauseMenu;
    public static GameMenuManager instance;
    public string ButtonName, VicotoryMusic, DeadMusic, MenuMusic, GameMusic;


    void Start()
    {
        instance = this;
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }



    }

    public void Exit()
    {
        GameManager.Instance.ContinueTime();
        AudioManager.instance.Play(MenuMusic, true);
        SceneManager.LoadScene("Menu");
    }

    public void Dead()
    {
        changeScreen(_Dead);
        GameManager.Instance.PauseTime();
        
        AudioManager.instance.Play(DeadMusic, true);
    }

    public void Win()
    {
        changeScreen(_Victory);
        GameManager.Instance.PauseTime();
        AudioManager.instance.Play(VicotoryMusic, true);
    }

    public void Continue()
    {
        changeScreen(_Game);
        GameManager.Instance.ContinueTime();
    }

    public void PauseMenu()
    {
        changeScreen(_PauseMenu);
        GameManager.Instance.PauseTime();

    }

    public void confirmation()
    {
        UIManager.Instance.ConfirmScreen().SetConfirmAction(Exit);
        UIManager.Instance.ConfirmScreen().SetText("Estas seguro?");
        UIManager.Instance.PushConfirmScreen();
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.ContinueTime();
        AudioManager.instance.Play(GameMusic, true);
    }

    public void ButtonNoice()
    {
        AudioManager.instance.Play(ButtonName);
    }

}
