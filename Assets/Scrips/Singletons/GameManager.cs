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

    public void LoadLevel(int level = 0)
    {
        SceneManager.LoadScene(levels[level]);
    }

    public void PlayNextLevel()
    {
        currentlevel++;
        if (currentlevel > levels.Count)
        {
            FinishGame();
            return;
        }

        LoadLevel(currentlevel);
    }

    public void FinishGame() 
    {
        currentlevel = 0; //TEMP! En teoria aca iria el link al nivel o boss o cutscene final
        LoadLevel(currentlevel);
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
