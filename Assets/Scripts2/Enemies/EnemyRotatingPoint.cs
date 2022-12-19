using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotatingPoint : Enemy
{
    [SerializeField] Transform RotHolder;
    
    public override void DefaultStrategy()
    {
        Enemy_SideToSideMovement m = new Enemy_SideToSideMovement(RotHolder, transform, transform.right, Shoot, _speed * 2, _speed, shootFrequency);
        m.ShotType(_proyectileType);
        ChangeStrategy(m);
    }

}
