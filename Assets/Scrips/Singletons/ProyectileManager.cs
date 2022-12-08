using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileManager : MonoBehaviour
{

    public static ProyectileManager instance;

    Factory<Bullet> _pool;
    Factory<Bullet> _poolPlayer;

    [SerializeField]
    Bullet EnemyArrow;
    [SerializeField]
    Bullet Arrow;


    [SerializeField]
    int PreinstanceAmount = 15;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        _poolPlayer = new Factory<Bullet>(Factory, Bullet.TurnOn, Bullet.TurnOff, PreinstanceAmount);
        _pool = new Factory<Bullet>(EnemyFactory, Bullet.TurnOn, Bullet.TurnOff, PreinstanceAmount);
    }

    // Update is called once per frame
    public Bullet Factory()
    {
        var arrow = Instantiate(Arrow);
        return arrow;
    }
    public Bullet EnemyFactory()
    {
        var arrow = Instantiate(EnemyArrow);
        return arrow;
    }



    public void Create(Transform tip, bool fromPlayer = false, int type = 0)
    {

        if (!fromPlayer)
        {
            var b = _pool.GetObject();
            b.Create(_pool);
            b.transform.position = tip.position;
            b.transform.up = tip.up;
        }
        else
        {
            var b = _poolPlayer.GetObject();
            b.Create(_poolPlayer);
            b.transform.position = tip.position;
            b.transform.up = tip.up;


            switch (type)
            {
                case 0:
                    break; 
            }

        }

    }


}
