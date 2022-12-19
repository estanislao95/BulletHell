using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotatingPoint : Enemy
{
    [SerializeField] Transform RotHolder;
    
    public override void DefaultStrategy()
    {
        Enemy_SideToSideMovement m = new Enemy_SideToSideMovement(RotHolder, transform, transform.right, Shoot, FlyweightPointer.EnemyRotate.speed * 2, FlyweightPointer.EnemyRotate.fireRate);
        m.ShotType(_proyectileType);
        ChangeStrategy(m);
    }

}
