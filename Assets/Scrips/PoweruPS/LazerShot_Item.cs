using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot_Item : item
{
    public override void UpgradePlayer(IUpgrades entity)
    {
        entity.Upgrades(new LazerShot(entity.getPowerup()));
    }
}
