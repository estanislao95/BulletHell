using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiagonal : Enemy
{
    public override void DefaultStrategy()
    {
        Enemy_DiagonalMovement em = new Enemy_DiagonalMovement(transform, Shoot, new Vector2(FlyweightPointer.EnemyDiagonal.horizontal_speed, FlyweightPointer.EnemyDiagonal.speed), FlyweightPointer.EnemyDiagonal.fireRate);
        //em.SetPhases(phases);
        ChangeStrategy(em);
    }

}
