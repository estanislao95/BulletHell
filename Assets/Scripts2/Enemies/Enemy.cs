using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyAbstract
{

    [SerializeField] protected float[] phases = { 1, 2 };

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
        Enemy_SegmentedMovement em = new Enemy_SegmentedMovement(transform, -transform.up, Shoot, FlyweightPointer.EnemyCockroach.speed, FlyweightPointer.EnemyCockroach.exitSpeed, FlyweightPointer.EnemyCockroach.fireRate);
        //em.SetPhases(phases); //comentado por un error muy extraño error:
                                //por alguna razon aumentaban los valores de phases cuando se spawneaban los clones
                                //de 2, 3, 1 pasaba a 2, 7, 17. en inspector.
                                //pero no entendemos porque, porque el valor phases nunca deberia ser directamente modificado.

        ChangeStrategy(em);
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
