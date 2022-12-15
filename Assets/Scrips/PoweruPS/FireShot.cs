using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : PowerupDecorator
{
    public FireShot(AbstractPowerup pwr) : base(pwr)
    {
        type = PlayerProyectileType.fire;
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
}
