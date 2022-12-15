using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SomethingEnter(collision);

    }

    public void SomethingEnter(Collider2D collision)
    {
        IUpgrades entity = collision.GetComponent<IUpgrades>();

        if (entity != null)
        {
            UpgradePlayer(entity);
            Destroy(this.gameObject);
        }
    }

    public virtual void UpgradePlayer(IUpgrades entity)
    {
        //entity.Upgrades(new FireShot(entity.getPowerup())); //TEMP.

    }

}
