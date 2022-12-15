using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPowerup
{
    public PlayerProyectileType type;
    public int cannonLevel;
    public abstract PlayerProyectileType getShotType();
    public abstract int getCannonLevel(); 
}
