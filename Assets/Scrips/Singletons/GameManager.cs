using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Points;
    public Player player;
<<<<<<< Updated upstream
=======
    public List<string> levels = new List<string>();
    public int _remeber;

>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
    
=======
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(levels[scene]);
    }

    public void ToRandomScene()
    {
        SceneManager.LoadScene(SceneRandom());
    }


    public string SceneRandom()
    {
        int select = Random.Range(0, levels.Count);


        while (select == _remeber)
        {
            select = Random.Range(0, levels.Count);
        }

        return levels[select];
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
    }
>>>>>>> Stashed changes
}
