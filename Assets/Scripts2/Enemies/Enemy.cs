using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyAbstract
{
    [SerializeField] float shootFrequency = 1;
    protected virtual void Start()
    {
        Activated();

        _chosenStrategy = new Enemy_SegmentedMovement(transform, -transform.up, Shoot, _speed * 2, _speed, shootFrequency);
        //_chosenStrategy = new Enemy_StraightMovement(transform, -transform.up, Shoot, _speed, shootFrequency);
        //_chosenStrategy = new SineMovement(transform, transform.up, transform.right, _speed, 3, 0.25f);
    }

    private void Update()
    {
        StrategyMove(_chosenStrategy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ilife target = collision.GetComponent<IPlayerLife>();

        if (target != null)
        {
            target.Damage(_damage);
        }
    }
}
