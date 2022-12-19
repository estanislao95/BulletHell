using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cannons : MonoBehaviour, IUpgrades
{

    public List<CannonsUpgrades> _cannons;

    [SerializeField]
    float timer, MaxTimer;
    [SerializeField]
    int timermultipler;
    [SerializeField]
    string Player_Shoot, Player_Upgrade;

    AbstractPowerup powerup;

    public event Action shoot;

    // Start is called before the first frame update
    void Start()
    {
        powerup = new RegularShot();
    }

    // Update is called once per frame
    void Update()
    {
        timer += timermultipler * Time.deltaTime;
        
    }

    public void Shoot()
    {
        if (timer >= MaxTimer)
        {
            AudioManager.instance.Play(Player_Shoot);
            _cannons[powerup.cannonLevel].shooting(powerup.type);
            timer = 0;
            shoot?.Invoke();
        }
    }

    

    public void Upgrades(PowerupDecorator pwr)
    {
        powerup = pwr;
        AudioManager.instance.Play(Player_Upgrade);
        MaxTimer = pwr.firerate;
        //player aplica decorator
        CheckCannonLevels();
    }

    public void CheckCannonLevels()//temp?
    {
        if (powerup.getCannonLevel() > _cannons.Count - 1)
        {
            powerup.cannonLevel = _cannons.Count - 1;
        }
    }
    public AbstractPowerup getPowerup()
    {
        return powerup;
    }
}
