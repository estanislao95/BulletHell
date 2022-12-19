using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyAbstract
{
    [SerializeField] protected float shootFrequency = 1;


    #region Preparation
    protected virtual void Start()
    {
        Prepare();
    }

    public override void Prepare()
    {
        base.Prepare();
        DefaultStrategy();
    }

    public override void DefaultStrategy()
    {
        ChangeStrategy(new Enemy_SegmentedMovement(transform, -transform.up, Shoot, _speed * 2, _speed, shootFrequency));
    }

    #endregion


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
