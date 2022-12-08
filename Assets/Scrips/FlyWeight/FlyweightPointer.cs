using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly FlyWeight Player = new FlyWeight
    {
        speed = 5,
        maxLife = 15,
    };

    public static readonly FlyWeight Enemy = new FlyWeight
    {
        speed = 2,
        maxLife = 25
    };

}
