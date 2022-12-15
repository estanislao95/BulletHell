using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrades
{
    void Upgrades(PowerupDecorator pwr);

    AbstractPowerup getPowerup();
}
