using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo y Alejandro Caffarena
public class Bullet : ProyectileAbstract
{

    //public GameObject paricles;

    protected virtual void Start()
    {
        //Activated();
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

    public override void Prepare()
    {
        base.Prepare();
        _chosenStrategy = new StraightMovement(transform, transform.up, _speed);
    }
}
