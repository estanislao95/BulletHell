using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Menu
{
    public int _Game ,_Menu, _Dead, _Victory;
    public static MenuManager instance;
    public string ButtonName, VicotoryMusic, DeadMusic, MenuMusic, GameMusic;


    protected override void Awake()
    {
        instance = this;
        base.Awake();
    }

    private void Start()
    {
        AudioManager.instance.Play(MenuMusic, true);
        PauseTime();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }



    }


    public void PauseMenu()
    {
        PauseTime();

        UIManager.Instance.ConfirmScreen().SetConfirmAction(Exit);
        UIManager.Instance.ConfirmScreen().SetText("Pausa");
        UIManager.Instance.PushConfirmScreen();
    }


    public void Exit()
    {
        changeScreen(_Menu);
        ContinueTime();
        RestartGame.Instance.restart();
        AudioManager.instance.Play(MenuMusic, true);
    }

    public void Dead()
    {
        changeScreen(_Dead);
        PauseTime();
        RestartGame.Instance.restart();
        AudioManager.instance.Play(DeadMusic, true);
    }

    public void Win()
    {
        changeScreen(_Victory);
        PauseTime();
        AudioManager.instance.Play(VicotoryMusic, true);
    }

    public void start()
    {
<<<<<<< Updated upstream
        changeScreen(_Game);
        ContinueTime();
        RestartGame.Instance.restart();
        EnemyHandler.instance.WaveStart(EnemyHandler.instance.waves[0]);
        
        UIManager.Instance.wavecounter(0);
=======
        GameManager.Instance.ContinueTime();
        GameManager.Instance.SceneRandom();
>>>>>>> Stashed changes
        AudioManager.instance.Play(GameMusic, true);
    }
    public void exit()
    {
        

    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
    }

    public void ButtonNoice()
    {
        AudioManager.instance.Play(ButtonName);
    }

}
