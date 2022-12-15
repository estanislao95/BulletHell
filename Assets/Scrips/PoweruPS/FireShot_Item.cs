using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot_Item : item
{
    public override void UpgradePlayer(IUpgrades entity)
    {
        entity.Upgrades(new FireShot(entity.getPowerup()));
    }
}
