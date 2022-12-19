using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiagonal : Enemy
{
    [SerializeField] float _hspeed = 2;
    public override void DefaultStrategy()
    {
        Enemy_DiagonalMovement em = new Enemy_DiagonalMovement(transform, Shoot, new Vector2(_hspeed, _speed), shootFrequency);
        //em.SetPhases(phases);
        ChangeStrategy(em);
    }

}
