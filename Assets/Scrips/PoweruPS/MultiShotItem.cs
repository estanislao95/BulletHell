using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotItem : item
{
    public override void UpgradePlayer(IUpgrades entity)
    {
        entity.Upgrades(new MultiShot(entity.getPowerup()));
    }
}
