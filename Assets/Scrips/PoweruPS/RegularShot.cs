using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularShot : AbstractPowerup
{
    public RegularShot()
    {
        type = PlayerProyectileType.straight;
        firerate = 1.4f;
        cannonLevel = 0;
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
