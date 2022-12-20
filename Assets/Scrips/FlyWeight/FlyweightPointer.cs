using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly FlyWeight Player = new FlyWeight
    {
        speed = 5,
        maxLife = 8,
        IFrames = 0.5f
    };

    public static readonly FlyWeight_Enemy Enemy = new FlyWeight_Enemy
    {
        speed = 2,
        maxLife = 5,
        IFrames = 0.1f,
        fireRate = 0.5f
    };

    public static readonly FlyWeight_EnemyCockroach EnemyCockroach = new FlyWeight_EnemyCockroach
    {
        speed = 2,
        exitSpeed = 1f,
        maxLife = 5,
        IFrames = 0.1f,
        fireRate = 0.5f
    };

    public static readonly FlyWeight_EnemyDiagonal EnemyDiagonal = new FlyWeight_EnemyDiagonal
    {
        speed = 1,
        horizontal_speed = 2,
        IFrames = 0.1f,
        fireRate = 0.3f
    };

    public static readonly FlyWeight_Enemy EnemyRotate = new FlyWeight_Enemy
    {
        speed = 2,
        maxLife = 5,
        IFrames = 0.1f,
        fireRate = 0.5f
    };
}
