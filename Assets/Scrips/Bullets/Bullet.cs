using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProyectileAbstract
{

    //public GameObject paricles;

    private void Start()
    {
        Activated();

        _chosenStrategy = new StraightMovement(transform, transform.up, _speed);
    }
    private void Update()
    {
        StrategyMove(_chosenStrategy);

        lifeTimeCount(Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ilife target = collision.GetComponent<Ilife>();

        if (target != null)
        {
            target.Damage(_damage);
            Deactivated();
        }
    }
}
