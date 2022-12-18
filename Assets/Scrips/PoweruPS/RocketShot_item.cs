using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShot_item : item
{
    public override void UpgradePlayer(IUpgrades entity)
    {
        entity.Upgrades(new RockjetShot(entity.getPowerup()));
    }
}
