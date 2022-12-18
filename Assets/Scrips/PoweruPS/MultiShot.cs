using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : PowerupDecorator
{
    public MultiShot(AbstractPowerup pwr) : base(pwr)
    {
        type = pwr.type;
        firerate = pwr.firerate;
        cannonLevel = pwr.cannonLevel + 1;
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
