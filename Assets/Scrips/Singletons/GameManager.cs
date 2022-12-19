using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public int Points;
    public Player player;
    public List<string> levels = new List<string>();
    public int currentlevel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addpoints(int points)
    {
        Points += points;
        UIManager.Instance.pointcounter(Points);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levels[currentlevel]);
        currentlevel++;
    }
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
    }
}
