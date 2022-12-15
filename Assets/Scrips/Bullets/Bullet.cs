using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProyectileAbstract
{

    //public GameObject paricles;

    protected virtual void Start()
    {
        Activated();

        _chosenStrategy = new StraightMovement(transform, transform.up, _speed);
        //_chosenStrategy = new SineMovement(transform, transform.up, transform.right, _speed, 3, 0.25f);
    }
    private void Update()
    {
        StrategyMove(_chosenStrategy);

        lifeTimeCount(Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Ilife target = collision.GetComponent<IPlayerLife>();

        if (target != null)
        {
            target.Damage(_damage);
            Deactivated();
        }
    }
}
