using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeight
{
    public int maxLife;
    public float speed;
    public float IFrames;
}

public class FlyWeight_Enemy : FlyWeight
{
    public float fireRate;
}

public class FlyWeight_EnemyCockroach : FlyWeight_Enemy
{
    public float exitSpeed;
}

public class FlyWeight_EnemyDiagonal : FlyWeight_Enemy
{
    public float horizontal_speed;
}

