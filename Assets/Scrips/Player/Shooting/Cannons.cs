using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannons : MonoBehaviour, IUpgrades
{

    public List<ICannonUpgrades> _cannons = CannonsUpgrades.upgrades;

    [SerializeField]
    float timer, MaxTimer;
    [SerializeField]
    int timermultipler, cannonLevels;

    AbstractPowerup powerup;

    // Start is called before the first frame update
    void Start()
    {
        powerup = new RegularShot();
    }

    // Update is called once per frame
    void Update()
    {
        timer += timermultipler * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int tepm = cannonLevels;

            tepm++;

            if (tepm > _cannons.Count - 1)
            {
                cannonLevels = _cannons.Count - 1;
            }
            else
            {
                cannonLevels = tepm;
            }
            return;
        }


        if (Input.GetKey(KeyCode.Space) && timer >= MaxTimer)
        {
            _cannons[powerup.cannonLevel].shooting(powerup.type);
            timer = 0;
        }
    }


    public void Upgrades(PowerupDecorator pwr)
    {
        powerup = pwr;
        //player aplica decorator
    }

    public AbstractPowerup getPowerup()
    {
        return powerup;
    }
}
