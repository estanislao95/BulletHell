using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : PowerupDecorator
{
    public LazerShot(AbstractPowerup pwr) : base(pwr)
    {
        type = PlayerProyectileType.Lazer;
        firerate = 2.1f;
        cannonLevel = pwr.cannonLevel;
        _powerup = pwr;
    }
    public override int getCannonLevel()
    {
        return cannonLevel;
    }

    public override PlayerProyectileType getShotType()
    {
        return type;
    }

    public override float getfirerate()
    {
        return firerate;
    }
}
