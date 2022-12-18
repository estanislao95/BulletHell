using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockjetShot : PowerupDecorator
{
    public RockjetShot(AbstractPowerup pwr) : base(pwr)
    {
        type = PlayerProyectileType.rocket;
        firerate = 6.1f;
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
