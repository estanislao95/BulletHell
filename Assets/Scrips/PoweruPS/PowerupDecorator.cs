using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupDecorator : AbstractPowerup
{
    protected AbstractPowerup _powerup;

    public PowerupDecorator(AbstractPowerup powerup)
    {
        _powerup = powerup;
    }
}
