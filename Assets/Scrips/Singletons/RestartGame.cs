using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : Singleton<RestartGame>
{
    public Player player;
    public Transform resetpoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        player.transform.position = resetpoint.position;
        EnemyHandler.instance.restartwave();

    }


}
